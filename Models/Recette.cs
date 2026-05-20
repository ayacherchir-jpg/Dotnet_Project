namespace NutritionRecettes.Models;

public class Recette
{
    public int Id { get; set; }
    public string Nom { get; set; } = "";
    public string Description { get; set; } = "";
    public int NbPersonnes { get; set; } = 4;
    public string Categorie { get; set; } = "Déjeuner";
    public string TypeCuisine { get; set; } = "Tunisienne";
    public List<RecetteIngredient> Ingredients { get; set; } = new();

    public double CaloriesTotales => Ingredients.Sum(ri => ri.CaloriesTotal);
    public double CaloriesParPersonne => NbPersonnes > 0 ? CaloriesTotales / NbPersonnes : 0;
}