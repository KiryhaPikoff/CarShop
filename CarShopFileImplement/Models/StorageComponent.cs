namespace CarShopFileImplement.Models
{
    public class StorageComponent
    {
        public int Id { get; set; }
        public int StorageId { get; set; }
        public int ComponentId { get; set; }
        public int Count { get; set; }
    }
}