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
    public class OrderLogic : IOrderLogic
    {
        private readonly FileDataListSingleton source;

        public OrderLogic()
        {
            source = FileDataListSingleton.GetInstance();
        }

        public void CreateOrUpdate(OrderBindingModel model)
        {
            Order order;
            if (model.Id.HasValue)
            {
                order = source.Orders.FirstOrDefault(rec => rec.Id == model.Id);
                if (order == null)
                {
                    throw new Exception("Элемент не найден");
                }
            }
            else
            {
                int maxId = source.Orders.Count > 0 ? source.Orders.Max(rec => rec.Id) : 0;
                order = new Order
                {
                    Id = maxId + 1,
                    CarId = model.CarId,
                    Count = model.Count,
                    DateCreate = model.DateCreate,
                    DateImplement = model.DateImplement,
                    Status = OrderStatus.Принят,
                    Sum = model.Sum
                };
                source.Orders.Add(order);
                return;
            }
            order.CarId = model.CarId;
            order.ClientId = model.ClientId;
            order.Count = model.Count;
            order.DateCreate = model.DateCreate;
            order.DateImplement = model.DateImplement;
            order.Status = model.Status;
            order.Sum = model.Sum;
        }

        public void Delete(OrderBindingModel model)
        {
            Order order = source.Orders.FirstOrDefault(rec => rec.Id == model.Id);
            if (order != null)
            {
                source.Orders.Remove(order);
            }
            else
            {
                throw new Exception("Элемент не найден");
            }
        }

        public List<OrderViewModel> Read(OrderBindingModel model)
        {
            return source.Orders
            .Where(rec => model == null ||
                (model.Id != null && rec.Id == model.Id) ||
                (model.DateFrom != null && model.DateTo != null && rec.DateCreate >= model.DateFrom && rec.DateCreate <= model.DateTo) ||
                (rec.ClientId == model.ClientId))
            .Select(rec => new OrderViewModel
            {
                Id = rec.Id,
                CarId = rec.CarId,
                CarName = source.Cars.FirstOrDefault(car => car.Id == rec.CarId).CarName,
                ClientFIO = source.Clients.FirstOrDefault((cl) => cl.Id == rec.ClientId).Fio,
                Count = rec.Count,
                DateCreate = rec.DateCreate,
                DateImplement = rec.DateImplement,
                Status = rec.Status,
                Sum = rec.Sum
            })
            .ToList();
        }
    }
}
