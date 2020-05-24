using CarShopBuisnessLogic.BindingModels;
using CarShopBuisnessLogic.Interfaces;
using CarShopBuisnessLogic.ViewModels;
using CarShopListImplement.Models;
using System;
using System.Collections.Generic;

namespace CarShopListImplement.Implements
{
    public class MessageInfoLogic : IMessageInfoLogic
    {
        private readonly DataListSingleton source;
        public MessageInfoLogic()
        {
            source = DataListSingleton.GetInstance();
        }

        public void Create(MessageInfoBindingModel model)
        {
            foreach (var messageInfo in source.MessageInfoes)
            {
                if (messageInfo.MessageId == model.MessageId)
                {
                    throw new Exception("Уже есть письмо с таким идентификатором");
                }
            }
            int? clientId = null;
            foreach (var client in source.Clients)
            {
                if (client.Login == model.FromMailAddress)
                {
                    clientId = client.Id;
                }
            }
            source.MessageInfoes.Add(new MessageInfo
            {
                MessageId = model.MessageId,
                ClientId = clientId,
                SenderName = model.FromMailAddress,
                DateDelivery = model.DateDelivery,
                Subject = model.Subject,
                Body = model.Body
            });
        }

        public List<MessageInfoViewModel> Read(MessageInfoBindingModel model)
        {
            List<MessageInfoViewModel> result = new List<MessageInfoViewModel>();
            foreach (var messageInfo in source.MessageInfoes)
            {
                if (messageInfo != null)
                {
                    if (messageInfo.ClientId == model.ClientId)
                    {
                        result.Add(CreateViewModel(messageInfo));
                        break;
                    }
                    continue;
                }
                result.Add(CreateViewModel(messageInfo));
            }
            return result;
        }

        private MessageInfoViewModel CreateViewModel(MessageInfo messageInfo)
        {
            return new MessageInfoViewModel
            {
                MessageId = messageInfo.MessageId,
                Body = messageInfo.Body,
                DateDelivery = messageInfo.DateDelivery,
                SenderName = messageInfo.SenderName,
                Subject = messageInfo.Subject
            };
        }
    }
}
