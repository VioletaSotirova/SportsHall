using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SportsHall.Data.Models;
using static SportsHall.Common.EntityValidationConstants.User;


namespace SportsHall.Data.Configuration
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(u => u.Id);

            builder.Property(u => u.FirstName)
                .IsRequired()
                .HasMaxLength(FirstNameMaxLength);

            builder.Property(u => u.LastName)
               .IsRequired()
               .HasMaxLength(LastNameMaxLength);

            builder.Property(u => u.Phone)
                .IsRequired()
                .HasMaxLength(PhoneMaxLength);
        }
    }
}
