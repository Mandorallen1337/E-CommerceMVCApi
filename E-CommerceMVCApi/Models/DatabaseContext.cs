using Microsoft.EntityFrameworkCore;

namespace E_CommerceMVCApi.Models
{
    public class DatabaseContext : DbContext
    {


        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {

        }


        public DbSet<User> Users { get; set; } 
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
    }
}
