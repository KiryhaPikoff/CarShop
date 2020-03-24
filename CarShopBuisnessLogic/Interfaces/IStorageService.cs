using CarShopBuisnessLogic.ViewModels;

namespace CarShopBuisnessLogic.Interfaces
{
    public interface IStorageService
    {
        void WriteOffComponentsFromStorage(OrderViewModel order);
    }
}
