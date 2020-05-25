using CarShopBuisnessLogic.ViewModels;
using System.Collections.Generic;

namespace CarShopBuisnessLogic.HelperModels
{
    class PdfInfoStorageComponents : PdfInfo
    {
        public List<ReportStorageComponentViewModel> StorageComponents { get; set; }
    }
}
