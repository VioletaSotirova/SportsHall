using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SportsHall.Data.Models;

namespace SportsHall.Data.Configuration
{
    public class ReservationConfiguration : IEntityTypeConfiguration<Reservation>
    {
        public void Configure(EntityTypeBuilder<Reservation> builder)
        {
            builder.HasKey(r => r.Id);

            builder.HasOne(r => r.Training)
                  .WithMany(t => t.Reservations)
                  .HasForeignKey(r => r.TrainingId)
                  .OnDelete(DeleteBehavior.Cascade); 

            builder.HasOne(r => r.User)
                  .WithMany(u => u.Reservations)
                  .HasForeignKey(r => r.UserId)
                  .OnDelete(DeleteBehavior.Cascade);  
        }
    }
}
