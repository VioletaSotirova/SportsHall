using Microsoft.EntityFrameworkCore;
using SportsHall.Data;
using SportsHall.Data.Models;
using SportsHall.Data.Repository.Interfaces;
using SportsHall.Services.Data;

using SportsHall.Data.Repository;

namespace SportsHall.Services.Tests
{
    [TestFixture]
    public class TrainingStatusServiceTests
    {
        private SportsHallDbContext dbContext;
        private IRepository<TrainingStatus, int> trainingStatusRepository;
        private TrainingStatusService trainingStatusService;

        [SetUp]
        public void Setup()
        {
            var options = new DbContextOptionsBuilder<SportsHallDbContext>()
                .UseInMemoryDatabase(databaseName: "TestDb")
                .Options;

            dbContext = new SportsHallDbContext(options);
            trainingStatusRepository = new BaseRepository<TrainingStatus, int>(dbContext);
            trainingStatusService = new TrainingStatusService(trainingStatusRepository);

            dbContext.TrainingsStatuses.Add(new TrainingStatus { Id = 1, Name = "Scheduled" });
            dbContext.TrainingsStatuses.Add(new TrainingStatus { Id = 2, Name = "In Progress" });
            dbContext.TrainingsStatuses.Add(new TrainingStatus { Id = 3, Name = "Completed" });
            dbContext.SaveChanges();
        }

        [TearDown]
        public void TearDown()
        {
            dbContext.Database.EnsureDeleted();
            dbContext.Dispose();
        }

        [Test]
        public async Task GetAllStatusesAsync_ShouldReturnAllTrainingStatuses()
        {
            var result = await trainingStatusService.GetAllStatusesAsync();

            Assert.IsNotNull(result);
            Assert.AreEqual(3, result.Count); 
            Assert.IsTrue(result.Any(ts => ts.Name == "Scheduled"));
            Assert.IsTrue(result.Any(ts => ts.Name == "In Progress"));
            Assert.IsTrue(result.Any(ts => ts.Name == "Completed"));
        }

        [Test]
        public async Task GetTrainingStatusesAsSelectItemAsync_ShouldReturnCorrectSelectItems()
        {
            var result = await trainingStatusService.GetTrainingStatusesAsSelectItemAsync();

            Assert.IsNotNull(result);
            Assert.AreEqual(3, result.Count); 
            Assert.IsTrue(result.Any(ts => ts.Text == "Scheduled"));
            Assert.IsTrue(result.Any(ts => ts.Text == "In Progress"));
            Assert.IsTrue(result.Any(ts => ts.Text == "Completed"));

            Assert.AreEqual("1", result.FirstOrDefault(ts => ts.Text == "Scheduled")?.Value);
            Assert.AreEqual("2", result.FirstOrDefault(ts => ts.Text == "In Progress")?.Value);
            Assert.AreEqual("3", result.FirstOrDefault(ts => ts.Text == "Completed")?.Value);
        }
    }
}
