using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Migrations
{
    /// <inheritdoc />
    public partial class EditEntities : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Value",
                table: "PhysicalActivityTypes",
                newName: "CoeffValue");

            migrationBuilder.RenameColumn(
                name: "Amount",
                table: "Ingredients",
                newName: "UnitsAmount");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CoeffValue",
                table: "PhysicalActivityTypes",
                newName: "Value");

            migrationBuilder.RenameColumn(
                name: "UnitsAmount",
                table: "Ingredients",
                newName: "Amount");
        }
    }
}
