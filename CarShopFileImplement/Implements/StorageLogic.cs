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
            // удалили те, которых нет в модели
            source.StorageComponents.RemoveAll(rec => rec.StorageId == model.Id && !model.StorageComponents.ContainsKey(rec.ComponentId));
            // обновили количество у существующих записей
            var updateComponents = source.StorageComponents.Where(rec => rec.StorageId == model.Id && model.StorageComponents.ContainsKey(rec.ComponentId));
            foreach (var updateComponent in updateComponents)
            {
                updateComponent.Count = model.StorageComponents[updateComponent.ComponentId].Item2;
                model.StorageComponents.Remove(updateComponent.ComponentId);
            }
            // добавили новые
            int maxPCId = source.StorageComponents.Count > 0 ? source.StorageComponents.Max(rec => rec.Id) : 0;
            foreach (var pc in model.StorageComponents)
            {
                source.StorageComponents.Add(new StorageComponent
                {
                    Id = ++maxPCId,
                    StorageId = storage.Id,
                    ComponentId = pc.Key,
                    Count = pc.Value.Item2
                });
            }
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
