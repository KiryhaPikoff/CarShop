using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.Serialization;

namespace CarShopBuisnessLogic.ViewModels
{
    /// <summary>
    /// Изделие, изготавливаемое в магазине
    /// </summary>
    [DataContract]
    public class CarViewModel
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        [DisplayName("Название машины")]
        public string CarName { get; set; }
        [DataMember]
        [DisplayName("Цена")]
        public decimal Price { get; set; }
        [DataMember]
        public Dictionary<int, (string, int)> CarComponents { get; set; }
    }
}