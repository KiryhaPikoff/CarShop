using System;
using System.Collections.Generic;
using System.Text;

namespace CarShopBuisnessLogic.ViewModels
{
    public class ReportStorageViewModel
    {
        public string StorageName { get; set; }
        public List<Tuple<string, int>> Components { get; set; }
        public int TotalCount { get; set; }
    }
}
