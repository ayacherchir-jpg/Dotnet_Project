using NutritionRecettes.Models;

namespace NutritionRecettes.Services;

public interface IRecetteService
{
    // CRUD
    Task<List<Recette>> GetAllAsync();

    Task<Recette?> GetByIdAsync(int id);

    Task AjouterAsync(Recette recette);

    Task ModifierAsync(Recette recette);

    Task SupprimerAsync(int id);

    // Statistiques / analytics
    Task<Dictionary<string, int>> RepartitionParCategorie();

    Task<Dictionary<string, int>> RepartitionParTypeCuisine();

    Task<Dictionary<string, double>> CaloriesMoyennesParCategorie();
}