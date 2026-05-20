namespace NutritionRecettes.Models;

public class RecetteIngredient
{
    public int Id { get; set; }                   // clé primaire pour EF

    public int IngredientId { get; set; }         // clé étrangère
    public Ingredient Ingredient { get; set; } = new();

    public int RecetteId { get; set; }            // clé étrangère
    public double Quantite { get; set; }

    public double CaloriesTotal => Ingredient.CaloriesParUnite * Quantite;
}