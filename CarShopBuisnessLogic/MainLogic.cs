using CarShopBuisnessLogic.BindingModels;
using CarShopBuisnessLogic.Enums;
using CarShopBuisnessLogic.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace CarShopBuisnessLogic
{
    public class MainLogic
    {
        private readonly IOrderLogic orderLogic;
        private readonly IStorageLogic storageLogic;
        private readonly IComponentLogic componentLogic;

        public MainLogic(IOrderLogic orderLogic, IStorageLogic storageLogic, IComponentLogic componentLogic)
        {
            this.orderLogic = orderLogic;
            this.storageLogic = storageLogic;
            this.componentLogic = componentLogic;
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
            else {
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
    }
}