using Microsoft.EntityFrameworkCore;
using warteg.Models;  

namespace warteg.Data
{
    public class WartegDbContext : DbContext
    {
        public WartegDbContext(DbContextOptions<WartegDbContext> options) : base(options)
        {
        }

        public DbSet<Food> Foods { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<Payment> Payments { get; set; } 

    }
}
