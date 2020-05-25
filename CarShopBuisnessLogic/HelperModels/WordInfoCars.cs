using CarShopBuisnessLogic.ViewModels;
using System.Collections.Generic;

namespace CarShopBuisnessLogic.HelperModels
{
    class WordInfoCars : WordInfo
    {
        public List<CarViewModel> Cars { get; set; }
    }
}
