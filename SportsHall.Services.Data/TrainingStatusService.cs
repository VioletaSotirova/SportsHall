using Microsoft.AspNetCore.Mvc.Rendering;
using SportsHall.Data.Models;
using SportsHall.Data.Repository.Interfaces;
using SportsHall.Services.Data.Interfaces;

namespace SportsHall.Services.Data
{
    public class TrainingStatusService : ITrainingStatusService
    {
        private IRepository<TrainingStatus, int> trainingStatusRepository;

        public TrainingStatusService(IRepository<TrainingStatus, int> trainingStatusRepository)
        {
            this.trainingStatusRepository = trainingStatusRepository;
        }
        public async Task<IEnumerable<TrainingStatus>> GetAllStatusesAsync()
        {
            var trainingStatuses = await trainingStatusRepository.GetAllAsync();

            return trainingStatuses;
        }
        public async Task<IEnumerable<SelectListItem>> GetTrainingStatusesAsSelectItemAsync()
        {
            return (await trainingStatusRepository.GetAllAsync())
                .Select(ts => new SelectListItem { Value = ts.Id.ToString(), Text = ts.Name });
        }
    }
}
