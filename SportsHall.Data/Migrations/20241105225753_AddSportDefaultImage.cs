using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SportsHall.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddSportDefaultImage : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "ImageUrl",
                table: "Sports",
                type: "nvarchar(2083)",
                maxLength: 2083,
                nullable: true,
                defaultValue: "/images/defaultSportImage.jpg",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "ImageUrl",
                table: "Sports",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(2083)",
                oldMaxLength: 2083,
                oldNullable: true,
                oldDefaultValue: "/images/defaultSportImage.jpg");
        }
    }
}
