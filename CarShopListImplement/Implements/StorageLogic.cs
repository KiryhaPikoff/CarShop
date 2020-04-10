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

        /// <summary>
        /// Метод обновляющий состояние компонентов на конкретном складе.
        /// </summary>
        /// <param name="storageId">ID обновляемого склада</param>
        /// <param name="components">Новое состояние его компонентов</param>
        public void updateComponentOnStorage(int storageId, Dictionary<int, (string, int)> components)
        {
            int maxCCId = 0;
            for (int i = 0; i < source.StorageComponents.Count; ++i)
            {
                if (source.StorageComponents[i].Id > maxCCId)
                {
                    maxCCId = source.StorageComponents[i].Id;
                }
                if (source.StorageComponents[i].StorageId == storageId)
                {
                    // если в модели пришла запись компонента с таким id
                    if
                    (components.ContainsKey(source.StorageComponents[i].ComponentId))
                    {
                        // обновляем количество
                        source.StorageComponents[i].Count = components[source.StorageComponents[i].ComponentId].Item2;
                        // из модели убираем эту запись, чтобы остались только не просмотренные
                        components.Remove(source.StorageComponents[i].ComponentId);
                    }
                    else
                    {
                        source.StorageComponents.RemoveAt(i--);
                    }
                }
            }
            // новые записи
            foreach (var sc in components)
            {
                source.StorageComponents.Add(new StorageComponent
                {
                    Id = ++maxCCId,
                    StorageId = storageId,
                    ComponentId = sc.Key,
                    Count = sc.Value.Item2
                });
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
                Id = -1, // такова логика!
                StorageId = model.StorageId,
                ComponentId = model.ComponentId,
                Count = model.Count
            };

            foreach (StorageComponent storageComponent in source.StorageComponents)
            {
                if (addedComponent.StorageId == storageComponent.StorageId &&
                    addedComponent.ComponentId == storageComponent.ComponentId)
                    {
                        addedComponent.Id = storageComponent.Id;
                        int prevCount = storageComponent.Count;
                        addedComponent.Count += prevCount;
                    }
            }
            this.saveOrUpdateStorageComponent(addedComponent);
        }

        private bool isComponentExist(int componentId)
        {
            bool isComponentExist = false;
            foreach (Component component in source.Components)
            {
                if (componentId == component.Id)
                {
                    isComponentExist = true;
                    break;
                }
            }
            return isComponentExist;
        }

        private bool isStorageExist(int storageId) 
        {
            bool isStorageExist = false;
            foreach (Storage storage in source.Storages)
            {
                if (storageId == storage.Id) {
                    isStorageExist = true;
                    break;
                }
            }
            return isStorageExist;
        }

        private void saveOrUpdateStorageComponent(StorageComponent storageComponent)
        {
            if (storageComponent.Id == -1)
            {
                int maxId = 0;
                foreach (StorageComponent sc in source.StorageComponents)
                {
                    if (sc.Id > maxId)
                    {
                        maxId = sc.Id;
                    }
                }
                storageComponent.Id = maxId + 1;
            }
            source.StorageComponents.Add(storageComponent);
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
