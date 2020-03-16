using CarShopBuisnessLogic.ViewModels;
using System.Collections.Generic;

namespace CarShopBuisnessLogic.HelperModels
{
    class ExcelInfo
    {
        public string FileName { get; set; }
        public string Title { get; set; }
        public List<ReportCarComponentViewModel> ProductComponents { get; set; }
    }
}
