using Microsoft.EntityFrameworkCore;

namespace ProductCustomers.Models
{
    public class pcDbContext : DbContext
    {
        public pcDbContext(DbContextOptions<pcDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Order>().HasKey(o => new {o.productID, o.customerID});
        }

        public DbSet<Product> Products {get; set;} = default!;
        public DbSet<Customer> Customers {get; set;} = default!; 
        public DbSet<Order> Order {get; set;} = default!;
    }
}