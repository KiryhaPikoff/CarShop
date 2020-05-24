using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarShopDatabaseImplement.Models
{
    public class Client
    {
        public int Id { get; set; }
        [Required]
        public string Fio { get; set; }
        [Required]
        public string Login { get; set; }
        [Required]
        public string Password { get; set; }
        [ForeignKey("ClientId")]
        public virtual List<Order> Orders { get; set; }
        [ForeignKey("ClientId")]
        public virtual List<MessageInfo> MessageInfoes { get; set; }
    }
}