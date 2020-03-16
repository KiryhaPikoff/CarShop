using CarShopBuisnessLogic.ViewModels;
using System.Collections.Generic;

namespace CarShopBuisnessLogic.HelperModels
{
    class WordInfo
    {
        public string FileName { get; set; }
        public string Title { get; set; }
        public List<ComponentViewModel> Components { get; set; }
    }

}