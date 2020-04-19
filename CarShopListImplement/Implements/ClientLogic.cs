using CarShopBuisnessLogic.BindingModels;
using CarShopBuisnessLogic.Interfaces;
using CarShopBuisnessLogic.ViewModels;
using CarShopListImplement.Models;
using System;
using System.Collections.Generic;

namespace CarShopListImplement.Implements
{
    public class ClientLogic : IClientLogic
    {
        private readonly DataListSingleton source;
        public ClientLogic()
        {
            source = DataListSingleton.GetInstance();
        }

        public void CreateOrUpdate(ClientBindingModel model)
        {
            Client tempClient = model.Id.HasValue ? null : new Client
            {
                Id = 1
            };
            foreach (var client in source.Clients)
            {
                if (client.Login == model.Login && client.Id != model.Id)
                {
                    throw new Exception("Уже есть пользователь с таким логином");
                }
                if (!model.Id.HasValue && client.Id >= tempClient.Id)
                {
                    tempClient.Id = client.Id + 1;
                }
                else if (model.Id.HasValue && client.Id == model.Id)
                {
                    tempClient = client;
                }
            }

            if (model.Id.HasValue)
            {
                if (tempClient == null)
                {
                    throw new Exception("Элемент не найден");
                }
                CreateModel(model, tempClient);
            }
            else
            {
                source.Clients.Add(CreateModel(model, tempClient));
            }
        }

        public void Delete(ClientBindingModel model)
        {
            for (int i = 0; i < source.Clients.Count; ++i)
            {
                if (source.Clients[i].Id == model.Id.Value)
                {
                    source.Clients.RemoveAt(i);
                    return;
                }
            }
            throw new Exception("Элемент не найден");
        }

        public List<ClientViewModel> Read(ClientBindingModel model)
        {
            List<ClientViewModel> result = new List<ClientViewModel>();
            foreach (var client in source.Clients)
            {
                if (model != null)
                {
                    if (client.Id == model.Id || (client.Login == model.Login && client.Password == model.Password))
                    {
                        result.Add(CreateViewModel(client));
                        break;
                    }
                    continue;
                }
                result.Add(CreateViewModel(client));
            }
            return result;
        }

        private Client CreateModel(ClientBindingModel model, Client client)
        {
            client.Fio = model.ClientFio;
            client.Login = model.Login;
            client.Password = model.Password;
            return client;
        }

        private ClientViewModel CreateViewModel(Client client)
        {
            return new ClientViewModel
            {
                Id = client.Id,
                ClientFio = client.Fio,
                Login = client.Login,
                Password = client.Password
            };
        }
    }
}
