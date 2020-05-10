using CarShopBuisnessLogic.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarShopBuisnessLogic.HelperModels
{
    class PdfInfoCarComponents : PdfInfo
    {
        public List<ReportCarComponentViewModel> Cars { get; set; }
    }
}
