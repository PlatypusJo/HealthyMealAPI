using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Migrations
{
    /// <inheritdoc />
    public partial class ChangeTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Eating",
                table: "Eating");

            migrationBuilder.RenameTable(
                name: "Eating",
                newName: "Meal");

            migrationBuilder.RenameIndex(
                name: "IX_Eating_UserId",
                table: "Meal",
                newName: "IX_Meal_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Eating_NutritionalValueId",
                table: "Meal",
                newName: "IX_Meal_NutritionalValueId");

            migrationBuilder.RenameIndex(
                name: "IX_Eating_MealTypeId",
                table: "Meal",
                newName: "IX_Meal_MealTypeId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Meal",
                table: "Meal",
                column: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Meal",
                table: "Meal");

            migrationBuilder.RenameTable(
                name: "Meal",
                newName: "Eating");

            migrationBuilder.RenameIndex(
                name: "IX_Meal_UserId",
                table: "Eating",
                newName: "IX_Eating_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Meal_NutritionalValueId",
                table: "Eating",
                newName: "IX_Eating_NutritionalValueId");

            migrationBuilder.RenameIndex(
                name: "IX_Meal_MealTypeId",
                table: "Eating",
                newName: "IX_Eating_MealTypeId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Eating",
                table: "Eating",
                column: "Id");
        }
    }
}
