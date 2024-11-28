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
        public string? ImageUrl { get; set; }
        public IEnumerable<Training> Trainings { get; set; } = new List<Training>();

    }
}
