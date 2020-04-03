using System.ComponentModel.DataAnnotations;

namespace CarShopDatabaseImplement.Models
{
    public class StorageComponent
    {
        public int Id { get; set; }

        public int StorageId { get; set; }

        public int ComponentId { get; set; }

        [Required]
        public int Count { get; set; }

        public virtual Component Component { get; set; }

        public virtual Car Car { get; set; }
    }
}