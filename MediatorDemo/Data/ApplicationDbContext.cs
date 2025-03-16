using MediatorDemo.Models;
using Microsoft.EntityFrameworkCore;

namespace MediatorDemo.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
        public DbSet<Player> players { get; set; }
    }
}
