using CarShopBuisnessLogic;
using CarShopBuisnessLogic.BindingModels;
using CarShopBuisnessLogic.Interfaces;
using CarShopBuisnessLogic.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace CarShopRestApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class MainController : ControllerBase
    {
        private readonly IOrderLogic _order;
        private readonly ICarLogic _Car;
        private readonly IComponentLogic _componentLogic;
        private readonly MainLogic _main;

        public MainController(IOrderLogic order, ICarLogic Car, MainLogic main, IComponentLogic componentLogic)
        {
            _order = order;
            _Car = Car;
            _main = main;
            _componentLogic = componentLogic;
        }

        [HttpGet]
        public List<CarViewModel> GetCarList() => _Car.Read(null);

        [HttpGet]
        public List<ComponentViewModel> GetComponentList() => _componentLogic.Read(null);

        [HttpGet]
        public CarViewModel GetCar(int CarId) => _Car.Read(new CarBindingModel
        {
            Id = CarId
        })?[0];

        [HttpGet]
        public List<OrderViewModel> GetOrders(int clientId) => _order.Read(new OrderBindingModel
        {
            ClientId = clientId
        });

        [HttpPost]
        public void CreateOrder(CreateOrderBindingModel model) => _main.CreateOrder(model);
    }
}