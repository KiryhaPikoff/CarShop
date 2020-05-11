using CarShopDatabaseImplement.Models;
using Microsoft.EntityFrameworkCore;

namespace CarShopDatabaseImplement
{
    public class CarShopDatabase : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (optionsBuilder.IsConfigured == false)
            {
                optionsBuilder.UseSqlServer(@"Data Source=DESKTOP-3FLK5BJ\SQLEXPRESS;Initial Catalog=CarShopDatabaseHard5;Integrated Security=True;MultipleActiveResultSets=True;");
            }
            base.OnConfiguring(optionsBuilder);
        }
        public virtual DbSet<Component> Components { set; get; }
        public virtual DbSet<Car> Cars { set; get; }
        public virtual DbSet<CarComponent> CarComponents { set; get; }
        public virtual DbSet<Order> Orders { set; get; }
        public virtual DbSet<Client> Clients { set; get; }
        public virtual DbSet<Storage> Storages { set; get; }
        public virtual DbSet<StorageComponent> StorageComponents { set; get; }
    }
}