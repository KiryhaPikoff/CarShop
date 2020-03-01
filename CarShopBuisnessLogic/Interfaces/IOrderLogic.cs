﻿using CarShopBuisnessLogic.BindingModels;
using CarShopBuisnessLogic.ViewModels;
using System.Collections.Generic;
namespace AbstractShopBusinessLogic.Interfaces
{
    public interface IOrderLogic
    {
        List<OrderViewModel> Read(OrderBindingModel model);
        void CreateOrUpdate(OrderBindingModel model);
        void Delete(OrderBindingModel model);
    }
}