using CarShopBuisnessLogic.BindingModels;
using CarShopBuisnessLogic.ViewModels;
using System.Collections.Generic;

namespace CarShopBuisnessLogic.Interfaces
{
    public interface ICarLogic
    {
        List<CarViewModel> Read(CarBindingModel model);
        void CreateOrUpdate(CarBindingModel model);
        void Delete(CarBindingModel model);
    }
}