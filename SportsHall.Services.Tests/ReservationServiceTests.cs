using Microsoft.EntityFrameworkCore;

using SportsHall.Data;
using SportsHall.Data.Models;
using SportsHall.Services.Data;
using SportsHall.Data.Repository;

namespace SportsHall.Services.Tests
{
    [TestFixture]
    public class ReservationServiceTests : IDisposable
    {
        private SportsHallDbContext dbContext;
        private ReservationService reservationService;

        [SetUp]
        public void SetUp()
        {
            var options = new DbContextOptionsBuilder<SportsHallDbContext>()
                .UseInMemoryDatabase(databaseName: "SportsHallTestDb")
                .Options;

            dbContext = new SportsHallDbContext(options);

            reservationService = new ReservationService(new ReservationRepository(dbContext));

            SeedTestData();
        }

        private void SeedTestData()
        {
            var sport = new Sport { Name = "Football", Description = "Team sport played with a ball" };
            var coach = new Coach { FirstName = "John", LastName = "Doe", Expirience = "10 years of coaching experience", Phone = "123456789", Email = "john.doe@example.com", ImageUrl = "imageUrl" };
            var training1 = new Training
            {
                Sport = sport,
                Coach = coach,
                Start = DateTime.Now.AddDays(1),
                Location = "Football Field",
                Duration = 90
            };
            var training2 = new Training
            {
                Sport = new Sport { Name = "Tennis", Description = "Individual sport played with a racket" },
                Coach = new Coach { FirstName = "Jane", LastName = "Smith", Expirience = "5 years of coaching experience", Phone = "987654321", Email = "jane.smith@example.com", ImageUrl = "imageUrl" },
                Start = DateTime.Now.AddDays(2),
                Location = "Tennis Court",
                Duration = 60
            };

            var reservation1 = new Reservation
            {
                UserId = 1, 
                Training = training1,
                CreatedOn = DateTime.Now
            };
            var reservation2 = new Reservation
            {
                UserId = 1, 
                Training = training2,
                CreatedOn = DateTime.Now
            };

            dbContext.AddRange(sport, coach, training1, training2, reservation1, reservation2);
            dbContext.SaveChanges();
        }

        [Test]
        public async Task GetUserReservationsAsync_ShouldReturnCorrectReservations()
        {
            string userId = "1";

            var result = await reservationService.GetUserReservationsAsync(userId);

            Assert.IsNotNull(result);
            Assert.AreEqual(2, result.Count()); 

            Assert.AreEqual("Football", result.First().SportName);
            Assert.AreEqual("John Doe", result.First().CoachName);

            Assert.AreEqual("Tennis", result.Last().SportName);
            Assert.AreEqual("Jane Smith", result.Last().CoachName);
        }
        public void Dispose()
        {
            dbContext?.Dispose();
        }
    }
}
