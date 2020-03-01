using System.ComponentModel;

namespace CarShopBuisnessLogic.ViewModels
{
    /// <summary>
    /// Сколько компонента, требуется при изготовлении машины
    /// </summary>
    public class CarComponentViewModel
    {
        public int Id { get; set; }

        public int CarId { get; set; }

        public int ComponentId { get; set; }

        [DisplayName("Компонент")]
        public string ComponentName { get; set; }

        [DisplayName("Количество")]
        public int Count { get; set; }
    }
}