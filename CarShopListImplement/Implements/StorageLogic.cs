﻿using CarShopBuisnessLogic.BindingModels;
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
                CreateModel(model, tempStorage);
            }
            else
            {
                source.Storages.Add(CreateModel(model, tempStorage));
            }
        }

        private Storage CreateModel(StorageBindingModel model, Storage storage)
        {
            storage.StorageName = model.StorageName;
            //обновляем существуюущие компоненты и ищем максимальный идентификатор
            int maxCCId = 0;
            for (int i = 0; i < source.StorageComponents.Count; ++i)
            {
                if (source.StorageComponents[i].Id > maxCCId)
                {
                    maxCCId = source.StorageComponents[i].Id;
                }
                if (source.StorageComponents[i].StorageId == storage.Id)
                {
                    // если в модели пришла запись компонента с таким id
                    if
                    (model.StorageComponents.ContainsKey(source.StorageComponents[i].ComponentId))
                    {
                        // обновляем количество
                        source.StorageComponents[i].Count = model.StorageComponents[source.StorageComponents[i].ComponentId].Item2;
                        // из модели убираем эту запись, чтобы остались только не просмотренные
                        model.StorageComponents.Remove(source.StorageComponents[i].ComponentId);
                    }
                    else
                    {
                        source.StorageComponents.RemoveAt(i--);
                    }
                }
            }
            // новые записи
            foreach (var pc in model.StorageComponents)
            {
                source.StorageComponents.Add(new StorageComponent
                {
                    Id = ++maxCCId,
                    StorageId = storage.Id,
                    ComponentId = pc.Key,
                    Count = pc.Value.Item2
                });
            }
            return storage;
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
