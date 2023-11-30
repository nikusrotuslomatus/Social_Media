using Microsoft.EntityFrameworkCore;
using Social_Media.Models;

namespace Social_Media.Data
{
    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options): base(options)
        {
            
        }
        public DbSet<Concert> Concerts { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<Address> Addresses { get; set; }
    }
}
