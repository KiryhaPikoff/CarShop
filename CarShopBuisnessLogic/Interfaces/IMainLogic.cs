using CarShopBuisnessLogic.BindingModels;

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
