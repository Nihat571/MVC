using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Carvilla.Migrations
{
    /// <inheritdoc />
    public partial class createDescColumn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Models",
                table: "cars",
                newName: "Model");

            migrationBuilder.AddColumn<string>(
                name: "Desc",
                table: "cars",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Desc",
                table: "cars");

            migrationBuilder.RenameColumn(
                name: "Model",
                table: "cars",
                newName: "Models");
        }
    }
}
