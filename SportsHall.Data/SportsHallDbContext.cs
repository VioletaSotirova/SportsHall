namespace SportsHall.Data
{
    using Microsoft.EntityFrameworkCore;
    using SportsHall.Data.Models;
    using System.Reflection;

    public class SportsHallDbContext : DbContext
    {
        public SportsHallDbContext()
        {
            
        }

        public SportsHallDbContext(DbContextOptions options)
            :base(options) 
        {
            
        }

        public virtual DbSet<Sport> Sports { get; set; } = null!;
        public virtual DbSet<Coach> Coaches { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
 