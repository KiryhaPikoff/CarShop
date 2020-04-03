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

        public void updateComponentsOnStorage(int storageId, Dictionary<int, (string, int)> components)
        {
            using (var context = new CarShopDatabase())
            {
                using (var transaction = context.Database.BeginTransaction())
                {
                    var StorageComponents = context.StorageComponents.Where(rec => rec.StorageId == storageId).ToList();
                    // удалили те, которых нет в модели
                    context.StorageComponents.RemoveRange(StorageComponents.Where(rec => !components.ContainsKey(rec.ComponentId)).ToList());
                    context.SaveChanges();
                    // обновили количество у существующих записей
                    foreach (var updateComponent in StorageComponents)
                    {
                        updateComponent.Count = components[updateComponent.ComponentId].Item2;
                        components.Remove(updateComponent.ComponentId);
                    }
                    context.SaveChanges();
                    // добавили новые
                    foreach (var sc in components)
                    {
                        context.StorageComponents.Add(new StorageComponent
                        {
                            StorageId = storageId,
                            ComponentId = sc.Key,
                            Count = sc.Value.Item2
                        });
                        context.SaveChanges();
                    }
                    transaction.Commit();
                }
            }
        }
    }
}
