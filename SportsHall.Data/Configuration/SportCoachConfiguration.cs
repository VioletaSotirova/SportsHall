using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SportsHall.Data.Models;
using System.Reflection.Emit;

namespace SportsHall.Data.Configuration
{
    public class SportCoachConfiguration : IEntityTypeConfiguration<SportCoach>
    {
        public void Configure(EntityTypeBuilder<SportCoach> builder)
        {
            builder.HasKey(sc => new { sc.CoachId, sc.SportId });

            builder.HasOne(sc => sc.Coach)
                .WithMany(c => c.SportsCoaches)
                .HasForeignKey(sc => sc.CoachId)
                .IsRequired();

            builder.HasOne(sc => sc.Sport)
                .WithMany(s => s.SportsCoaches)
                .HasForeignKey(sc => sc.SportId)
                .IsRequired();

            builder.HasData(Seed());

        }

        private List<SportCoach> Seed()
        {
            var list = new List<SportCoach>()
            {
                new SportCoach()
                {
                    CoachId = 1,
                    SportId = 1
                },

                new SportCoach()
                {
                    CoachId = 1,
                    SportId = 2
                },

                new SportCoach()
                {
                    CoachId = 2,
                    SportId = 4
                },

                new SportCoach()
                {
                    CoachId = 3,
                    SportId = 3
                }
            };
            return list;
        }
    }
}
