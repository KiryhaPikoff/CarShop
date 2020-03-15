using AbstractShopBusinessLogic.Interfaces;
using CarShopBuisnessLogic.BindingModels;
using CarShopBuisnessLogic.Enums;
using CarShopBuisnessLogic.Interfaces;
using CarShopBuisnessLogic.ViewModels;
using CarShopFileImplement.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CarShopFileImplement.Implements
{
    public class MainLogic : IMainLogic
    {
        private readonly IOrderLogic orderLogic;

        private readonly ICarLogic carLogic;

        private readonly IComponentLogic componentLogic;

        private readonly IStorageLogic storageLogic;

        public MainLogic(IOrderLogic orderLogic, ICarLogic carLogic, IComponentLogic componentLogic, IStorageLogic storageLogic)
        {
            this.orderLogic = orderLogic;
            this.carLogic = carLogic;
            this.componentLogic = componentLogic;
            this.storageLogic = storageLogic;
        }

        public void CreateOrder(CreateOrderBindingModel model)
        {
            orderLogic.CreateOrUpdate(new OrderBindingModel
            {
                CarId = model.CarId,
                Count = model.Count,
                Sum = model.Sum,
                DateCreate = DateTime.Now,
                Status = OrderStatus.Принят
            });
        }

        public void TakeOrderInWork(ChangeStatusBindingModel model)
        {
            var order = orderLogic.Read(new OrderBindingModel
            {
                Id = model.OrderId
            })?[0];
            if (order == null)
            {
                throw new Exception("Не найден заказ");
            }
            if (order.Status != OrderStatus.Принят)
            {
                throw new Exception("Заказ не в статусе \"Принят\"");
            }
            // Получаем компоненты из этого заказа
            List<CarComponent> components = this.getNeededCarComponentsFromOrder(order);
            // Если они все есть на складах
            if (checkComponentsExistenceOnStorages(components) == true)
            {
                // То списваем их
                foreach (CarComponent component in components)
                {
                    this.writeOffComponentFromStorages(component);
                }
            }
            else
            {
                throw new Exception("На складе отсутствуют необходимые компоненты. Попробуйте позже.");
            }
            orderLogic.CreateOrUpdate(new OrderBindingModel
            {
                Id = order.Id,
                CarId = order.CarId,
                Count = order.Count,
                Sum = order.Sum,
                DateCreate = order.DateCreate,
                DateImplement = DateTime.Now,
                Status = OrderStatus.Выполняется
            });
        }

        /// <summary>
        /// Метод осуществляющий проверку необходимых компонентов на складах
        /// </summary>
        /// <param name="components"></param>
        /// <returns></returns>
        private bool checkComponentsExistenceOnStorages(List<CarComponent> components)
        {
            bool existAllComponents = true;
            List<StorageViewModel> storages = storageLogic.Read(null);
            // Проход по каждому компоненту, который необходим для заказа
            foreach (CarComponent component in components)
            {
                // Если такого компонента меньше чем требуется то выходим из цикла и метода с false
                if (this.getComponentCountOnStorages(component) < component.Count)
                {
                    existAllComponents = false;
                    break;
                }
            }
            return existAllComponents;
        }

        /// <summary>
        /// Метод вытаскивающий компоненты из заказа, которые необходимо списать
        /// </summary>
        /// <param name="order"></param>
        /// <returns></returns>
        private List<CarComponent> getNeededCarComponentsFromOrder(OrderViewModel order)
        {
            Dictionary<int, (string, int)> dictComponents = carLogic.Read(new CarBindingModel
            {
                Id = order.CarId
            }
            )[0].CarComponents;
            return dictComponents.Select(rec => new CarComponent
            {
                ComponentId = rec.Key,
                Count = rec.Value.Item2
            }).ToList();
        }

        /// <summary>
        /// Метод возвращающий общее количество компонента на всех складах
        /// </summary>
        /// <param name="component"></param>
        /// <returns></returns>
        private int getComponentCountOnStorages(CarComponent component)
        {
            int componentCount = 0;
            List<StorageViewModel> storages = storageLogic.Read(null);
            foreach (StorageViewModel storage in storages)
            {
                int tempCount = this.getStorageComponents(storage)
                    .Where(stc => stc.ComponentId == component.ComponentId)
                    .Select(stc => stc.Count)
                    .FirstOrDefault();

                componentCount += tempCount;
            }
            return componentCount;
        }

        /// <summary>
        /// Метод который списывает компонент со склада(ов)
        /// </summary>
        /// <param name="component"></param>
        private void writeOffComponentFromStorages(CarComponent component)
        {
            List<StorageViewModel> storages = storageLogic.Read(null);
            int toWriteOff = component.Count;
            for (int i = 0; i < storages.Count; i++)
            {
                StorageViewModel storage = storages.ElementAt(i);
                List<StorageComponent> storageComponents = this.getStorageComponents(storage);
                StorageComponent storageComponent = storageComponents
                    .Where(stc => stc.ComponentId == component.ComponentId)
                    .FirstOrDefault();
                if (storageComponent != null)
                {
                    if (storageComponent.Count <= toWriteOff)
                    {
                        toWriteOff -= storageComponent.Count;
                        storageComponent.Count = 0;
                    }
                    else
                    {
                        storageComponent.Count -= toWriteOff;
                    }
                }
                Dictionary<int, (string, int)> storageComponentsDict = new Dictionary<int, (string, int)>();
                foreach (StorageComponent storageComp in storageComponents)
                {
                    string scName = componentLogic.Read(null)
                        .Where(sc => sc.Id == storageComp.ComponentId)
                        .Select(sc => sc.ComponentName)
                        .FirstOrDefault();
                    storageComponentsDict.Add(
                        storageComp.ComponentId,
                        (scName, storageComp.Count)
                    );
                }
                storageLogic.CreateOrUpdate(new StorageBindingModel
                {
                    Id = storage.Id,
                    StorageName = storage.StorageName,
                    StorageComponents = storageComponentsDict
                });
            }
        }

        /// <summary>
        /// Метод вытаскивающий все компоненты на складе
        /// </summary>
        /// <param name="storage"></param>
        /// <returns></returns>
        private List<StorageComponent> getStorageComponents(StorageViewModel storage)
        {
            return storage.StorageComponents.Select(stc => new StorageComponent
            {
                ComponentId = stc.Key,
                Count = stc.Value.Item2
            }).ToList();
        }

        public void FinishOrder(ChangeStatusBindingModel model)
        {
            var order = orderLogic.Read(new OrderBindingModel
            {
                Id = model.OrderId
            })?[0];
            if (order == null)
            {
                throw new Exception("Не найден заказ");
            }
            if (order.Status != OrderStatus.Выполняется)
            {
                throw new Exception("Заказ не в статусе \"Выполняется\"");
            }
            orderLogic.CreateOrUpdate(new OrderBindingModel
            {
                Id = order.Id,
                CarId = order.CarId,
                Count = order.Count,
                Sum = order.Sum,
                DateCreate = order.DateCreate,
                DateImplement = order.DateImplement,
                Status = OrderStatus.Готов
            });
        }

        public void PayOrder(ChangeStatusBindingModel model)
        {
            var order = orderLogic.Read(new OrderBindingModel
            {
                Id = model.OrderId
            })?[0];
            if (order == null)
            {
                throw new Exception("Не найден заказ");
            }
            if (order.Status != OrderStatus.Готов)
            {
                throw new Exception("Заказ не в статусе \"Готов\"");
            }
            orderLogic.CreateOrUpdate(new OrderBindingModel
            {
                Id = order.Id,
                CarId = order.CarId,
                Count = order.Count,
                Sum = order.Sum,
                DateCreate = order.DateCreate,
                DateImplement = order.DateImplement,
                Status = OrderStatus.Оплачен
            });
        }
    }
}