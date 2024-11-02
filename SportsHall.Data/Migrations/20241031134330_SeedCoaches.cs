using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SportsHall.Data.Migrations
{
    /// <inheritdoc />
    public partial class SeedCoaches : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Coaches",
                columns: new[] { "Id", "Email", "Expirience", "FirstName", "ImageUrl", "LastName", "Phone" },
                values: new object[,]
                {
                    { 1, "vanya89@gmail.com", "Vanya is a passionate fitness professional with over five years of experience in group fitness instruction, specializing in Zumba and Spinning. With a vibrant personality and an infectious enthusiasm for fitness, Jessica creates an uplifting and energetic environment in her classes.", "Vanya", null, "Ivanova", "0885222111" },
                    { 2, "ivoPetkov@gmail.com", "Ivaylo is a dedicated CrossFit coach with over six years of experience in the fitness industry. His passion for high-intensity training and commitment to functional fitness has transformed the lives of countless athletes and fitness enthusiasts.", "Ivaylo", null, "Petkov", "0883212121" },
                    { 3, "Sonya@gmail.com", "Sonya  is a highly experienced yoga instructor with over ten years of dedicated practice and teaching experience. Her journey with yoga began as a way to find inner balance and mindfulness, which she now shares with her students, guiding them toward a holistic approach to wellness.", "Sonya", null, "Stamatova", "0883212122" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Coaches",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Coaches",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Coaches",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
