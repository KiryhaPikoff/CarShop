using CarShopBuisnessLogic.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CarShopBuisnessLogic.HelperModels
{
    class ExcelInfoOrders : ExcelInfo
    {
        public IEnumerable<IGrouping<DateTime, ReportOrdersViewModel>> Orders { get; set; }
    }
}
