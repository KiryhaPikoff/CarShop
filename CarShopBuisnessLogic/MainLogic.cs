using CarShopBuisnessLogic.BindingModels;
using CarShopBuisnessLogic.Enums;
using CarShopBuisnessLogic.Interfaces;
using CarShopBuisnessLogic.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CarShopBuisnessLogic
{
    public class MainLogic
    {
        private readonly IOrderLogic orderLogic;
        private readonly IStorageLogic storageLogic;
        private readonly IComponentLogic componentLogic;
        private readonly ICarLogic carLogic;

        public MainLogic(IOrderLogic orderLogic, IStorageLogic storageLogic, IComponentLogic componentLogic, ICarLogic carLogic)
        {
            this.orderLogic = orderLogic;
            this.storageLogic = storageLogic;
            this.componentLogic = componentLogic;
            this.carLogic = carLogic;
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

            this.WriteOffComponentsFromStorage(order);

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

        // В этом методе логика формирования списка компонентов склада, при добавлении на него нового.
        public void addComponentOnStorage(int storageId, int componentId, int count)
        {
            Dictionary<int, (string, int)> components = this.storageLogic.Read(new StorageBindingModel
            {
                Id = storageId
            })[0].StorageComponents;

            // Если такой компонент уже хранился на складе, то увеличиваем его количество
            if (components.ContainsKey(componentId))
            {
                string name = components[componentId].Item1;
                int prevCount = components[componentId].Item2;
                components.Remove(componentId);
                components.Add(componentId, (name, prevCount + count));
            }
            else
            {
                // если нет - добавляем его
                string name = this.componentLogic.Read(new ComponentBindingModel
                {
                    Id = componentId
                })[0].ComponentName;

                components.Add(componentId, (name, count));
            }

            // сохраняем новое состояние компонентов склада
            storageLogic.updateComponentsOnStorage(storageId, components);
        }

        private void WriteOffComponentsFromStorage(OrderViewModel order)
        {
            // Получаем компоненты из этого заказа
            Dictionary<int, (string, int)> components = this.getNeededCarComponentsFromOrder(order);
            // Если они все есть на складах
            if (checkComponentsExistenceOnStorages(components) == true)
            {
                // То списваем их
                foreach (KeyValuePair<int, (string, int)> component in components)
                {
                    this.writeOffComponentFromStorages(component);
                }
            }
            else
            {
                throw new Exception("На складе отсутствуют необходимые компоненты. Попробуйте позже.");
            }
        }

        /// <summary>
        /// Метод осуществляющий проверку необходимых компонентов на складах
        /// </summary>
        /// <param name="components"></param>
        /// <returns></returns>
        private bool checkComponentsExistenceOnStorages(Dictionary<int, (string, int)> components)
        {
            bool existAllComponents = true;
            List<StorageViewModel> storages = storageLogic.Read(null);
            // Проход по каждому компоненту, который необходим для заказа
            foreach (KeyValuePair<int, (string, int)> component in components)
            {
                // Если такого компонента меньше чем требуется то выходим из цикла и метода с false
                if (this.getComponentCountOnStorages(component) < component.Value.Item2)
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
        private Dictionary<int, (string, int)> getNeededCarComponentsFromOrder(OrderViewModel order)
        {
            return carLogic.Read(new CarBindingModel
            {
                Id = order.CarId
            }
            )[0].CarComponents // количество каждого компонента умножается на количество машин в заказе
            .ToDictionary(rec => rec.Key, rec => (rec.Value.Item1, rec.Value.Item2 * order.Count));
        }

        /// <summary>
        /// Метод возвращающий общее количество компонента на всех складах
        /// </summary>
        /// <param name="component"></param>
        /// <returns></returns>
        private int getComponentCountOnStorages(KeyValuePair<int, (string, int)> component)
        {
            int componentCount = 0;
            List<StorageViewModel> storages = storageLogic.Read(null);
            foreach (StorageViewModel storage in storages)
            {
                int tempCount = storage.StorageComponents
                    .Where(stc => stc.Key == component.Key)
                    .Select(stc => stc.Value.Item2)
                    .FirstOrDefault();

                componentCount += tempCount;
            }
            return componentCount;
        }

        /// <summary>
        /// Метод который списывает компонент со склада(ов)
        /// </summary>
        /// <param name="component"></param>
        private void writeOffComponentFromStorages(KeyValuePair<int, (string, int)> component)
        {
            List<StorageViewModel> storages = storageLogic.Read(null);
            int toWriteOff = component.Value.Item2;
            for (int i = 0; i < storages.Count; i++)
            {
                StorageViewModel storage = storages.ElementAt(i);
                Dictionary<int, (string, int)> storageComponents = storage.StorageComponents;
                KeyValuePair<int, (string, int)> storageComponent = storageComponents
                    .Where(stc => stc.Key == component.Key)
                    .FirstOrDefault();
                Dictionary<int, (string, int)> storageComponentsDict = new Dictionary<int, (string, int)>();
                if (storageComponent.Key == component.Key)
                {
                    if (storageComponent.Value.Item2 <= toWriteOff)
                    {
                        toWriteOff -= storageComponent.Value.Item2;
                        storageComponent = new KeyValuePair<int, (string, int)>(storageComponent.Key, (storageComponent.Value.Item1, 0));
                    }
                    else
                    {
                        storageComponent = new KeyValuePair<int, (string, int)>(storageComponent.Key, (storageComponent.Value.Item1, storageComponent.Value.Item2 - toWriteOff));
                    }
                    storageComponents.Remove(storageComponent.Key);
                    storageComponents.Add(storageComponent.Key, (storageComponent.Value.Item1, storageComponent.Value.Item2));
                }
                storageLogic.updateComponentsOnStorage(storage.Id, storageComponents);
            }
        }
    }
}