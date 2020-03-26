using CarShopBuisnessLogic.BindingModels;
using CarShopBuisnessLogic.Enums;
using CarShopBuisnessLogic.Interfaces;
using CarShopBuisnessLogic.ViewModels;
using CarShopDatabaseImplement.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CarShopDatabaseImplement.Implements
{
    public class OrderLogic : IOrderLogic
    {
        public void CreateOrUpdate(OrderBindingModel model)
        {
            using (var context = new CarShopDatabase())
            {
                Order order;
                if (model.Id.HasValue)
                {
                    order = context.Orders.FirstOrDefault(rec => rec.Id == model.Id);
                    if (order == null)
                    {
                        throw new Exception("Элемент не найден");
                    }
                }
                else
                {
                    order = new Order
                    {
                        CarId = model.CarId,
                        Count = model.Count,
                        DateCreate = model.DateCreate,
                        DateImplement = model.DateImplement,
                        Status = OrderStatus.Принят,
                        Sum = model.Sum
                    };
                    context.Orders.Add(order);
                    context.SaveChanges();
                    return;
                }
                order.CarId = model.CarId;
                order.Count = model.Count;
                order.DateCreate = model.DateCreate;
                order.DateImplement = model.DateImplement;
                order.Status = model.Status;
                order.Sum = model.Sum;

                context.SaveChanges();
            }
        }

        public void Delete(OrderBindingModel model)
        {
            using (var context = new CarShopDatabase())
            {
                Order element = context.Orders.FirstOrDefault(rec => rec.Id == model.Id);
                if (element != null)
                {
                    context.Orders.Remove(element);
                    context.SaveChanges();
                }
                else
                {
                    throw new Exception("Элемент не найден");
                }
            }
        }

        public List<OrderViewModel> Read(OrderBindingModel model)
        {
            using (var context = new CarShopDatabase())
            {
                var orders = context.Orders
                .Where(rec => model == null || rec.Id == model.Id);
                if (model != null && model.DateFrom != null && model.DateTo != null)
                {
                    orders.Where(rec => rec.DateCreate >= model.DateFrom && rec.DateCreate <= model.DateTo);
                }
                return context.Orders
                .Select(rec => new OrderViewModel
                {
                    Id = rec.Id,
                    CarId = rec.CarId,
                    CarName = context.Cars.FirstOrDefault(car => car.Id == rec.CarId).CarName,
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
}
