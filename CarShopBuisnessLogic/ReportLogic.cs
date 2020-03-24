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
        public List<ReportCarComponentViewModel> GetCarComponent()
        {
            var components = componentLogic.Read(null);
            var cars = carLogic.Read(null);
            var list = new List<ReportCarComponentViewModel>();
            foreach (var component in components)
            {
                var record = new ReportCarComponentViewModel
                {
                    ComponentName = component.ComponentName,
                    Cars = new List<Tuple<string, int>>(),
                    TotalCount = 0
                };
                foreach (var car in cars)
                {
                    if (car.CarComponents.ContainsKey(component.Id))
                    {
                        record.Cars.Add(new Tuple<string, int>(car.CarName, car.CarComponents[component.Id].Item2));
                        record.TotalCount += car.CarComponents[component.Id].Item2;
                    }
                }
                list.Add(record);
            }
            return list;
        }

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

        /// <summary>
        /// Сохранение компонент в файл-Word
        /// </summary>
        /// <param name="model"></param>
        public void SaveComponentsToWordFile(ReportBindingModel model)
        {
            SaveToWord.CreateDoc(new WordInfo
            {
                FileName = model.FileName,
                Title = "Список компонент",
                Components = componentLogic.Read(null)
            });
        }

        /// <summary>
        /// Сохранение компонент с указаеним продуктов в файл-Excel
        /// </summary>
        /// <param name="model"></param>
        public void SaveCarComponentToExcelFile(ReportBindingModel model)
        {
            SaveToExcel.CreateDoc(new ExcelInfo
            {
                FileName = model.FileName,
                Title = "Список компонент",
                CarComponents = GetCarComponent()
            });
        }

        /// <summary>
        /// Сохранение заказов в файл-Pdf
        /// </summary>
        /// <param name="model"></param>
        [Obsolete]
        public void SaveOrdersToPdfFile(ReportBindingModel model)
        {
            SaveToPdf.CreateDoc(new PdfInfo
            {
                FileName = model.FileName,
                Title = "Список заказов",
                DateFrom = model.DateFrom.Value,
                DateTo = model.DateTo.Value,
                Orders = GetOrders(model)
            });
        }
    }
}