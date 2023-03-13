using Microsoft.EntityFrameworkCore;
using Database.models;
namespace Database
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        public DbSet<userm> Userm { get; set; }
    }
}