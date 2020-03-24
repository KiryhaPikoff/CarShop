using CarShopBuisnessLogic.Enums;
using CarShopFileImplement.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Linq;

namespace CarShopFileImplement
{
    class FileDataListSingleton
    {
        private static FileDataListSingleton instance;

        private readonly string ComponentFileName = "Component.xml";

        private readonly string OrderFileName = "Order.xml";

        private readonly string CarFileName = "Car.xml";

        private readonly string CarComponentFileName = "CarComponent.xml";

        public List<Component> Components { get; set; }

        public List<Order> Orders { get; set; }

        public List<Car> Cars { get; set; }

        public List<CarComponent> CarComponents { get; set; }

        private FileDataListSingleton()
        {
            Components = LoadComponents();
            Orders = LoadOrders();
            Cars = LoadCars();
            CarComponents = LoadCarComponents();
        }

        public static FileDataListSingleton GetInstance()
        {
            if (instance == null)
            {
                instance = new FileDataListSingleton();
            }
            return instance;
        }

        ~FileDataListSingleton()
        {
            SaveComponents();
            SaveOrders();
            SaveCars();
            SaveCarComponents();
        }

        private List<Component> LoadComponents()
        {
            var list = new List<Component>();

            if (File.Exists(ComponentFileName))
            {
                XDocument xDocument = XDocument.Load(ComponentFileName);

                var xElements = xDocument.Root.Elements("Component").ToList();

                foreach (var elem in xElements)
                {
                    list.Add(new Component
                    {
                        Id = Convert.ToInt32(elem.Attribute("Id").Value),
                        ComponentName = elem.Element("ComponentName").Value
                    });
                }
            }

            return list;
        }

        private List<Order> LoadOrders()
        {
            var list = new List<Order>();

            if (File.Exists(OrderFileName))
            {
                XDocument xDocument = XDocument.Load(OrderFileName);

                var xElements = xDocument.Root.Elements("Order").ToList();

                foreach (var elem in xElements)
                {
                    list.Add(new Order
                    {
                        Id = Convert.ToInt32(elem.Attribute("Id").Value),
                        CarId = Convert.ToInt32(elem.Element("CarId").Value),
                        Count = Convert.ToInt32(elem.Element("Count").Value),
                        Sum = Convert.ToDecimal(elem.Element("Sum").Value),
                        Status = (OrderStatus)Enum.Parse(typeof(OrderStatus),
                        elem.Element("Status").Value),
                        DateCreate = Convert.ToDateTime(elem.Element("DateCreate").Value),
                        DateImplement = string.IsNullOrEmpty(elem.Element("DateImplement").Value) ? (DateTime?)null : Convert.ToDateTime(elem.Element("DateImplement").Value),
                    });
                }
            }

            return list;
        }

        private List<Car> LoadCars()
        {
            var list = new List<Car>();

            if (File.Exists(CarFileName))
            {
                XDocument xDocument = XDocument.Load(CarFileName);

                var xElements = xDocument.Root.Elements("Car").ToList();

                foreach (var elem in xElements)
                {
                    list.Add(new Car
                    {
                        Id = Convert.ToInt32(elem.Attribute("Id").Value),
                        CarName = elem.Element("CarName").Value,
                        Price = Convert.ToDecimal(elem.Element("Price").Value)
                    });
                }
            }

            return list;
        }

        private List<CarComponent> LoadCarComponents()
        {
            var list = new List<CarComponent>();

            if (File.Exists(CarComponentFileName))
            {
                XDocument xDocument = XDocument.Load(CarComponentFileName);

                var xElements = xDocument.Root.Elements("CarComponent").ToList();

                foreach (var elem in xElements)
                {
                    list.Add(new CarComponent
                    {
                        Id = Convert.ToInt32(elem.Attribute("Id").Value),
                        CarId = Convert.ToInt32(elem.Element("CarId").Value),
                        ComponentId = Convert.ToInt32(elem.Element("ComponentId").Value),
                        Count = Convert.ToInt32(elem.Element("Count").Value)
                    });
                }
            }

            return list;
        }

        private void SaveComponents()
        {
            if (Components != null)
            {
                var xElement = new XElement("Components");

                foreach (var component in Components)
                {
                    xElement.Add(
                        new XElement("Component",
                        new XAttribute("Id", component.Id),
                        new XElement("ComponentName", component.ComponentName)
                        ));
                }

                XDocument xDocument = new XDocument(xElement);
                xDocument.Save(ComponentFileName);
            }
        }

        private void SaveOrders()
        {
            if (Orders != null)
            {
                var xElement = new XElement("Orders");

                foreach (var order in Orders)
                {
                    xElement.Add(
                        new XElement("Order",
                        new XAttribute("Id", order.Id),
                        new XElement("CarId", order.CarId),
                        new XElement("Count", order.Count),
                        new XElement("Sum", order.Sum),
                        new XElement("Status", order.Status),
                        new XElement("DateCreate", order.DateCreate),
                        new XElement("DateImplement", order.DateImplement)
                        ));
                }

                XDocument xDocument = new XDocument(xElement);
                xDocument.Save(OrderFileName);
            }
        }

        private void SaveCars()
        {
            if (Cars != null)
            {
                var xElement = new XElement("cars");

                foreach (var car in Cars)
                {
                    xElement.Add(
                        new XElement("Car",
                        new XAttribute("Id", car.Id),
                        new XElement("CarName", car.CarName),
                        new XElement("Price", car.Price)
                        ));
                }

                XDocument xDocument = new XDocument(xElement);
                xDocument.Save(CarFileName);
            }
        }

        private void SaveCarComponents()
        {
            if (CarComponents != null)
            {
                var xElement = new XElement("CarComponents");

                foreach (var carComponent in CarComponents)
                {
                    xElement.Add(new XElement("CarComponent",
                        new XAttribute("Id", carComponent.Id),
                        new XElement("CarId", carComponent.CarId),
                        new XElement("ComponentId", carComponent.ComponentId),
                        new XElement("Count", carComponent.Count)
                        ));
                }

                XDocument xDocument = new XDocument(xElement);
                xDocument.Save(CarComponentFileName);
            }
        }
    }
}