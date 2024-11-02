using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SportsHall.Data.Migrations
{
    /// <inheritdoc />
    public partial class RenamePropertyInTrainings : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Duartion",
                table: "Trainings",
                newName: "Duration");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Duration",
                table: "Trainings",
                newName: "Duartion");
        }
    }
}
