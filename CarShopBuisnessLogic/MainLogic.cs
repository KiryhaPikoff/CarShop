using CarShopBuisnessLogic.BindingModels;
using CarShopBuisnessLogic.Enums;
using CarShopBuisnessLogic.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CarShopBuisnessLogic
{
    public class MainLogic
    {
        private readonly IOrderLogic orderLogic;
        private readonly object locker = new object();
        private readonly IStorageLogic storageLogic;
        private readonly ICarLogic carLogic;

        public MainLogic(IOrderLogic orderLogic, IStorageLogic storageLogic, ICarLogic carLogic)
        {
            this.orderLogic = orderLogic;
            this.storageLogic = storageLogic;
            this.carLogic = carLogic;
        }
        public void CreateOrder(CreateOrderBindingModel model)
        {
            orderLogic.CreateOrUpdate(new OrderBindingModel
            {
                ClientId = model.ClientId,
                CarId = model.CarId,
                Count = model.Count,
                Sum = model.Sum,
                DateCreate = DateTime.Now,
                Status = OrderStatus.Принят
            });
        }

        public void TakeOrderInWork(ChangeStatusBindingModel model)
        {
            lock (locker)
            {
                var order = orderLogic.Read(new OrderBindingModel
                {
                    Id = model.OrderId
                })?[0];
                if (order == null)
                {
                    throw new Exception("Не найден заказ");
                }
                if (order.Status != OrderStatus.Принят && order.Status != OrderStatus.Треубются_материалы)
                {
                    throw new Exception("Заказ не в статусе \"Принят\" или \"Требуются материалы\"");
                }
                if (order.ImplementerId.HasValue)
                {
                    throw new Exception("У заказа уже есть исполнитель");
                }

                List<ComponentCountBindingModel> components = carLogic.Read(new CarBindingModel
                {
                    Id = order.CarId
                })[0].CarComponents
                    .Select(x => new ComponentCountBindingModel
                    {
                        ComponentId = x.Key,
                    // Кол-во компонентов умножается на кол-во машин.
                    Count = x.Value.Item2 * order.Count
                    })
                    .ToList();

                var orderModel = new OrderBindingModel
                {
                    Id = order.Id,
                    ClientId = order.ClientId,
                    CarId = order.CarId,
                    Count = order.Count,
                    Sum = order.Sum,
                    DateCreate = order.DateCreate
                };

                try
                {
                    storageLogic.DiscountComponents(components);
                    orderModel.DateImplement = DateTime.Now;
                    orderModel.Status = OrderStatus.Выполняется;
                    orderModel.ImplementerId = model.ImplementerId;
                }
                catch
                {
                    orderModel.Status = OrderStatus.Треубются_материалы;
                }

                orderLogic.CreateOrUpdate(orderModel);
            }
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
                ImplementerId = model.ImplementerId,
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
                ImplementerId = model.ImplementerId,
                Count = order.Count,
                Sum = order.Sum,
                DateCreate = order.DateCreate,
                DateImplement = order.DateImplement,
                Status = OrderStatus.Оплачен
            });
        }

        public void addComponentOnStorage(AddComponentBindingModel addComponentBindingModel)
        {
            this.storageLogic.AddComponent(addComponentBindingModel);
        }
    }
}