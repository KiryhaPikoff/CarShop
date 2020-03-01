namespace CarShopBuisnessLogic.BindingModels
{
    /// <summary>
    /// Сколько компонента, требуется при изготовлении машины
    /// </summary>
    public class CarComponentBindingModel
    {
        public int Id { get; set; }
        public int CarId { get; set; }
        public int ComponentId { get; set; }
        public int Count { get; set; }
    }
}