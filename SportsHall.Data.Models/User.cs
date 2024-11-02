namespace SportsHall.Data.Models
{
    public class User
    {
        public int Id { get; set; }
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string Phone { get; set; } = null!;
        public string? Email { get; set; }
        public IEnumerable<Reservation> Reservations { get; set; } = new List<Reservation>();
    }
}
