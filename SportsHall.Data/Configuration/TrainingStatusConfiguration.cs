using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using SportsHall.Data.Models;
using static SportsHall.Common.EntityValidationConstants.TrainingStatus;
using System.Globalization;
using Microsoft.VisualBasic;

namespace SportsHall.Data.Configuration
{
    public class TrainingStatusConfiguration : IEntityTypeConfiguration<TrainingStatus>
    {
        public void Configure(EntityTypeBuilder<TrainingStatus> builder)
        {
            builder.HasKey(ts => ts.Id);

            builder.Property(ts => ts.Name)
                .IsRequired()
                .HasMaxLength(NameMaxLength);

            builder.HasData(SeedStatuses());
        }

        private List<TrainingStatus> SeedStatuses()
        {
            var statuses = new List<TrainingStatus>()
            {
                new TrainingStatus
                {
                    Id = 1,
                    Name = "Active"

                },

                new TrainingStatus
                {
                    Id = 2,
                    Name = "Completed"
                },

                new TrainingStatus
                {
                    Id = 3,
                    Name = "Cancelled"
                }
            };

            return statuses;
        }
    }
}

