using CarShopBuisnessLogic.BindingModels;
using CarShopBuisnessLogic.Interfaces;
using CarShopBuisnessLogic.ViewModels;
using CarShopFileImplement.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CarShopFileImplement.Implements
{
    public class ClientLogic : IClientLogic
    {
        private readonly FileDataListSingleton source;

        public ClientLogic()
        {
            source = FileDataListSingleton.GetInstance();
        }

        public void CreateOrUpdate(ClientBindingModel model)
        {
            Client element = source.Clients.FirstOrDefault(rec => rec.Fio == model.ClientFio && rec.Id != model.Id);
            if (element != null)
            {
                throw new Exception("Уже есть пользователь с таким логином");
            }
            if (model.Id.HasValue)
            {
                element = source.Clients.FirstOrDefault(rec => rec.Id == model.Id);
                if (element == null)
                {
                    throw new Exception("Элемент не найден");
                }
            }
            else
            {
                int maxId = source.Clients.Count > 0 ? source.Clients.Max(rec => rec.Id) : 0;
                element = new Client { Id = maxId + 1 };
                source.Clients.Add(element);
            }
            element.Fio = model.ClientFio;
            element.Login = model.Login;
            element.Password = model.Password;
        }

        public void Delete(ClientBindingModel model)
        {
            Client element = source.Clients.FirstOrDefault(rec => rec.Id == model.Id);
            if (element != null)
            {
                source.Clients.Remove(element);
            }
            else
            {
                throw new Exception("Элемент не найден");
            }
        }

        public List<ClientViewModel> Read(ClientBindingModel model)
        {
            return source.Clients
             .Where(rec => model == null ||
                (model.Id != null && rec.Id == model.Id) ||
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
