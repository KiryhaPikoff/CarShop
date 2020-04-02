using System;
using System.Collections.Generic;

namespace CarShopBuisnessLogic.ViewModels
{
    public class ReportCarViewModel
    {
        public string CarName { get; set; }
        public decimal Price { get; set; }
        public List<Tuple<string, int>> CarComponents { get; set; }
    }
}
