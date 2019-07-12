using Microsoft.EntityFrameworkCore;
namespace web_api_example.Models
{
    public class RepositoryContext:DbContext
    {
        public RepositoryContext(DbContextOptions options):base(options){}

        public DbSet<Order> orders {get; set;}
        public DbSet<Customer> customers{get;set;}

        protected override void OnModelCreating(ModelBuilder modelBuilder){
            modelBuilder.Entity<Order>()
            .HasOne(c => c.Customer)
            .WithMany( o => o.Orders)
            .HasForeignKey( fk => fk.customerId )
            .HasConstraintName("fk_orders_customers");
        }

    }

    
}