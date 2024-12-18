﻿using SportsHall.Data.Models;
using SportsHall.Services.Mapping;

namespace SportsHall.Web.ViewModels
{
    public class ReservationViewModel : IMapFrom<Reservation>
    {
        public int Id { get; set; }
        public int TrainingId { get; set; }
        public string SportName { get; set; } = null!;
        public string CoachName { get; set; } = null!;
        public DateTime Start { get; set; }
        public string Location { get; set; } = null!;
        public DateTime CreatedOn { get; set; }
    }
}
