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
        private readonly IStorageLogic storageLogic;

        public ReportLogic(ICarLogic carLogic, IComponentLogic componentLogic, IOrderLogic orderLogic, IStorageLogic storageLogic)
        {
            this.carLogic = carLogic;
            this.componentLogic = componentLogic;
            this.orderLogic = orderLogic;
            this.storageLogic = storageLogic;
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

        public List<ReportStorageComponentViewModel> GetStorageComponents() 
        {
            return storageLogic.Read(null)
                .Select(x => x.StorageComponents
                        .Select(sc => new ReportStorageComponentViewModel
                        {
                            StorageName = x.StorageName,
                            ComponentName = sc.Value.Item1,
                            Count = sc.Value.Item2
                        }))
                .SelectMany(scl => scl)
                .ToList();
        }

        public List<ReportStorageViewModel> GetStorageWithComponents() 
        {
            return storageLogic.Read(null)
                .Select(x => new ReportStorageViewModel
                {
                    StorageName = x.StorageName,
                    Components = x.StorageComponents
                        .Select(
                            sc => new Tuple<string, int>(sc.Value.Item1, sc.Value.Item2)
                        ).ToList(),
                    TotalCount = x.StorageComponents.Sum(sc => sc.Value.Item2)
                })
                .ToList();
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

        public void SaveStoragesToWordFile(ReportBindingModel model)
        {
            SaveToWord.CreateDocStorages(new WordInfoStorages
            { 
                FileName = model.FileName,
                Title = "Список складов",
                Storages = storageLogic.Read(null)
            });
        }

        public void SaveStoragesToExcelFile(ReportBindingModel model)
        {
            SaveToExcel.CreateDocStorages(new ExcelInfoStorages
            {
                FileName = model.FileName,
                Title = "Список складов с компонентами",
                Storages = GetStorageWithComponents()
            });
        }

        public void SaveStorageComponentsToPdfFile(ReportBindingModel model)
        {
            SaveToPdf.CreateDocStorageComponents(new PdfInfoStorageComponents
            {
                FileName = model.FileName,
                Title = "Список компонентов на складах",
                StorageComponents = GetStorageComponents()
            });
        }

        /// <summary>
        /// Сохранение компонент в файл-Word
        /// </summary>
        /// <param name="model"></param>
        public void SaveCarsToWordFile(ReportBindingModel model)
        {
            SaveToWord.CreateDocCars(new WordInfoCars
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
            SaveToExcel.CreateDocOrders(new ExcelInfoOrders
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
            SaveToPdf.CreateDocCars(new PdfInfoCarComponents
            {
                FileName = model.FileName,
                Title = "Список машин с компонентами",
                Cars = GetCarComponentsWithCar()
            });
        }
    }
}