using System.Collections.Generic;

namespace CarShopBuisnessLogic.BindingModels
{
    public class StorageBindingModel
    {
        public int? Id { get; set; }
        public string StorageName { get; set; }
        public Dictionary<int, (string, int)> StorageComponents { get; set; }
    }
}
