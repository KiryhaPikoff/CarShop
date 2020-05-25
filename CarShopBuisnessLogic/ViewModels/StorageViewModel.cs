using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.Serialization;

namespace CarShopBuisnessLogic.ViewModels
{
    [DataContract]
    public class StorageViewModel
    {
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        [DisplayName("Название склада")]
        public string StorageName { get; set; }

        [DataMember]
        public Dictionary<int, (string, int)> StorageComponents { get; set; }
    }
}
