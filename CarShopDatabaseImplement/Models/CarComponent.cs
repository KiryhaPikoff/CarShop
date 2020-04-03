using System.ComponentModel.DataAnnotations;

namespace CarShopDatabaseImplement.Models
{
    /// <summary>
    /// Сколько компонентов, требуется при изготовлении изделия
    /// </summary>
    public class CarComponent
    {
        public int Id { get; set; }

        public int CarId { get; set; }

        public int ComponentId { get; set; }

        [Required]
        public int Count { get; set; }

        public virtual Component Component { get; set; }

        public virtual Car Car { get; set; }
    }
}