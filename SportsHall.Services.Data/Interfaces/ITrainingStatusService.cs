using Microsoft.AspNetCore.Mvc.Rendering;
using SportsHall.Data.Models;
using SportsHall.Web.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportsHall.Services.Data.Interfaces
{
    public interface ITrainingStatusService
    {
        Task <IEnumerable<TrainingStatus>> GetAllStatusesAsync();
        Task<IEnumerable<SelectListItem>> GetTrainingStatusesAsSelectItemAsync();
    }
}
