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
        /// Получение списка заказов за определенный период
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public IEnumerable<IGrouping<DateTime, ReportOrdersViewModel>> GetOrders(ReportBindingModel model)
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
            .GroupBy(x => x.DateCreate.Date);
        }

        public List<ReportCarComponentViewModel> GetCarComponentsWithCar()
        {
            var cars = carLogic.Read(null);
            List<ReportCarComponentViewModel> listCompCar = new List<ReportCarComponentViewModel>();
            foreach (var car in cars)
            {
                foreach (var comp in car.CarComponents)
                {
                    listCompCar.Add(new ReportCarComponentViewModel
                    {
                        CarName = car.CarName,
                        ComponentName = comp.Value.Item1,
                        Count = comp.Value.Item2
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
        public void SaveCarsWithComponentsToPdfFile(ReportBindingModel model)
        {
            SaveToPdf.CreateDoc(new PdfInfo
            {
                FileName = model.FileName,
                Title = "Список машин с компонентами",
                Cars = GetCarComponentsWithCar()
            });
        }
    }
}