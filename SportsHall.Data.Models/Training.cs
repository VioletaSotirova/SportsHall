namespace SportsHall.Data.Models
{
    public class Training
    {
        public int Id { get; set; }
        public int SportId { get; set; }
        public Sport Sport { get; set; }
        public int CoachId { get; set; }
        public Coach Coach { get; set; }
        public DateTime Start { get; set; }
        public string Location { get; set; }
        public int Duration { get; set; }
        public int AvailableSpot { get; set; }
        public bool Status { get; set; }
        public IEnumerable<Reservation> Reservations { get; set; } = new List<Reservation>();

    }
}
