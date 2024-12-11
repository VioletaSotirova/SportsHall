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
    public class SportServiceTests
    {
        private SportsHallDbContext dbContext;
        private IRepository<Sport, int> sportRepository;
        private ISportService sportService;

        [SetUp]
        public void Setup()
        {
            ConfigureAutoMapper();

            var options = new DbContextOptionsBuilder<SportsHallDbContext>()
                .UseInMemoryDatabase(databaseName: "TestDb")
                .Options;

            dbContext = new SportsHallDbContext(options);

            sportRepository = new BaseRepository<Sport, int>(dbContext);
            sportService = new SportService(sportRepository);

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

            dbContext.SaveChanges();
        }

        [TearDown]
        public void TearDown()
        {
            dbContext.Database.EnsureDeleted();
            dbContext.Dispose();
        }

        [Test]
        public async Task GetAllAsync_ShouldReturnAllSports()
        {
            var result = await sportService.GetAllAsync();

            Assert.IsNotNull(result);
            Assert.AreEqual(2, result.Count());
            Assert.IsTrue(result.Any(s => s.Name == "Football"));
            Assert.IsTrue(result.Any(s => s.Name == "Basketball"));
        }

        [Test]
        public async Task CreateAsync_ShouldAddNewSport()
        {
            var newSport = new SportEditViewModel
            {
                Name = "Tennis",
                Description = "A racket sport played individually or in pairs.",
                MaxParticipants = 2,
                ImageUrl = "https://example.com/tennis.jpg"
            };

            var createdSport = await sportService.CreateAsync(newSport);

            var allSports = dbContext.Sports.ToList();
            Assert.AreEqual(3, allSports.Count); 
            Assert.IsTrue(allSports.Any(s => s.Name == "Tennis"));
        }

        [Test]
        public async Task DeleteAsync_ShouldRemoveSport()
        {
            await sportService.DeleteAsync(1);

            var allSports = dbContext.Sports.ToList();
            Assert.AreEqual(1, allSports.Count);
            Assert.IsFalse(allSports.Any(s => s.Id == 1));
        }

        [Test]
        public async Task UpdateSportAsync_ShouldUpdateSportDetails()
        {
            var updateModel = new SportEditViewModel
            {
                Id = 1,
                Name = "Updated Football",
                Description = "Updated description for football.",
                MaxParticipants = 24,
                ImageUrl = "https://example.com/updated-football.jpg"
            };

            await sportService.UpdateSportAsync(updateModel);

            var updatedSport = dbContext.Sports.FirstOrDefault(s => s.Id == 1);
            Assert.IsNotNull(updatedSport);
            Assert.AreEqual("Updated Football", updatedSport.Name);
            Assert.AreEqual("Updated description for football.", updatedSport.Description);
            Assert.AreEqual(24, updatedSport.MaxParticipants);
        }
        private void ConfigureAutoMapper()
        {
            AutoMapperConfig.RegisterMappings(
                typeof(SportsViewModel).Assembly,
                typeof(Sport).Assembly);
        }
    }
}
