using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SportsHall.Data.Models;
using static SportsHall.Common.EntityValidationConstants.ApplicationUser;


namespace SportsHall.Data.Configuration
{
    public class ApplicationUserConfiguration : IEntityTypeConfiguration<ApplicationUser>
    {
        public void Configure(EntityTypeBuilder<ApplicationUser> builder)
        {

            builder.Property(au => au.FirstName)
                .IsRequired()
                .HasMaxLength(FirstNameMaxLength);

            builder.Property(au => au.LastName)
               .IsRequired()
               .HasMaxLength(LastNameMaxLength);

        }
    }
}