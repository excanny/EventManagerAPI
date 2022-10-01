using EventManager.Models;
using Microsoft.EntityFrameworkCore;

namespace EventManager.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext() { }
        public AppDbContext(DbContextOptions options) : base(options) { }

        public DbSet<Event> Events { get; set; }
    }
}
