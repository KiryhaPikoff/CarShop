namespace CarShopFileImplement.Models
{
    /// <summary>
    /// Сколько компонентов, требуется при изготовлении машины
    /// </summary>
    public class CarComponent
    {
        public int Id { get; set; }
        public int CarId { get; set; }
        public int ComponentId { get; set; }
        public int Count { get; set; }
    }
}