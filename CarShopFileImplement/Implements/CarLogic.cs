using CarShopBuisnessLogic.BindingModels;
using CarShopBuisnessLogic.Interfaces;
using CarShopBuisnessLogic.ViewModels;
using CarShopFileImplement.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CarShopFileImplement.Implements
{
    public class CarLogic : ICarLogic
    {
        private readonly FileDataListSingleton source;

        public CarLogic() 
        { 
            source = FileDataListSingleton.GetInstance(); 
        }

        public void CreateOrUpdate(CarBindingModel model)
        {
            Car car = source.Cars.FirstOrDefault(rec => rec.CarName == model.CarName && rec.Id != model.Id);
            if (car != null)
            {
                throw new Exception("Уже есть машина с таким названием");
            }
            if (model.Id.HasValue)
            {
                car = source.Cars.FirstOrDefault(rec => rec.Id == model.Id);
                if (car == null)
                {
                    throw new Exception("Элемент не найден");
                }
            }
            else
            {
                int maxId = source.Cars.Count > 0 ? source.Components.Max(rec => rec.Id) : 0;
                car = new Car { Id = maxId + 1 };
                source.Cars.Add(car);
            }
            car.CarName = model.CarName;
            car.Price = model.Price;
            // удалили те, которых нет в модели
            source.CarComponents.RemoveAll(rec => rec.CarId == model.Id && !model.CarComponents.ContainsKey(rec.ComponentId));
            // обновили количество у существующих записей
            var updateComponents = source.CarComponents.Where(rec => rec.CarId == model.Id && model.CarComponents.ContainsKey(rec.ComponentId));
            foreach (var updateComponent in updateComponents)
            {
                updateComponent.Count = model.CarComponents[updateComponent.ComponentId].Item2;
                model.CarComponents.Remove(updateComponent.ComponentId);
            }
            // добавили новые
            int maxPCId = source.CarComponents.Count > 0 ? source.CarComponents.Max(rec => rec.Id) : 0;
            foreach (var pc in model.CarComponents)
            {
                source.CarComponents.Add(new CarComponent
                {
                    Id = ++maxPCId,
                    CarId = car.Id,
                    ComponentId = pc.Key,
                    Count = pc.Value.Item2
                });
            }
        }
        public void Delete(CarBindingModel model)
        {
            // удаяем записи по компонентам при удалении изделия
            source.CarComponents.RemoveAll(rec => rec.CarId == model.Id);
            Car car = source.Cars.FirstOrDefault(rec => rec.Id == model.Id);
            if (car != null)
            {
                source.Cars.Remove(car);
            }
            else
            {
                throw new Exception("Элемент не найден");
            }
        }
        public List<CarViewModel> Read(CarBindingModel model)
        {
            return source.Cars
            .Where(rec => model == null || rec.Id == model.Id)
            .Select(rec => new CarViewModel
            {
                Id = rec.Id,
                CarName = rec.CarName,
                Price = rec.Price,
                CarComponents = source.CarComponents
            .Where(recPC => recPC.CarId == rec.Id)
            .ToDictionary(recPC => recPC.ComponentId, recPC =>
                (source.Components.FirstOrDefault(recC => recC.Id == recPC.ComponentId)?.ComponentName, recPC.Count))
            })
            .ToList();
        }
    }
}
