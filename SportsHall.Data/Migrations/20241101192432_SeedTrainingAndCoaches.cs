using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SportsHall.Data.Migrations
{
    /// <inheritdoc />
    public partial class SeedTrainingAndCoaches : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Location",
                table: "Trainings",
                type: "nvarchar(150)",
                maxLength: 150,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.InsertData(
                table: "SportsCoaches",
                columns: new[] { "CoachId", "SportId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 1, 2 },
                    { 2, 4 },
                    { 3, 3 }
                });

            migrationBuilder.InsertData(
                table: "Trainings",
                columns: new[] { "Id", "AvailableSpot", "CoachId", "Duration", "Location", "SportId", "Start", "Status" },
                values: new object[,]
                {
                    { 1, 30, 1, 50, "Plovdiv, bul.Hristo Botev 4, DynamicFitCenter, Hall 3", 1, new DateTime(2024, 10, 31, 8, 30, 0, 0, DateTimeKind.Unspecified), false },
                    { 2, 20, 1, 30, "Plovdiv, bul.Hristo Botev 4, DynamicFitCenter, Hall 1", 2, new DateTime(2024, 10, 31, 10, 30, 0, 0, DateTimeKind.Unspecified), false },
                    { 3, 5, 3, 50, "Plovdiv, bul.Hristo Botev 4, DynamicFitCenter, Hall 5", 3, new DateTime(2024, 10, 31, 11, 0, 0, 0, DateTimeKind.Unspecified), false },
                    { 4, 14, 2, 45, "Plovdiv, bul.Hristo Botev 4, DynamicFitCenter, Hall 5", 4, new DateTime(2024, 10, 31, 11, 50, 0, 0, DateTimeKind.Unspecified), false }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "SportsCoaches",
                keyColumns: new[] { "CoachId", "SportId" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "SportsCoaches",
                keyColumns: new[] { "CoachId", "SportId" },
                keyValues: new object[] { 1, 2 });

            migrationBuilder.DeleteData(
                table: "SportsCoaches",
                keyColumns: new[] { "CoachId", "SportId" },
                keyValues: new object[] { 2, 4 });

            migrationBuilder.DeleteData(
                table: "SportsCoaches",
                keyColumns: new[] { "CoachId", "SportId" },
                keyValues: new object[] { 3, 3 });

            migrationBuilder.DeleteData(
                table: "Trainings",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Trainings",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Trainings",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Trainings",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.AlterColumn<string>(
                name: "Location",
                table: "Trainings",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(150)",
                oldMaxLength: 150);
        }
    }
}
