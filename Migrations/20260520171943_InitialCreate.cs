using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace NutritionRecettes.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Ingredients",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nom = table.Column<string>(type: "TEXT", nullable: false),
                    Unite = table.Column<string>(type: "TEXT", nullable: false),
                    CaloriesParUnite = table.Column<double>(type: "REAL", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ingredients", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Recettes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nom = table.Column<string>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: false),
                    NbPersonnes = table.Column<int>(type: "INTEGER", nullable: false),
                    Categorie = table.Column<string>(type: "TEXT", nullable: false),
                    TypeCuisine = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Recettes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RecetteIngredients",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    IngredientId = table.Column<int>(type: "INTEGER", nullable: false),
                    RecetteId = table.Column<int>(type: "INTEGER", nullable: false),
                    Quantite = table.Column<double>(type: "REAL", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RecetteIngredients", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RecetteIngredients_Ingredients_IngredientId",
                        column: x => x.IngredientId,
                        principalTable: "Ingredients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RecetteIngredients_Recettes_RecetteId",
                        column: x => x.RecetteId,
                        principalTable: "Recettes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_RecetteIngredients_IngredientId",
                table: "RecetteIngredients",
                column: "IngredientId");

            migrationBuilder.CreateIndex(
                name: "IX_RecetteIngredients_RecetteId",
                table: "RecetteIngredients",
                column: "RecetteId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RecetteIngredients");

            migrationBuilder.DropTable(
                name: "Ingredients");

            migrationBuilder.DropTable(
                name: "Recettes");
        }
    }
}
