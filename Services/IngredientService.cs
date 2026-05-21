
using NutritionRecettes.Data;
using NutritionRecettes.Models;
using Microsoft.EntityFrameworkCore;


namespace NutritionRecettes.Services;

public class IngredientService : IIngredientService
{
    private readonly AppDbContext _context;

    public IngredientService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<List<Ingredient>> GetAllAsync()
    {
        return await _context.Ingredients
            .OrderBy(i => i.Nom)
            .ToListAsync();
    }

    public async Task<Ingredient?> GetByIdAsync(int id)
    {
        return await _context.Ingredients.FindAsync(id);
    }

    public async Task AjouterAsync(Ingredient ingredient)
    {
        _context.Ingredients.Add(ingredient);
        await _context.SaveChangesAsync();
    }

    public async Task ModifierAsync(Ingredient ingredient)
{
    var existingIngredient = await _context.Ingredients.FindAsync(ingredient.Id);

    if (existingIngredient != null)
    {
        existingIngredient.Nom = ingredient.Nom;
        existingIngredient.Unite = ingredient.Unite;
        existingIngredient.CaloriesParUnite = ingredient.CaloriesParUnite;

        await _context.SaveChangesAsync();
    }
}

    public async Task SupprimerAsync(int id)
    {
        var ing = await _context.Ingredients.FindAsync(id);

        if (ing != null)
        {
            _context.Ingredients.Remove(ing);
            await _context.SaveChangesAsync();
        }
    }
}