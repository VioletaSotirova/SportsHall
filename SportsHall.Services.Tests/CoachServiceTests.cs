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
    public class CoachServiceTests
    {
        private SportsHallDbContext dbContext;
        private IRepository<Coach, int> coachRepository;
        private ICoachService coachService;

        [SetUp]
        public void Setup()
        {
            ConfigureAutoMapper();
 
            var options = new DbContextOptionsBuilder<SportsHallDbContext>()
                .UseInMemoryDatabase(databaseName: "TestDb_Coach")
                .Options;

            dbContext = new SportsHallDbContext(options);

            coachRepository = new BaseRepository<Coach, int>(dbContext);
            coachService = new CoachService(coachRepository);

            dbContext.Coaches.Add(new Coach
            {
                Id = 1,
                FirstName = "John",
                LastName = "Doe",
                Expirience = "5 years of experience in basketball",
                Phone = "123456789",
                Email = "john.doe@example.com",
                ImageUrl = "https://example.com/john.jpg"
            });

            dbContext.Coaches.Add(new Coach
            {
                Id = 2,
                FirstName = "Jane",
                LastName = "Smith",
                Expirience = "10 years of experience in football", 
                Phone = "987654321",
                Email = "jane.smith@example.com",
                ImageUrl = "https://example.com/jane.jpg"
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
        public async Task GetAllAsync_ShouldReturnAllCoaches()
        {
            var result = await coachService.GetAllAsync();

            Assert.IsNotNull(result);
            Assert.AreEqual(2, result.Count());
            Assert.IsTrue(result.Any(c => c.FirstName == "John" && c.LastName == "Doe"));
            Assert.IsTrue(result.Any(c => c.FirstName == "Jane" && c.LastName == "Smith"));
        }

        [Test]
        public async Task CreateAsync_ShouldAddNewCoach()
        {
            var newCoach = new CoachEditViewModel
            {
                FirstName = "Alex",
                LastName = "Johnson",
                Expirience = "3 years of coaching experience in tennis", 
                Phone = "555555555",
                Email = "alex.johnson@example.com",
                ImageUrl = "https://example.com/alex.jpg"
            };

            var createdCoach = await coachService.CreateAsync(newCoach);

            var allCoaches = dbContext.Coaches.ToList();
            Assert.AreEqual(3, allCoaches.Count); 
            Assert.IsTrue(allCoaches.Any(c => c.FirstName == "Alex" && c.LastName == "Johnson"));
        }

        [Test]
        public async Task DeleteAsync_ShouldRemoveCoach()
        {
            await coachService.DeleteAsync(1);

            var allCoaches = dbContext.Coaches.ToList();
            Assert.AreEqual(1, allCoaches.Count);
            Assert.IsFalse(allCoaches.Any(c => c.Id == 1));
        }

        [Test]
        public async Task UpdateCoachAsync_ShouldUpdateCoachDetails()
        {
            var updateModel = new CoachEditViewModel
            {
                Id = 1,
                FirstName = "Updated John",
                LastName = "Updated Doe",
                Expirience = "Updated experience: 7 years of basketball", 
                Phone = "111222333",
                Email = "updated.john@example.com",
                ImageUrl = "https://example.com/updated-john.jpg"
            };

            await coachService.UpdateCoachAsync(updateModel);

            var updatedCoach = dbContext.Coaches.FirstOrDefault(c => c.Id == 1);
            Assert.IsNotNull(updatedCoach);
            Assert.AreEqual("Updated John", updatedCoach.FirstName);
            Assert.AreEqual("Updated Doe", updatedCoach.LastName);
            Assert.AreEqual("Updated experience: 7 years of basketball", updatedCoach.Expirience);
        }

        [Test]
        public async Task GetCoachByIdAsync_ShouldReturnCorrectCoach()
        {
            var coach = await coachService.GetCoachByIdAsync(1);

            Assert.IsNotNull(coach);
            Assert.AreEqual("John", coach.FirstName);
            Assert.AreEqual("Doe", coach.LastName);
            Assert.AreEqual("5 years of experience in basketball", coach.Expirience);
        }

        [Test]
        public async Task GetCoachesAsSelectItemAsync_ShouldReturnCorrectSelectItems()
        {
            var selectItems = await coachService.GetCoachesAsSelectItemAsync();

            Assert.IsNotNull(selectItems);
            Assert.AreEqual(2, selectItems.Count);
            Assert.IsTrue(selectItems.Any(si => si.Text == "John Doe"));
            Assert.IsTrue(selectItems.Any(si => si.Text == "Jane Smith"));
        }

        private void ConfigureAutoMapper()
        {
            AutoMapperConfig.RegisterMappings(
                typeof(CoachesViewModel).Assembly,
                typeof(Coach).Assembly);
        }
    }
}
