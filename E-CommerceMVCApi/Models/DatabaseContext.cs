using Microsoft.EntityFrameworkCore;

namespace E_CommerceMVCApi.Models
{
    public class DatabaseContext : DbContext
    {


        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {
        }


        DbSet<User> Users { get; set; } 
        DbSet<Product> Products { get; set; }
        DbSet<Order> Orders { get; set; }
    }
}
