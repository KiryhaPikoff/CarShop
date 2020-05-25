using CarShopBuisnessLogic.ViewModels;
using System.Collections.Generic;

namespace CarShopBuisnessLogic.HelperModels
{
    class ExcelInfoStorages : ExcelInfo
    {
        public List<ReportStorageViewModel> Storages { get; set; }
    }
}
