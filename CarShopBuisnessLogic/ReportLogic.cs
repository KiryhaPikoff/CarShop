using CarShopBuisnessLogic.BindingModels;
using CarShopBuisnessLogic.HelperModels;
using CarShopBuisnessLogic.Interfaces;
using CarShopBuisnessLogic.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;


namespace CarShopBuisnessLogic
{
    public class ReportLogic
    {
        private readonly IComponentLogic componentLogic;
        private readonly ICarLogic carLogic;
        private readonly IOrderLogic orderLogic;

        public ReportLogic(ICarLogic carLogic, IComponentLogic componentLogic, IOrderLogic orderLLogic)
        {
            this.carLogic = carLogic;
            this.componentLogic = componentLogic;
            this.orderLogic = orderLLogic;
        }

        /// <summary>
        /// Получение списка компонент с указанием, в каких изделиях используются
        /// </summary>
        /// <returns></returns>
   /*     public List<ReportCarViewModel> GetCars()
        {
            var components = componentLogic.Read(null);
            var cars = carLogic.Read(null);
            var list = new List<ReportCarViewModel>();
            foreach (var car in cars)
            {
                var record = new ReportCarViewModel
                {
                    CarName = car.CarName,
                    CarComponents = new List<Tuple<string, int>>(),
                    Price = car.Price
                };
                foreach (var component in components)
                {
                    if (car.CarComponents.ContainsKey(component.Id))
                    {
                        record.CarComponents.Add(new Tuple<string, int>(component.ComponentName, car.CarComponents[component.Id].Item2));
                    }
                }
                list.Add(record);
            }
            return list;
        }*/

        /// <summary>
        /// Получение списка заказов за определенный период
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public List<ReportOrdersViewModel> GetOrders(ReportBindingModel model)
        {
            return orderLogic.Read(new OrderBindingModel
            {
                DateFrom = model.DateFrom,
                DateTo = model.DateTo
            })
            .Select(x => new ReportOrdersViewModel
            {
                DateCreate = x.DateCreate,
                CarName = x.CarName,
                Count = x.Count,
                Sum = x.Sum,
                Status = x.Status
            })
           .ToList();
        }

        public List<ReportCarViewModel> GetCars()
        {
            return carLogic.Read(null)
            .Select(x => new ReportCarViewModel
            {
                CarName = x.CarName,
                Price = x.Price,
                CarComponents = x.CarComponents.Select(y => new Tuple<string, int>(y.Value.Item1, y.Value.Item2)).ToList()
            })
           .ToList();
        }

        public List<ReportCarComponentViewModel> GetCarComponentsWithCar()
        {
            var cars = this.GetCars();
            List<ReportCarComponentViewModel> listCompCar = new List<ReportCarComponentViewModel>();
            foreach (var car in cars)
            {
                foreach (var comp in car.CarComponents)
                {
                    listCompCar.Add(new ReportCarComponentViewModel
                    {
                        CarName = car.CarName,
                        ComponentName = comp.Item1,
                        Count = comp.Item2
                    });
                }
            }
            return listCompCar;
        }

        /// <summary>
        /// Сохранение компонент в файл-Word
        /// </summary>
        /// <param name="model"></param>
        public void SaveCarsToWordFile(ReportBindingModel model)
        {
            SaveToWord.CreateDoc(new WordInfo
            {
                FileName = model.FileName,
                Title = "Список машин",
                Cars = carLogic.Read(null)
            });
        }

        /// <summary>
        /// Сохранение заказов в файл-Excel
        /// </summary>
        /// <param name="model"></param>
        public void SaveOrdersToExcelFile(ReportBindingModel model)
        {
            SaveToExcel.CreateDoc(new ExcelInfo
            {
                FileName = model.FileName,
                Title = "Список заказов",
                Orders = GetOrders(model)
            });
        }

        /// <summary>
        /// Сохранение машин с компонентами в файл-Pdf
        /// </summary>
        /// <param name="model"></param>
        [Obsolete]
        public void SaveCarsToPdfFile(ReportBindingModel model)
        {
            SaveToPdf.CreateDoc(new PdfInfo
            {
                FileName = model.FileName,
                Title = "Список машин с компонентами",
                Cars = GetCars()
            });
        }
    }
}