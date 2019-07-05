using Microsoft.EntityFrameworkCore;
namespace web_api_example.Models
{
    public class UserDBContext : DbContext
    {
        public UserDBContext(DbContextOptions<UserDBContext> options)
        : base(options)
        {}

        //faz o mapeando do objeto para a tabela
        public DbSet<User> Users{get; set;} 
    }
}