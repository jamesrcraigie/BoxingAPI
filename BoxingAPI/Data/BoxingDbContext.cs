using BoxingAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace BoxingAPI.Data
{
    public class BoxingDbContext : DbContext
    {
        public BoxingDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Boxer> Boxers { get; set; }

        public DbSet<Gym> Gyms { get; set; }

        public DbSet<Fight> Fights { get; set; }
    }
}
