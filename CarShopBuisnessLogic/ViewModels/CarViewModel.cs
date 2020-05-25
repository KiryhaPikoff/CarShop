using CarShopBuisnessLogic.Attributes;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.Serialization;

namespace CarShopBuisnessLogic.ViewModels
{
    /// <summary>
    /// Изделие, изготавливаемое в магазине
    /// </summary>
    [DataContract]
    public class CarViewModel : BaseViewModel
    {
        [DataMember]
        [Column(title: "Название машины", width: 150)]
        public string CarName { get; set; }
        
        [DataMember]
        [Column(title: "Цена", width: 100)]
        public decimal Price { get; set; }
        [DataMember]
        public Dictionary<int, (string, int)> CarComponents { get; set; }

        public override List<string> Properties() => new List<string> { "Id", "CarName", "Price" };
    }
}