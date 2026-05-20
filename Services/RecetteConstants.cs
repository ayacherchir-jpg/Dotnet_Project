namespace NutritionRecettes.Services;

public static class RecetteConstants
{
    public static readonly List<string> Categories = new()
    {
        "Petit-déjeuner",
        "Déjeuner",
        "Dîner",
        "Dessert"
    };

    public static readonly List<string> TypesCuisine = new()
    {
        "Tunisienne",
        "Française",
        "Italienne",
        "Méditerranéenne",
        "Orientale",
        "Autre"
    };
}