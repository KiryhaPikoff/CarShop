using CarShopBuisnessLogic.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarShopBuisnessLogic.HelperModels
{
    class WordInfoCars : WordInfo
    {
        public List<CarViewModel> Cars { get; set; }
    }
}
