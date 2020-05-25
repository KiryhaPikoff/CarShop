using CarShopBuisnessLogic.ViewModels;
using System.Collections.Generic;

namespace CarShopBuisnessLogic.HelperModels
{
    class PdfInfoCarComponents : PdfInfo
    {
        public List<ReportCarComponentViewModel> Cars { get; set; }
    }
}
