using SportsHall.Data.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using static SportsHall.Common.EntityValidationConstants.Training;
using System.Globalization;

namespace SportsHall.Data.Configuration
{
    public class TrainingConfiguration : IEntityTypeConfiguration<Training>
    {
        public void Configure(EntityTypeBuilder<Training> builder)
        {
            builder.HasKey(t => t.Id);

            builder.HasOne(t => t.Sport)
                .WithMany(s => s.Trainings)
                .HasForeignKey(t => t.SportId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(t => t.Coach)
                .WithMany(c => c.Trainings)
                .HasForeignKey(t => t.CoachId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Property(t => t.Location)
                .IsRequired()
                .HasMaxLength(LocationMaxLength);

            builder.Property(t => t.Start)
                .IsRequired();

            builder.Property(t => t.Duration)
                .IsRequired();

            builder.Property(t => t.AvailableSpot)
                .IsRequired();

            builder.Property(t => t.Status)
                .IsRequired();
            builder.HasData(SeedTrainings());
        }

        private List<Training> SeedTrainings()
        {
            var trainings = new List<Training>()
            {
                new Training
                {
                    Id = 1,
                    SportId = 1,
                    CoachId = 1,
                    Start  = DateTime.ParseExact("2024-10-31 08:30",DateFormat, CultureInfo.InvariantCulture),
                    Location = "Plovdiv, bul.Hristo Botev 4, DynamicFitCenter, Hall 3",
                    Duration = 50,
                    AvailableSpot = 30
                },

                 new Training
                {
                    Id = 2,
                    SportId = 2,
                    CoachId = 1,
                    Start  = DateTime.ParseExact("2024-10-31 10:30",DateFormat, CultureInfo.InvariantCulture),
                    Location = "Plovdiv, bul.Hristo Botev 4, DynamicFitCenter, Hall 1",
                    Duration = 30,
                    AvailableSpot = 20
                },

                  new Training
                {
                    Id = 3,
                    SportId = 3,
                    CoachId = 3,
                    Start  = DateTime.ParseExact("2024-10-31 11:00",DateFormat, CultureInfo.InvariantCulture),
                    Location = "Plovdiv, bul.Hristo Botev 4, DynamicFitCenter, Hall 5",
                    Duration = 50,
                    AvailableSpot = 5
                },

                    new Training
                {
                    Id = 4,
                    SportId = 4,
                    CoachId = 2,
                    Start  = DateTime.ParseExact("2024-10-31 11:50",DateFormat, CultureInfo.InvariantCulture),
                    Location = "Plovdiv, bul.Hristo Botev 4, DynamicFitCenter, Hall 5",
                    Duration = 45,
                    AvailableSpot = 14
                }
            };
            return trainings;
        }
    }
}

 
