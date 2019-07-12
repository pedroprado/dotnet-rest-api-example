using Microsoft.EntityFrameworkCore;
namespace web_api_example.Models
{
    public class RepositoryContext:DbContext
    {
        public RepositoryContext(DbContextOptions options):base(options){}

        public DbSet<Order> orders {get; set;}
        public DbSet<Customer> customers{get;set;}

    }
}