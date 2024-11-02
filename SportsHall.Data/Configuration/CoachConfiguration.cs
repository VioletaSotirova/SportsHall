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

            builder.HasData(SeedCoaches());
        }

        private List<Coach> SeedCoaches()
        {
            List<Coach> coaches = new List<Coach>()
            {
                new Coach()
                {
                    Id = 1,
                    FirstName = "Vanya",
                    LastName = "Ivanova",
                    Email = "vanya89@gmail.com",
                    Phone = "0885222111",
                    Expirience = "Vanya is a passionate fitness professional with over five years of experience in group fitness instruction, specializing in Zumba and Spinning. With a vibrant personality and an infectious enthusiasm for fitness, Jessica creates an uplifting and energetic environment in her classes."
                },

                new Coach()
                {
                    Id = 2,
                    FirstName = "Ivaylo",
                    LastName = "Petkov",
                    Email = "ivoPetkov@gmail.com",
                    Phone = "0883212121",
                    Expirience = "Ivaylo is a dedicated CrossFit coach with over six years of experience in the fitness industry. His passion for high-intensity training and commitment to functional fitness has transformed the lives of countless athletes and fitness enthusiasts."
                },

                new Coach()
                {
                    Id = 3,
                    FirstName = "Sonya",
                    LastName = "Stamatova",
                    Email = "Sonya@gmail.com",
                    Phone = "0883212122",
                    Expirience = "Sonya  is a highly experienced yoga instructor with over ten years of dedicated practice and teaching experience. Her journey with yoga began as a way to find inner balance and mindfulness, which she now shares with her students, guiding them toward a holistic approach to wellness."
                }
            };

            return coaches;
        }
    }
}
