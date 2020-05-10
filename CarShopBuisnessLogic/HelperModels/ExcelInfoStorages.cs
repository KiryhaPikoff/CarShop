using CarShopBuisnessLogic.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarShopBuisnessLogic.HelperModels
{
    class ExcelInfoStorages : ExcelInfo
    {
        public List<ReportStorageViewModel> Storages { get; set; }
    }
}
