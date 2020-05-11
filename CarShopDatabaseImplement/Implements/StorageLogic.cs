using CarShopBuisnessLogic.BindingModels;
using CarShopBuisnessLogic.Interfaces;
using CarShopBuisnessLogic.ViewModels;
using CarShopDatabaseImplement.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CarShopDatabaseImplement.Implements
{
    public class StorageLogic : IStorageLogic
    {
        public void CreateOrUpdate(StorageBindingModel model)
        {
            using (var context = new CarShopDatabase())
            {
                using (var transaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        Storage storage = context.Storages.FirstOrDefault(rec => rec.StorageName == model.StorageName && rec.Id != model.Id);
                        if (storage != null)
                        {
                            throw new Exception("Уже есть склад с таким названием");
                        }
                        if (model.Id.HasValue)
                        {
                            storage = context.Storages.FirstOrDefault(rec => rec.Id == model.Id);
                            if (storage == null)
                            {
                                throw new Exception("Склад не найден");
                            }
                        }
                        else
                        {
                            storage = new Storage();
                            context.Storages.Add(storage);
                        }
                        storage.StorageName = model.StorageName;
                        context.SaveChanges();
                        transaction.Commit();
                    }
                    catch (Exception)
                    {
                        transaction.Rollback();
                        throw;
                    }
                }
            }
        }

        public void Delete(StorageBindingModel model)
        {
            using (var context = new CarShopDatabase())
            {
                using (var transaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        // удаяем записи по компонентам при удалении изделия
                        context.StorageComponents.RemoveRange(context.StorageComponents.Where(rec =>
                        rec.StorageId == model.Id));
                        Storage storage = context.Storages.FirstOrDefault(rec => rec.Id == model.Id);
                        if (storage != null)
                        {
                            context.Storages.Remove(storage);
                            context.SaveChanges();
                        }
                        else
                        {
                            throw new Exception("Элемент не найден");
                        }
                        transaction.Commit();
                    }
                    catch (Exception)
                    {
                        transaction.Rollback();
                        throw;
                    }
                }
            }
        }

        public void AddComponent(AddComponentBindingModel model)
        {
            using (var context = new CarShopDatabase())
            {
                using (var transaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        if (context.Components.Count(x => x.Id == model.ComponentId) == 0)
                        {
                            throw new Exception("Добавляемый компонент не существует.");
                        }
                        if (context.Storages.Count(x => x.Id == model.StorageId) == 0)
                        {
                            throw new Exception("Склад на который хотите добавить компонент не существует.");
                        }
                        if (model.Count <= 0)
                        {
                            throw new Exception("Нельзя добавить компонент с количество меньше или равному нуля.");
                        }

                        StorageComponent storageComponent = context.StorageComponents
                        .FirstOrDefault(x => x.ComponentId == model.ComponentId && x.StorageId == model.StorageId);
                        if (storageComponent == null)
                        {
                            storageComponent = new StorageComponent
                            {
                                StorageId = model.StorageId,
                                ComponentId = model.ComponentId,
                                Count = model.Count
                            };
                            context.StorageComponents.Add(storageComponent);
                        }
                        else
                        {
                            storageComponent.Count += model.Count;
                        }

                        context.SaveChanges();
                        transaction.Commit();
                    }
                    catch (DbUpdateException e)
                    {
                        transaction.Rollback();
                        throw e.InnerException;
                    }
                }
            }
        }

        public void DiscountComponents(List<ComponentCountBindingModel> models)
        {
            using (var context = new CarShopDatabase())
            {
                using (var transaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        foreach (var componentCount in models)
                        {
                            bool discounted = false;
                            foreach (var storageComponent in context.StorageComponents
                                .Where(x => componentCount.ComponentId == x.ComponentId))
                            {
                                // Количество компонента на складе
                                int storageCount = storageComponent.Count;
                                // Сколько необходимо списать
                                int needCount = componentCount.Count;
                                // Сколько можем списать
                                int canDiscount = storageCount >= needCount ? needCount : storageCount;
                                storageComponent.Count -= canDiscount;
                                componentCount.Count -= canDiscount;
                                // Если списали, сколько хотели, то переходим к следующему компоненту
                                discounted = componentCount.Count == 0;
                            }
                            if (!discounted)
                            {
                                throw new Exception("Не получилось списать компонент по причине его нехватки.");
                            }
                        }
                        context.SaveChanges();
                        transaction.Commit();
                    }
                    catch (Exception)
                    {
                        transaction.Rollback();
                        throw;
                    }
                }
            }
        }

        /// <summary>
        /// Провека на наличие компонента на складе в нужном количестве.
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool IsComponentsInStock(List<ComponentCountBindingModel> models)
        {
            using (var context = new CarShopDatabase())
            {
                foreach (var model in models)
                {
                    int totalStorageCount = 0;
                    foreach (var storageComponent in context.StorageComponents)
                    {
                        if (storageComponent.ComponentId == model.ComponentId)
                        {
                            totalStorageCount += storageComponent.Count;
                        }
                    }
                    if (totalStorageCount < model.Count)
                    {
                        return false;
                    }
                }
                return true;
            }
        }

        public List<StorageViewModel> Read(StorageBindingModel model)
        {
            using (var context = new CarShopDatabase())
            {
                return context.Storages
                .Where(rec => model == null || rec.Id == model.Id)
                .ToList()
               .Select(rec => new StorageViewModel
               {
                   Id = rec.Id,
                   StorageName = rec.StorageName,
                   StorageComponents = context.StorageComponents.Include(recPC => recPC.Component)
               .Where(recPC => recPC.StorageId == rec.Id)
               .ToDictionary(recPC => recPC.ComponentId, recPC =>
                (recPC.Component?.ComponentName, recPC.Count))
               })
               .ToList();
            }
        }
    }
}
