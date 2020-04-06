using CarShopBuisnessLogic.BindingModels;
using CarShopBuisnessLogic.Interfaces;
using CarShopBuisnessLogic.ViewModels;
using CarShopListImplement.Models;
using System;
using System.Collections.Generic;

namespace CarShopListImplement.Implements
{
    public class OrderLogic : IOrderLogic
    {
        private readonly DataListSingleton source;
        public OrderLogic()
        {
            source = DataListSingleton.GetInstance();
        }

        public void CreateOrUpdate(OrderBindingModel model)
        {
            Order tempOrder = model.Id.HasValue ? null : new Order
            {
                Id = 1
            };
            foreach (var component in source.Orders)
            {
                if (!model.Id.HasValue && component.Id >= tempOrder.Id)
                {
                    tempOrder.Id = component.Id + 1;
                }
                else if (model.Id.HasValue && component.Id == model.Id)
                {
                    tempOrder = component;
                }
            }

            if (model.Id.HasValue)
            {
                if (tempOrder == null)
                {
                    throw new Exception("Элемент не найден");
                }
                CreateModel(model, tempOrder);
            }
            else
            {
                source.Orders.Add(CreateModel(model, tempOrder));
            }
        }

        public void Delete(OrderBindingModel model)
        {
            for (int i = 0; i < source.Orders.Count; ++i)
            {
                if (source.Orders[i].Id == model.Id)
                {
                    source.Orders.RemoveAt(i--);
                    return;
                }
            }
            throw new Exception("Элемент не найден");
        }

        public List<OrderViewModel> Read(OrderBindingModel model)
        {
            List<OrderViewModel> result = new List<OrderViewModel>();
            foreach (var order in source.Orders)
            {
                if (model != null)
                {
                    if (order.Id == model.Id)
                    {
                        if (model.DateFrom != null && model.DateTo != null)
                        {
                            if (order.DateCreate >= model.DateFrom && order.DateCreate <= model.DateTo)
                            {
                                result.Add(CreateViewModel(order));
                            }
                            continue;
                        }
                        result.Add(CreateViewModel(order));
                        break;
                    }
                    continue;
                }
                result.Add(CreateViewModel(order));
            }
            return result;
        }

        private Order CreateModel(OrderBindingModel model, Order order)
        {
            order.CarId = model.CarId;
            order.ClientId = model.ClientId;
            order.Count = model.Count;
            order.DateCreate = model.DateCreate;
            order.DateImplement = model.DateImplement;
            order.Status = model.Status;
            order.Sum = model.Sum;
            return order;
        }

        private OrderViewModel CreateViewModel(Order order)
        {
            string carName = "";
            for (int i = 0; i < source.Cars.Count; i++)
            {
                if (source.Cars[i].Id == order.CarId)
                {
                    carName = source.Cars[i].CarName;
                    break;
                }
            }

            string clientFio = "";

            for (int i = 0; i < source.Clients.Count; i++)
            {
                if (source.Clients[i].Id == order.ClientId)
                {
                    clientFio = source.Clients[i].Fio;
                    break;
                }
            }

            return new OrderViewModel
            {
                Id = order.Id,
                CarId = order.CarId,
                ClientId = order.ClientId,
                ClientFIO = clientFio,
                CarName = carName,
                Count = order.Count,
                DateCreate = order.DateCreate,
                DateImplement = order.DateImplement,
                Status = order.Status,
                Sum = order.Sum
            };
        }
    }
}
