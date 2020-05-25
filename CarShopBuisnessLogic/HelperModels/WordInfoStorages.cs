using CarShopBuisnessLogic.ViewModels;
using System.Collections.Generic;

namespace CarShopBuisnessLogic.HelperModels
{
    class WordInfoStorages : WordInfo
    {
        public List<StorageViewModel> Storages { get; set; }
    }
}
