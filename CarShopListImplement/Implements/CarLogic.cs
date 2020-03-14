using CarShopBuisnessLogic.BindingModels;
using CarShopBuisnessLogic.Interfaces;
using CarShopBuisnessLogic.ViewModels;
using CarShopListImplement.Models;
using System;
using System.Collections.Generic;

namespace CarShopListImplement.Implements
{
    public class CarLogic : ICarLogic
    {
        private readonly DataListSingleton source;
        public CarLogic()
        {
            source = DataListSingleton.GetInstance();
        }
        public void CreateOrUpdate(CarBindingModel model)
        {
            Car tempCar = model.Id.HasValue ? null : new Car { Id = 1 };
            foreach (var product in source.Cars)
            {
                if (product.CarName == model.CarName && product.Id != model.Id)
                {
                    throw new Exception("Уже есть машина с таким названием");
                }
                if (!model.Id.HasValue && product.Id >= tempCar.Id)
                {
                    tempCar.Id = product.Id + 1;
                }
                else if (model.Id.HasValue && product.Id == model.Id)
                {
                    tempCar = product;
                }
            }
            if (model.Id.HasValue)
            {
                if (tempCar == null)
                {
                    throw new Exception("Элемент не найден");
                }
                CreateModel(model, tempCar);
            }
            else
            {
                source.Cars.Add(CreateModel(model, tempCar));
            }
        }

        public void Delete(CarBindingModel model)
        {
            // удаляем записи по компонентам при удалении изделия
            for (int i = 0; i < source.CarComponents.Count; ++i)
            {
                if (source.CarComponents[i].CarId == model.Id)
                {
                    source.CarComponents.RemoveAt(i--);
                }
            }
            for (int i = 0; i < source.Cars.Count; ++i)
            {
                if (source.Cars[i].Id == model.Id)
                {
                    source.Cars.RemoveAt(i);
                    return;
                }
            }
            throw new Exception("Элемент не найден");
        }
        private Car CreateModel(CarBindingModel model, Car car)
        {
            car.CarName = model.CarName;
            car.Price = model.Price;
            //обновляем существуюущие компоненты и ищем максимальный идентификатор
            int maxCCId = 0;
            for (int i = 0; i < source.CarComponents.Count; ++i)
            {
                if (source.CarComponents[i].Id > maxCCId)
                {
                    maxCCId = source.CarComponents[i].Id;
                }
                if (source.CarComponents[i].CarId == car.Id)
                {
                    // если в модели пришла запись компонента с таким id
                    if
                    (model.CarComponents.ContainsKey(source.CarComponents[i].ComponentId))
                    {
                        // обновляем количество
                        source.CarComponents[i].Count = model.CarComponents[source.CarComponents[i].ComponentId].Item2;
                        // из модели убираем эту запись, чтобы остались только не просмотренные
                        model.CarComponents.Remove(source.CarComponents[i].ComponentId);
                    }
                    else
                    {
                        source.CarComponents.RemoveAt(i--);
                    }
                }
            }
            // новые записи
            foreach (var pc in model.CarComponents)
            {
                source.CarComponents.Add(new CarComponent
                {
                    Id = ++maxCCId,
                    CarId = car.Id,
                    ComponentId = pc.Key,
                    Count = pc.Value.Item2
                });
            }
            return car;
        }
        public List<CarViewModel> Read(CarBindingModel model)
        {
            List<CarViewModel> result = new List<CarViewModel>();
            foreach (var component in source.Cars)
            {
                if (model != null)
                {
                    if (component.Id == model.Id)
                    {
                        result.Add(CreateViewModel(component));
                        break;
                    }
                    continue;
                }
                result.Add(CreateViewModel(component));
            }
            return result;
        }
        private CarViewModel CreateViewModel(Car car)
        {
            // требуется дополнительно получить список компонентов для изделия с названиями и их количество
            Dictionary<int, (string, int)> carComponents = new Dictionary<int, (string, int)>();
            foreach (var cc in source.CarComponents)
            {
                if (cc.CarId == car.Id)
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
                    carComponents.Add(cc.ComponentId, (componentName, cc.Count));
                }
            }
            return new CarViewModel
            {
                Id = car.Id,
                CarName = car.CarName,
                Price = car.Price,
                CarComponents = carComponents
            };
        }
    }
}