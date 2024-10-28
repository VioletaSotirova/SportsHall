using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SportsHall.Data.Models;
using static SportsHall.Common.EntityValidationConstants.Coach;

namespace SportsHall.Data.Configuration
{
    public class CoachConfiguration : IEntityTypeConfiguration<Coach>
    {
        public void Configure (EntityTypeBuilder<Coach> builder)
        {
            builder.HasKey(c => c.Id);

            builder.Property(c => c.FirstName)
                .IsRequired()
                .HasMaxLength(FirstNameMaxLength);

            builder.Property(c => c.LastName)
                .IsRequired()
                .HasMaxLength(LastNameMaxLength);

            builder.Property(c => c.Phone)
               .IsRequired()
               .HasMaxLength(PhoneMaxLength);

            builder.Property(c => c.Expirience)
               .IsRequired()
               .HasMaxLength(ExpirienceMaxLength);
        }
    }
}
