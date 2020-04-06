using CarShopBuisnessLogic.BindingModels;
using CarShopBuisnessLogic.Interfaces;
using CarShopBuisnessLogic.ViewModels;
using CarShopDatabaseImplement.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CarShopDatabaseImplement.Implements
{
    public class ClientLogic : IClientLogic
    {
        public void CreateOrUpdate(ClientBindingModel model)
        {
            using (var context = new CarShopDatabase())
            {
                Client element = context.Clients.FirstOrDefault(rec => rec.Fio == model.ClientFio && rec.Id != model.Id);
                if (element != null)
                {
                    throw new Exception("Уже есть пользователь с таким логином");
                }
                if (model.Id.HasValue)
                {
                    element = context.Clients.FirstOrDefault(rec => rec.Id == model.Id);
                    if (element == null)
                    {
                        throw new Exception("Элемент не найден");
                    }
                }
                else
                {
                    element = new Client();
                    context.Clients.Add(element);
                }
                element.Fio = model.ClientFio;
                element.Login = model.Login;
                element.Password = model.Password;
                context.SaveChanges();
            }
        }

        public void Delete(ClientBindingModel model)
        {
            using (var context = new CarShopDatabase())
            {
                Client element = context.Clients.FirstOrDefault(rec => rec.Id == model.Id);
                if (element != null)
                {
                    context.Clients.Remove(element);
                    context.SaveChanges();
                }
                else
                {
                    throw new Exception("Элемент не найден");
                }
            }
        }

        public List<ClientViewModel> Read(ClientBindingModel model)
        {
            using (var context = new CarShopDatabase())
            {
                return context.Clients
                .Where(rec => (model == null || rec.Id == model.Id) ||
                (model.Login == rec.Login && model.Password == rec.Password))
                .Select(rec => new ClientViewModel
                {
                    Id = rec.Id,
                    ClientFio = rec.Fio,
                    Login = rec.Login,
                    Password = rec.Password
                })
                .ToList();
            }
        }
    }
}
