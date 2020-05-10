using CarShopBuisnessLogic.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarShopBuisnessLogic.HelperModels
{
    class PdfInfoStorageComponents : PdfInfo
    {
        public List<ReportStorageComponentViewModel> StorageComponents { get; set; }
    }
}
