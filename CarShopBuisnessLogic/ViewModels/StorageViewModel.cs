using System.Collections.Generic;
using System.ComponentModel;

namespace CarShopBuisnessLogic.ViewModels
{
    public class StorageViewModel
    {
        public int Id { get; set; }

        [DisplayName("Название склада")]
        public string StorageName { get; set; }

        public Dictionary<int, (string, int)> StorageComponents { get; set; }
    }
}
