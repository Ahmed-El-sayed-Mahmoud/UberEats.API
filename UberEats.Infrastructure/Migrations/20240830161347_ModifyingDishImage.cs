using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UberEats.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ModifyingDishImage : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ImageUrl",
                table: "DishImages",
                newName: "FilePath");

            migrationBuilder.AddColumn<string>(
                name: "FileExtension",
                table: "DishImages",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "FileName",
                table: "DishImages",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<long>(
                name: "FileSizeBytes",
                table: "DishImages",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FileExtension",
                table: "DishImages");

            migrationBuilder.DropColumn(
                name: "FileName",
                table: "DishImages");

            migrationBuilder.DropColumn(
                name: "FileSizeBytes",
                table: "DishImages");

            migrationBuilder.RenameColumn(
                name: "FilePath",
                table: "DishImages",
                newName: "ImageUrl");
        }
    }
}
