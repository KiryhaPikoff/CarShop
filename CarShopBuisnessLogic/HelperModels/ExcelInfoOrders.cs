using CarShopBuisnessLogic.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CarShopBuisnessLogic.HelperModels
{
    class ExcelInfoOrders : ExcelInfo
    {
        public IEnumerable<IGrouping<DateTime, ReportOrdersViewModel>> Orders { get; set; }
    }
}
