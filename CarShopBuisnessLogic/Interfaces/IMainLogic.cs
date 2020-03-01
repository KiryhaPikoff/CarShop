using CarShopBuisnessLogic.BindingModels;
using CarShopBuisnessLogic.ViewModels;
using System.Collections.Generic;

namespace CarShopBuisnessLogic.Interfaces
{
    public interface IMainLogic
    {
        void CreateOrder(CreateOrderBindingModel model);
        void TakeOrderInWork(ChangeStatusBindingModel model);
        void FinishOrder(ChangeStatusBindingModel model);
        void PayOrder(ChangeStatusBindingModel model);
    }
}
