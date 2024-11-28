using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SportsHall.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddTrainingsStatusesTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Status",
                table: "Trainings");

            migrationBuilder.AddColumn<int>(
                name: "TrainingStatusId",
                table: "Trainings",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "TrainingsStatuses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrainingsStatuses", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "Trainings",
                keyColumn: "Id",
                keyValue: 1,
                column: "TrainingStatusId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Trainings",
                keyColumn: "Id",
                keyValue: 2,
                column: "TrainingStatusId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Trainings",
                keyColumn: "Id",
                keyValue: 3,
                column: "TrainingStatusId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Trainings",
                keyColumn: "Id",
                keyValue: 4,
                column: "TrainingStatusId",
                value: 1);

            migrationBuilder.InsertData(
                table: "TrainingsStatuses",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Active" },
                    { 2, "Completed" },
                    { 3, "Cancelled" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Trainings_TrainingStatusId",
                table: "Trainings",
                column: "TrainingStatusId");

            migrationBuilder.AddForeignKey(
                name: "FK_Trainings_TrainingsStatuses_TrainingStatusId",
                table: "Trainings",
                column: "TrainingStatusId",
                principalTable: "TrainingsStatuses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Trainings_TrainingsStatuses_TrainingStatusId",
                table: "Trainings");

            migrationBuilder.DropTable(
                name: "TrainingsStatuses");

            migrationBuilder.DropIndex(
                name: "IX_Trainings_TrainingStatusId",
                table: "Trainings");

            migrationBuilder.DropColumn(
                name: "TrainingStatusId",
                table: "Trainings");

            migrationBuilder.AddColumn<bool>(
                name: "Status",
                table: "Trainings",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "Trainings",
                keyColumn: "Id",
                keyValue: 1,
                column: "Status",
                value: false);

            migrationBuilder.UpdateData(
                table: "Trainings",
                keyColumn: "Id",
                keyValue: 2,
                column: "Status",
                value: false);

            migrationBuilder.UpdateData(
                table: "Trainings",
                keyColumn: "Id",
                keyValue: 3,
                column: "Status",
                value: false);

            migrationBuilder.UpdateData(
                table: "Trainings",
                keyColumn: "Id",
                keyValue: 4,
                column: "Status",
                value: false);
        }
    }
}
