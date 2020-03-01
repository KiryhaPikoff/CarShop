namespace CarShopListImplement.Models
{
    /// <summary>
    /// Изделие, изготавливаемое в магазине
    /// </summary>
    public class Car
    {
        public int Id { get; set; }
        public string CarName { get; set; }
        public decimal Price { get; set; }
    }
}