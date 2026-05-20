using NutritionRecettes.Models;

namespace NutritionRecettes.Services;

public interface IIngredientService
{
    Task<List<Ingredient>> GetAllAsync();

    Task<Ingredient?> GetByIdAsync(int id);

    Task AjouterAsync(Ingredient ingredient);

    Task ModifierAsync(Ingredient ingredient);

    Task SupprimerAsync(int id);
}