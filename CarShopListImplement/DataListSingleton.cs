﻿using CarShopListImplement.Models;
using System.Collections.Generic;

namespace CarShopListImplement
{
    public class DataListSingleton
    {
        private static DataListSingleton instance;

        public List<Component> Components { get; set; }
        public List<Order> Orders { get; set; }
        public List<Car> Cars { get; set; }
        public List<CarComponent> CarComponents { get; set; }
        public List<Client> Clients { get; set; }
        public List<Implementer> Implementers { get; set; }
        public List<Storage> Storages { get; set; }
        public List<StorageComponent> StorageComponents { get; set; }

        private DataListSingleton()
        {
            Components = new List<Component>();
            Orders = new List<Order>();
            Cars = new List<Car>();
            CarComponents = new List<CarComponent>();
            Clients = new List<Client>();
            Implementers = new List<Implementer>();
            Storages = new List<Storage>();
            StorageComponents = new List<StorageComponent>();
        }
        public static DataListSingleton GetInstance()
        {
            if (instance == null)
            {
                instance = new DataListSingleton();
            }
            return instance;
        }
    }
}