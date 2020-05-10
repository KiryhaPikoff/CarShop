using CarShopBuisnessLogic.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarShopBuisnessLogic.HelperModels
{
    class WordInfoStorages : WordInfo
    {
        public List<StorageViewModel> Storages { get; set; }
    }
}
