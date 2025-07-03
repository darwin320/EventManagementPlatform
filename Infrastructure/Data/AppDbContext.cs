using Microsoft.EntityFrameworkCore;
using EventManagementPlatform.Domain.Entities;

namespace EventManagementPlatform.Infrastructure.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Event> Events { get; set; }
    }
}
