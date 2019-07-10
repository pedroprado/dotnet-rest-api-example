using Microsoft.EntityFrameworkCore;
namespace web_api_example.Models
{
    public class RepositoryContext:DbContext
    {
        public RepositoryContext(DbContextOptions options):base(options){}


        public DbSet<Order> orders {get; set;}

      //   protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
          //  optionsBuilder.UseMySql("server=remotemysql.com;Port=3306;database=t7jjZVOvqm;user=t7jjZVOvqm;password=nS4BiZO4TE");
        //}

    }
}