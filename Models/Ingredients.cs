namespace NutritionRecettes.Models;

public class Ingredient
{
    public int Id { get; set; }
    public string Nom { get; set; } = "";
    public string Unite { get; set; } = "g";
    public double CaloriesParUnite { get; set; }
}