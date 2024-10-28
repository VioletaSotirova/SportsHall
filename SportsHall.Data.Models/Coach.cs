namespace SportsHall.Data.Models
{
    public class Coach
    {
        public int Id { get; set; }
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string? Email { get; set; }
        public string Phone { get; set; } = null!;
        public string Expirience { get; set; } = null!;
        public IEnumerable<SportCoach> SportsCoaches { get; set; } = new List<SportCoach>();

    }
}
