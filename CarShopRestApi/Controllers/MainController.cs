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
        private readonly MainLogic _main;
        public MainController(IOrderLogic order, ICarLogic Car, MainLogic main)
        {
            _order = order;
            _Car = Car;
            _main = main;
        }

        [HttpGet]
        public List<CarViewModel> GetCarList() => _Car.Read(null);

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