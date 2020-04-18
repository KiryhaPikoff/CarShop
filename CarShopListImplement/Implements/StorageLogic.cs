using CarShopBuisnessLogic.BindingModels;
using CarShopBuisnessLogic.Interfaces;
using CarShopBuisnessLogic.ViewModels;
using CarShopListImplement.Models;
using System;
using System.Collections.Generic;

namespace CarShopListImplement.Implements
{
    public class StorageLogic : IStorageLogic
    {
        private readonly DataListSingleton source;

        public StorageLogic()
        {
            source = DataListSingleton.GetInstance();
        }

        public void CreateOrUpdate(StorageBindingModel model)
        {
            Storage tempStorage = model.Id.HasValue ? null : new Storage
            {
                Id = 1
            };
            foreach (var storage in source.Storages)
            {
                if (storage.StorageName == model.StorageName && storage.Id != model.Id)
                {
                    throw new Exception("Уже есть склад с таким названием");
                }
                if (!model.Id.HasValue && storage.Id >= tempStorage.Id)
                {
                    tempStorage.Id = storage.Id + 1;
                }
                else if (model.Id.HasValue && storage.Id == model.Id)
                {
                    tempStorage = storage;
                }
            }

            if (model.Id.HasValue)
            {
                if (tempStorage == null)
                {
                    throw new Exception("Элемент не найден");
                }
                tempStorage.StorageName = model.StorageName;
            }
            else
            {
                tempStorage.StorageName = model.StorageName;
                source.Storages.Add(tempStorage);
            }
        }

        public void Delete(StorageBindingModel model)
        {
            // удаляем записи по компонентам при удалении склада
            for (int i = 0; i < source.StorageComponents.Count; ++i)
            {
                if (source.StorageComponents[i].StorageId == model.Id)
                {
                    source.CarComponents.RemoveAt(i--);
                }
            }
            for (int i = 0; i < source.Storages.Count; ++i)
            {
                if (source.Storages[i].Id == model.Id)
                {
                    source.Storages.RemoveAt(i);
                    return;
                }
            }
            throw new Exception("Элемент не найден");
        }

        public List<StorageViewModel> Read(StorageBindingModel model)
        {
            List<StorageViewModel> result = new List<StorageViewModel>();
            foreach (var storage in source.Storages)
            {
                if (model != null)
                {
                    if (storage.Id == model.Id)
                    {
                        result.Add(CreateViewModel(storage));
                        break;
                    }
                    continue;
                }
                result.Add(CreateViewModel(storage));
            }
            return result;
        }

        public void AddComponent(AddComponentBindingModel model)
        {
            if (!isStorageExist(model.StorageId) ||
                !isComponentExist(model.ComponentId) ||
                model.Count <= 0)
            {
                throw new Exception("Ошибка добавления компонента на склад");
            }

            StorageComponent addedComponent = new StorageComponent
            {
                StorageId = model.StorageId,
                ComponentId = model.ComponentId,
                Count = model.Count
            };

            foreach (StorageComponent storageComponent in source.StorageComponents)
            {
                if (addedComponent.StorageId == storageComponent.StorageId &&
                    addedComponent.ComponentId == storageComponent.ComponentId)
                {
                    storageComponent.Count += addedComponent.Count;
                    return;
                }
            }

            int maxId = 0;
            foreach (StorageComponent sc in source.StorageComponents)
            {
                if (sc.Id > maxId)
                {
                    maxId = sc.Id;
                }
            }
            addedComponent.Id = maxId + 1;
            source.StorageComponents.Add(addedComponent);
        }

        public void DiscountComponents(List<ComponentCountBindingModel> models)
        {
            foreach (var componentCount in models)
            {
                foreach (var storageComponent in source.StorageComponents)
                {
                    if (storageComponent.ComponentId == componentCount.ComponentId)
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
        }

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
            int totalStorageCount = 0;
            foreach (var storageComponent in source.StorageComponents)
            {
                if (storageComponent.ComponentId == model.ComponentId)
                {
                    totalStorageCount += storageComponent.Count;
                }
            }
            return totalStorageCount >= model.Count;
        }

        private bool isComponentExist(int componentId)
        {
            foreach (Component component in source.Components)
            {
                if (componentId == component.Id)
                {
                    return true;
                }
            }
            return false;
        }

        private bool isStorageExist(int storageId)
        {
            foreach (Storage storage in source.Storages)
            {
                if (storageId == storage.Id)
                {
                    return true;
                }
            }
            return false;
        }

        private StorageViewModel CreateViewModel(Storage storage)
        {
            // требуется дополнительно получить список компонентов для склада с названиями и их количество
            Dictionary<int, (string, int)> storageComponents = new Dictionary<int, (string, int)>();
            foreach (var cc in source.StorageComponents)
            {
                if (cc.StorageId == storage.Id)
                {
                    string componentName = string.Empty;
                    foreach (var component in source.Components)
                    {
                        if (cc.ComponentId == component.Id)
                        {
                            componentName = component.ComponentName;
                            break;
                        }
                    }
                    storageComponents.Add(cc.ComponentId, (componentName, cc.Count));
                }
            }
            return new StorageViewModel
            {
                Id = storage.Id,
                StorageName = storage.StorageName,
                StorageComponents = storageComponents
            };
        }
    }
}
