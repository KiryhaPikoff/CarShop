using CarShopBuisnessLogic.BindingModels;
using CarShopBuisnessLogic.Interfaces;
using CarShopBuisnessLogic.ViewModels;
using CarShopFileImplement.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CarShopFileImplement.Implements
{
    public class StorageLogic : IStorageLogic
    {
        private readonly FileDataListSingleton source;

        public StorageLogic()
        {
            source = FileDataListSingleton.GetInstance();
        }

        public void CreateOrUpdate(StorageBindingModel model)
        {
            Storage storage = source.Storages.FirstOrDefault(rec => rec.StorageName == model.StorageName && rec.Id != model.Id);
            if (storage != null)
            {
                throw new Exception("Уже есть склад с таким названием");
            }
            if (model.Id.HasValue)
            {
                storage = source.Storages.FirstOrDefault(rec => rec.Id == model.Id);
                if (storage == null)
                {
                    throw new Exception("Элемент не найден");
                }
            }
            else
            {
                int maxId = source.Storages.Count > 0 ? source.Storages.Max(rec => rec.Id) : 0;
                storage = new Storage { Id = maxId + 1 };
                source.Storages.Add(storage);
            }
            storage.StorageName = model.StorageName;
        }

        public void Delete(StorageBindingModel model)
        {
            // удаяем записи по компонентам при удалении склада
            source.StorageComponents.RemoveAll(rec => rec.StorageId == model.Id);
            Storage storage = source.Storages.FirstOrDefault(rec => rec.Id == model.Id);
            if (storage != null)
            {
                source.Storages.Remove(storage);
            }
            else
            {
                throw new Exception("Элемент не найден");
            }
        }
        public void AddComponent(AddComponentBindingModel model)
        {
            if (!isStorageExist(model.StorageId) ||
                 !isComponentExist(model.ComponentId) ||
                 model.Count <= 0)
            {
                throw new Exception("Ошибка добавления компонента на склад");
            }

            StorageComponent storageComponent = source.StorageComponents
                .FirstOrDefault(x => x.ComponentId == model.ComponentId &&
                                 x.StorageId == model.StorageId);

            if (storageComponent != null)
            {
                storageComponent.Count += model.Count;
                source.StorageComponents.RemoveAll(x => x.Id == storageComponent.Id);
            }
            else
            {
                storageComponent = new StorageComponent
                {
                    Id = source.StorageComponents.Max(x => x.Id) + 1,
                    ComponentId = model.ComponentId,
                    StorageId = model.StorageId,
                    Count = model.Count
                };
            }
            source.StorageComponents.Add(storageComponent);
        }

        public void DiscountComponents(List<ComponentCountBindingModel> models)
        {
            if (!IsComponentsInStock(models))
            {
                throw new Exception("Недостаточно компонентов на складах.");
            }

            foreach (var componentCount in models)
            {
                foreach (var storageComponent in source.StorageComponents
                    .Where(x => componentCount.ComponentId == x.ComponentId))
                {
                    // Количества компонента на складе
                    int storageCount = storageComponent.Count;
                    // Сколько необходимо списать
                    int needCount = componentCount.Count;
                    // Сколько можем списать
                    int canDiscount = storageCount >= needCount ? needCount : storageCount;
                    storageComponent.Count -= canDiscount;
                    componentCount.Count -= canDiscount;
                    // Если списали, сколько хотели, то переходим к следующему компоненту
                    if (componentCount.Count == 0)
                    {
                        break;
                    }
                }
            }
        }

        /// <summary>
        /// Провека на наличие компонентов на складе в нужном количестве.
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool IsComponentsInStock(List<ComponentCountBindingModel> models)
        {
            foreach (var model in models)
            {
                if (!isComponentInStock(model))
                {
                    return false;
                }
            }
            return true;
        }

        /// <summary>
        /// Провека на наличие компонента на складе в нужном количестве.
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        private bool isComponentInStock(ComponentCountBindingModel model)
        {
            return source.StorageComponents
                .Where(x => x.ComponentId == model.ComponentId)
                .Sum(x => x.Count) >= model.Count;
        }

        private bool isComponentExist(int componentId)
        {
            return source.Components.Count(x => x.Id == componentId) > 0;
        }

        private bool isStorageExist(int storageId)
        {
            return source.Storages.Count(x => x.Id == storageId) > 0;
        }

        public List<StorageViewModel> Read(StorageBindingModel model)
        {
            return source.Storages
               .Where(rec => model == null || rec.Id == model.Id)
               .Select(rec => new StorageViewModel
               {
                   Id = rec.Id,
                   StorageName = rec.StorageName,
                   StorageComponents = source.StorageComponents
               .Where(recPC => recPC.StorageId == rec.Id)
               .ToDictionary(recPC => recPC.ComponentId, recPC =>
                   (source.Components.FirstOrDefault(recC => recC.Id == recPC.ComponentId)?.ComponentName, recPC.Count))
               })
               .ToList();
        }
    }
}
