using CarShopBuisnessLogic.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CarShopBuisnessLogic.HelperModels
{
    class ExcelInfo
    {
        public string FileName { get; set; }
        public string Title { get; set; }
        public DateTime DateFrom { get; set; }
        public DateTime DateTo { get; set; }
        public IEnumerable<IGrouping<DateTime, ReportOrdersViewModel>> Orders { get; set; }
    }
}
