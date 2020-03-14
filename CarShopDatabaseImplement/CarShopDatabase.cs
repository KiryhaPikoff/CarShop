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
                optionsBuilder.UseSqlServer(@"Data Source=DESKTOP-LCV7DQO\SQLEXPRESS;Initial Catalog=CarShopDatabase;Integrated Security=True;MultipleActiveResultSets=True;");
            }
            base.OnConfiguring(optionsBuilder);
        }
        public virtual DbSet<Component> Components { set; get; }
        public virtual DbSet<Car> Cars { set; get; }
        public virtual DbSet<CarComponent> CarComponents { set; get; }
        public virtual DbSet<Order> Orders { set; get; }
    }
}