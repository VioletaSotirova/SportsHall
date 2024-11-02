using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SportsHall.Data.Models;
using static SportsHall.Common.EntityValidationConstants.Sport;
using static System.Runtime.InteropServices.JavaScript.JSType;


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

            builder.HasData(this.SeedSports());
        }
    
        private List<Sport> SeedSports()
        {
            List<Sport> sports = new List<Sport>()
            {
                new Sport()
                {  
                    Id = 1,
                    ImageUrl = "/images/Zumba.jpg",
                    Name = "Zumba",
                    Description = "Zumba is a Latin-inspired dance workout that instructors say is primarily an aerobic workout — and it's all about having fun. Few exercise classes have had Zumba's staying power.",
                    MaxParticipants = 30,  
                },

                new Sport()
                {
                    Id = 2,
                    ImageUrl = "/images/Spinning.jpg",
                    Name = "Spinning",
                    Description = "Indoor cycling, often called spinning, is a form of exercise with classes focusing on endurance, strength, intervals, high intensity (race days) and recovery, and involves using a special stationary exercise bicycle with a weighted flywheel in a classroom setting.",
                    MaxParticipants = 20,
                },

                new Sport()
                {
                    Id = 3,
                    ImageUrl = "/images/yoga.jpg",
                    Name = "Yoga",
                    Description = "Yoga as exercise is a physical activity consisting mainly of postures, often connected by flowing sequences, sometimes accompanied by breathing exercises, and frequently ending with relaxation lying down or meditation.",
                    MaxParticipants = 5,
                },

                new Sport()
                {
                    Id = 4,
                    ImageUrl = "/images/crossFit.jpg",
                    Name = "CrossFit",
                    Description = "CrossFit is focused on constantly varied high-intensity functional movement, drawing on categories and exercises such as calisthenics, Olympic-style weightlifting, powerlifting, strongman-type events, plyometrics, bodyweight exercises, indoor rowing, aerobic exercise, running, and swimming.",
                    MaxParticipants = 14,
                }
            };

            return sports;
        }
    }
}
