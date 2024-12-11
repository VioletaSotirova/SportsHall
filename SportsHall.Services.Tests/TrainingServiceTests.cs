using Microsoft.EntityFrameworkCore;

using SportsHall.Data;
using SportsHall.Data.Models;
using SportsHall.Data.Repository;
using SportsHall.Data.Repository.Interfaces;
using SportsHall.Services.Data;
using SportsHall.Services.Data.Interfaces;
using SportsHall.Services.Mapping;
using SportsHall.Web.ViewModels;

namespace SportsHall.Services.Tests
{
    [TestFixture]
    public class TrainingServiceTests
    {
        private SportsHallDbContext dbContext;
        private IRepository<Training, int> trainingRepository;
        private ITrainingService trainingService;
        private ISportService sportService;
        private ICoachService coachService;
        private ITrainingStatusService trainingStatusService;

        [SetUp]
        public void Setup()
        {
            ConfigureAutoMapper();

            var options = new DbContextOptionsBuilder<SportsHallDbContext>()
                .UseInMemoryDatabase(databaseName: "TestDb_Training")
                .EnableSensitiveDataLogging()
                .Options;

            dbContext = new SportsHallDbContext(options);

            trainingRepository = new BaseRepository<Training, int>(dbContext);
            sportService = new SportService(new BaseRepository<Sport, int>(dbContext));
            coachService = new CoachService(new BaseRepository<Coach, int>(dbContext));
            trainingStatusService = new TrainingStatusService(new BaseRepository<TrainingStatus, int>(dbContext));
            trainingService = new TrainingService(trainingRepository, sportService, coachService, trainingStatusService);

            dbContext.Sports.Add(new Sport
            {
                Id = 1,
                Name = "Football",
                Description = "A popular team sport played worldwide.",
                MaxParticipants = 22,
                ImageUrl = "https://example.com/football.jpg"
            });

            dbContext.Sports.Add(new Sport
            {
                Id = 2,
                Name = "Basketball",
                Description = "A sport played on a court with a ball and two baskets.",
                MaxParticipants = 10,
                ImageUrl = "https://example.com/basketball.jpg"
            });

            dbContext.Coaches.Add(new Coach
            {
                Id = 1,
                FirstName = "John",
                LastName = "Doe",
                Expirience = "5 years",
                Phone = "123456789",
                Email = "john.doe@example.com",
                ImageUrl = "https://example.com/john.jpg"
            });

            dbContext.TrainingsStatuses.Add(new TrainingStatus
            {
                Id = 1,
                Name = "Scheduled"
            });

            dbContext.SaveChanges();
        }

        [TearDown]
        public void TearDown()
        {
            dbContext.Database.EnsureDeleted();
            dbContext.Dispose();
        }

        [Test]
        public async Task GetAllAsync_ShouldReturnAllTrainings()
        {
            var userId = "1"; 

            var result = await trainingService.GetAllAsync(userId);

            Assert.IsNotNull(result);
            Assert.AreEqual(0, result.Count());
        }

        [Test]
        public async Task CreateAsync_ShouldAddNewTraining()
        {
            var createModel = new TrainingCreateViewModel
            {
                SportId = 1,
                CoachId = 1,
                Start = DateTime.Now.AddDays(1),
                Location = "Football Field",
                Duration = 90,
                TrainingStatusId = 1
            };

            var createdTraining = await trainingService.CreateAsync(createModel);

            var allTrainings = dbContext.Trainings.ToList();
            Assert.AreEqual(1, allTrainings.Count); 
            Assert.AreEqual("Football", allTrainings.First().Sport.Name);
            Assert.AreEqual("John", allTrainings.First().Coach.FirstName);
            Assert.AreEqual("Scheduled", allTrainings.First().TrainingStatus.Name);
        }

        [Test]
        public async Task EditAsync_ShouldReturnCorrectTrainingViewModel()
        {
            var createModel = new TrainingCreateViewModel
            {
                SportId = 1, 
                CoachId = 1,
                Start = DateTime.Now.AddDays(1),
                Location = "Football Field",
                Duration = 90,
                TrainingStatusId = 1
            };

            var createdTraining = await trainingService.CreateAsync(createModel);

            var trainingToEdit = await trainingService.EditAsync(createdTraining.Id);

            Assert.IsNotNull(trainingToEdit);
            Assert.AreEqual(createdTraining.Id, trainingToEdit.Id);

            var sportInDb = await dbContext.Sports.FindAsync(trainingToEdit.SportId); 
            Assert.AreEqual("Football", sportInDb.Name); 
        }


        [Test]
        public async Task UpdateAsync_ShouldUpdateTrainingDetails()
        {
            var createModel = new TrainingCreateViewModel
            {
                SportId = 1,
                CoachId = 1,
                Start = DateTime.Now.AddDays(1),
                Location = "Football Field",
                Duration = 90,
                TrainingStatusId = 1
            };

            var createdTraining = await trainingService.CreateAsync(createModel);

            var updateModel = new TrainingCreateViewModel
            {
                Id = createdTraining.Id,
                SportId = 2, 
                CoachId = 1,
                Start = DateTime.Now.AddDays(2),
                Location = "Basketball Court",
                Duration = 120,
                TrainingStatusId = 1
            };

            await trainingService.UpdateAsync(updateModel);

            var updatedTraining = dbContext.Trainings.FirstOrDefault(t => t.Id == createdTraining.Id);
            Assert.IsNotNull(updatedTraining);
            Assert.AreEqual("Basketball", updatedTraining.Sport.Name);
            Assert.AreEqual("Basketball Court", updatedTraining.Location);
            Assert.AreEqual(120, updatedTraining.Duration);
        }

        [Test]
        public async Task DeleteAsync_ShouldRemoveTraining()
        {
            var createModel = new TrainingCreateViewModel
            {
                SportId = 1,
                CoachId = 1,
                Start = DateTime.Now.AddDays(1),
                Location = "Football Field",
                Duration = 90,
                TrainingStatusId = 1
            };

            var createdTraining = await trainingService.CreateAsync(createModel);

            await trainingService.DeleteAsync(createdTraining.Id);

            var allTrainings = dbContext.Trainings.ToList();
            Assert.AreEqual(0, allTrainings.Count); 
        }
        private void ConfigureAutoMapper()
        {
            AutoMapperConfig.RegisterMappings(
                typeof(SportsViewModel).Assembly,
                typeof(Sport).Assembly);
        }
    }
}
