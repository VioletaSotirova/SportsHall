namespace SportsHall.Web.ViewModels
{
    public class ReservationViewModel
    {
        public int TrainingId { get; set; }
        public string SportName { get; set; } = null!;
        public string CoachName { get; set; } = null!;
        public DateTime Start { get; set; }
        public string Location { get; set; } = null!;
        public DateTime CreatedOn { get; set; }
    }
}
