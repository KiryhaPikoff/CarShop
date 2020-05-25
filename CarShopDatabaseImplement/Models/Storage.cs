using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarShopDatabaseImplement.Models
{
    public class Storage
    {
        public int Id { get; set; }

        [Required]
        public string StorageName { get; set; }

        [ForeignKey("StorageId")]
        public virtual List<StorageComponent> StorageComponents { get; set; }
    }
}
