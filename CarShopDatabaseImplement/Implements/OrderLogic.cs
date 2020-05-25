using CarShopBuisnessLogic.BindingModels;
using CarShopBuisnessLogic.Enums;
using CarShopBuisnessLogic.Interfaces;
using CarShopBuisnessLogic.ViewModels;
using CarShopDatabaseImplement.Models;
using Microsoft.EntityFrameworkCore;
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
                        ClientId = model.ClientId,
                        ImplementerId = model.ImplementerId,
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
                order.ImplementerId = model.ImplementerId;
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
                return context.Orders
                .Where(rec => model == null ||
                (model.Id != null && rec.Id == model.Id) ||
                (model.ClientId == rec.ClientId) ||
                (model.DateFrom != null && model.DateTo != null && rec.DateCreate >= model.DateFrom && rec.DateCreate <= model.DateTo) ||
                (model.FreeOrders.HasValue && model.FreeOrders.Value && !rec.ImplementerId.HasValue) ||
                (model.ImplementerId.HasValue && rec.ImplementerId == model.ImplementerId && rec.Status == OrderStatus.Выполняется) ||
                (model.NotEnoughMaterialsOrders.HasValue && model.NotEnoughMaterialsOrders.Value && rec.Status == OrderStatus.Треубются_материалы))
                .Include(rec => rec.Car)
                .Include(rec => rec.Client)
                .Include(rec => rec.Implementer)
                .Select(rec => new OrderViewModel
                {
                    Id = rec.Id,
                    CarId = rec.CarId,
                    CarName = rec.Car.CarName,
                    ClientId = rec.ClientId,
                    ClientFIO = rec.Client.Fio,
                    ImplementerId = rec.ImplementerId,
                    ImplementerFIO = rec.Implementer.ImplementerFIO,
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
