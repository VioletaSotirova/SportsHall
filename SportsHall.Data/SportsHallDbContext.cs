using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SportsHall.Data.Models;
using System.Reflection;

namespace SportsHall.Data
{
    public class SportsHallDbContext : IdentityDbContext<ApplicationUser, IdentityRole<int>, int>
    {
        public SportsHallDbContext()
        {
        }

        public SportsHallDbContext(DbContextOptions<SportsHallDbContext> options)
            : base(options)
        {
        }

        public DbSet<Sport> Sports { get; set; }
        public DbSet<Coach> Coaches { get; set; }
        public DbSet<SportCoach> SportsCoaches { get; set; }
        public DbSet<Training> Trainings { get; set; }
        public DbSet<Reservation> Reservations { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
