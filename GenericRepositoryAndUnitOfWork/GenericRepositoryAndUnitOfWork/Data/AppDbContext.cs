using GenericRepositoryAndUnitOfWork.Model;
using Microsoft.EntityFrameworkCore;

namespace GenericRepositoryAndUnitOfWork.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) 
        {
        
        }

        public DbSet<User> Users { get; set; }
    }
}
