namespace SportsHall.Data.Models
{
    public class Training
    {
        public int Id { get; set; }
        public int SportId { get; set; }
        public Sport Sport { get; set; } = null!;
        public int CoachId { get; set; }
        public Coach Coach { get; set; } = null!;
        public int TrainingStatusId { get; set; }
        public TrainingStatus TrainingStatus { get; set; } = null!;
        public DateTime Start { get; set; }
        public string Location { get; set; } = null!;
        public int Duration { get; set; }
        public int AvailableSpot { get; set; }
        public IList<Reservation> Reservations { get; set; } = new List<Reservation>();

    }
}
