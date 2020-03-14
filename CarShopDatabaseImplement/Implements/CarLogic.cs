using CarShopBuisnessLogic.BindingModels;
using CarShopBuisnessLogic.Interfaces;
using CarShopBuisnessLogic.ViewModels;
using CarShopDatabaseImplement.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CarShopDatabaseImplement.Implements
{
    public class CarLogic : ICarLogic
    {
        public void CreateOrUpdate(CarBindingModel model)
        {
            using (var context = new CarShopDatabase())
            {
                using (var transaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        Car element = context.Cars.FirstOrDefault(rec => rec.CarName == model.CarName && rec.Id != model.Id);
                        if (element != null)
                        {
                            throw new Exception("Уже есть изделие с таким названием");
                        }
                        if (model.Id.HasValue)
                        {
                            element = context.Cars.FirstOrDefault(rec => rec.Id == model.Id);
                            if (element == null)
                            {
                                throw new Exception("Элемент не найден");
                            }
                        }
                        else
                        {
                            element = new Car();
                            context.Cars.Add(element);
                        }
                        element.CarName = model.CarName;
                        element.Price = model.Price;
                        context.SaveChanges();
                        if (model.Id.HasValue)
                        {
                            var CarComponents = context.CarComponents.Where(rec => rec.CarId == model.Id.Value).ToList();
                            // удалили те, которых нет в модели
                            context.CarComponents.RemoveRange(CarComponents.Where(rec => !model.CarComponents.ContainsKey(rec.ComponentId)).ToList());
                            context.SaveChanges();
                            // обновили количество у существующих записей
                            foreach (var updateComponent in CarComponents)
                            {
                                updateComponent.Count = model.CarComponents[updateComponent.ComponentId].Item2;
                                model.CarComponents.Remove(updateComponent.ComponentId);
                            }
                            context.SaveChanges();
                        }
                        // добавили новые
                        foreach (var pc in model.CarComponents)
                        {
                            context.CarComponents.Add(new CarComponent
                            {
                                CarId = element.Id,
                                ComponentId = pc.Key,
                                Count = pc.Value.Item2
                            });
                            context.SaveChanges();
                        }
                        transaction.Commit();
                    }
                    catch (Exception)
                    {
                        transaction.Rollback();
                        throw;
                    }
                }
            }
        }
        public void Delete(CarBindingModel model)
        {
            using (var context = new CarShopDatabase())
            {
                using (var transaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        // удаяем записи по компонентам при удалении изделия
                        context.CarComponents.RemoveRange(context.CarComponents.Where(rec =>
                        rec.CarId == model.Id));
                        Car element = context.Cars.FirstOrDefault(rec => rec.Id == model.Id);
                        if (element != null)
                        {
                            context.Cars.Remove(element);
                            context.SaveChanges();
                        }
                        else
                        {
                            throw new Exception("Элемент не найден");
                        }
                        transaction.Commit();
                    }
                    catch (Exception)
                    {
                        transaction.Rollback();
                        throw;
                    }
                }
            }
        }
        public List<CarViewModel> Read(CarBindingModel model)
        {
            using (var context = new CarShopDatabase())
            {
                return context.Cars
                .Where(rec => model == null || rec.Id == model.Id)
                .ToList()
               .Select(rec => new CarViewModel
               {
                   Id = rec.Id,
                   CarName = rec.CarName,
                   Price = rec.Price,
                   CarComponents = context.CarComponents
                .Include(recPC => recPC.Component)
               .Where(recPC => recPC.CarId == rec.Id)
               .ToDictionary(recPC => recPC.ComponentId, recPC =>
                (recPC.Component?.ComponentName, recPC.Count))
               })
               .ToList();
            }
        }
    }
}
