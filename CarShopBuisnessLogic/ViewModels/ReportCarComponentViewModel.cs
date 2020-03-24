using System;
using System.Collections.Generic;

namespace CarShopBuisnessLogic.ViewModels
{
    public class ReportCarComponentViewModel
    {
        public string ComponentName { get; set; }
        public int TotalCount { get; set; }
        public List<Tuple<string, int>> Cars { get; set; }
    }
}