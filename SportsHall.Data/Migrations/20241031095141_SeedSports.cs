using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SportsHall.Data.Migrations
{
    /// <inheritdoc />
    public partial class SeedSports : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Sports",
                columns: new[] { "Id", "Description", "ImageUrl", "MaxParticipants", "Name" },
                values: new object[,]
                {
                    { 1, "Zumba is a Latin-inspired dance workout that instructors say is primarily an aerobic workout — and it's all about having fun. Few exercise classes have had Zumba's staying power.", null, 30, "Zumba" },
                    { 2, "Indoor cycling, often called spinning, is a form of exercise with classes focusing on endurance, strength, intervals, high intensity (race days) and recovery, and involves using a special stationary exercise bicycle with a weighted flywheel in a classroom setting.", null, 20, "Spinning" },
                    { 3, "Yoga as exercise is a physical activity consisting mainly of postures, often connected by flowing sequences, sometimes accompanied by breathing exercises, and frequently ending with relaxation lying down or meditation.", null, 5, "Yoga" },
                    { 4, "CrossFit is focused on constantly varied high-intensity functional movement, drawing on categories and exercises such as calisthenics, Olympic-style weightlifting, powerlifting, strongman-type events, plyometrics, bodyweight exercises, indoor rowing, aerobic exercise, running, and swimming.", null, 14, "CrossFit" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Sports",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Sports",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Sports",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Sports",
                keyColumn: "Id",
                keyValue: 4);
        }
    }
}
