
namespace SportsHall.Data.Models
{
    public class Reservation
    {
        public int Id { get; set; }
        public int TrainingId { get; set; }
        public Training Training { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public DateTime CreatedOn { get; set; }
    }
}
