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

        public SportsHallDbContext(DbContextOptions<SportsHallDbContext> options)
            :base(options) 
        {
            
        }

        public DbSet<Sport> Sports { get; set; } 
        public DbSet<Coach> Coaches { get; set; } 
        public DbSet<SportCoach> SportsCoaches { get; set; } 
        public DbSet<Training> Trainings { get; set; } 
        public DbSet<User> Users { get; set; } 
        public DbSet<Reservation> Reservations { get; set; } 

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
 