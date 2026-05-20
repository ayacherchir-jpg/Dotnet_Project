using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace NutritionRecettes.Migrations
{
    /// <inheritdoc />
    public partial class UpdateModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: 12);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Ingredients",
                columns: new[] { "Id", "CaloriesParUnite", "Nom", "Unite" },
                values: new object[,]
                {
                    { 1, 3.6400000000000001, "Farine de blé", "g" },
                    { 2, 3.8700000000000001, "Sucre", "g" },
                    { 3, 8.8399999999999999, "Huile d'olive", "ml" },
                    { 4, 78.0, "Œuf", "pièce" },
                    { 5, 22.0, "Tomate", "pièce" },
                    { 6, 44.0, "Oignon", "pièce" },
                    { 7, 1.6499999999999999, "Poulet (filet)", "g" },
                    { 8, 3.5, "Riz", "g" },
                    { 9, 3.71, "Pâtes", "g" },
                    { 10, 0.60999999999999999, "Lait", "ml" },
                    { 11, 7.1699999999999999, "Beurre", "g" },
                    { 12, 0.77000000000000002, "Pomme de terre", "g" }
                });
        }
    }
}
