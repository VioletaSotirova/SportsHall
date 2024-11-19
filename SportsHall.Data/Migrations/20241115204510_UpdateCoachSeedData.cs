using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SportsHall.Data.Migrations
{
    /// <inheritdoc />
    public partial class UpdateCoachSeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Coaches",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Expirience", "ImageUrl" },
                values: new object[] { "Vanya is a passionate fitness professional with over five years of experience in group fitness instruction, specializing in Zumba and Spinning. With a vibrant personality and an infectious enthusiasm for fitness, Vanya creates an uplifting and energetic environment in her classes.", "/images/Vanya.jpg" });

            migrationBuilder.UpdateData(
                table: "Coaches",
                keyColumn: "Id",
                keyValue: 2,
                column: "ImageUrl",
                value: "/images/Ivaylo.jpg");

            migrationBuilder.UpdateData(
                table: "Coaches",
                keyColumn: "Id",
                keyValue: 3,
                column: "ImageUrl",
                value: "/images/Sonya.jpg");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Coaches",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Expirience", "ImageUrl" },
                values: new object[] { "Vanya is a passionate fitness professional with over five years of experience in group fitness instruction, specializing in Zumba and Spinning. With a vibrant personality and an infectious enthusiasm for fitness, Jessica creates an uplifting and energetic environment in her classes.", "/images/NoPhoto.jpg" });

            migrationBuilder.UpdateData(
                table: "Coaches",
                keyColumn: "Id",
                keyValue: 2,
                column: "ImageUrl",
                value: "/images/NoPhoto.jpg");

            migrationBuilder.UpdateData(
                table: "Coaches",
                keyColumn: "Id",
                keyValue: 3,
                column: "ImageUrl",
                value: "/images/NoPhoto.jpg");
        }
    }
}
