using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SportsHall.Data.Models;
using System.Reflection.Emit;
using static SportsHall.Common.EntityValidationConstants.Sport;


namespace SportsHall.Data.Configuration
{
    public class SportConfiguration : IEntityTypeConfiguration<Sport>
    {
        public void Configure(EntityTypeBuilder<Sport> builder)
        {
            builder.HasKey(s => s.Id);

            builder.Property(s => s.Name)
                .IsRequired()
                .HasMaxLength(NameMaxLength);

            builder.Property(s => s.Description)
                .IsRequired()
                .HasMaxLength(DescriptionMaxLength);

            builder.Property(s => s.MaxParticipants)
            .IsRequired();

        }
    }
}
