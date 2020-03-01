using System.Collections.Generic;
using System.ComponentModel;

namespace CarShopBuisnessLogic.ViewModels
{
    /// <summary>
    /// Изделие, изготавливаемое в магазине
    /// </summary>
    public class CarViewModel
    {
        public int Id { get; set; }

        [DisplayName("Название машины")]
        public string CarName { get; set; }

        [DisplayName("Цена")]
        public decimal Price { get; set; }

        public Dictionary<int, (string, int)> CarComponents { get; set; }
    }
}