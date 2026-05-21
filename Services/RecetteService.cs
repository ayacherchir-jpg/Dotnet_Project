using Microsoft.EntityFrameworkCore;
using NutritionRecettes.Data;
using NutritionRecettes.Models;

namespace NutritionRecettes.Services;

public class RecetteService : IRecetteService
{
    private readonly AppDbContext _context;

    public RecetteService(AppDbContext context)
    {
        _context = context;
    }

    public static readonly List<string> Categories = new()
        { "Petit-déjeuner", "Déjeuner", "Dîner", "Dessert" };

    public static readonly List<string> TypesCuisine = new()
        { "Tunisienne", "Française", "Italienne", "Méditerranéenne", "Orientale", "Autre" };

    // ───────────────────────────────
    // CRUD ASYNC
    // ───────────────────────────────

    public async Task<List<Recette>> GetAllAsync()
    {
        return await _context.Recettes
            .Include(r => r.Ingredients)
                .ThenInclude(ri => ri.Ingredient)
            .OrderBy(r => r.Nom)
            .ToListAsync();
    }

    public async Task<Recette?> GetByIdAsync(int id)
    {
        return await _context.Recettes
            .Include(r => r.Ingredients)
                .ThenInclude(ri => ri.Ingredient)
            .FirstOrDefaultAsync(r => r.Id == id);
    }

    public async Task AjouterAsync(Recette recette)
    {
        foreach (var ri in recette.Ingredients)
        {
            _context.Attach(ri.Ingredient);
            ri.IngredientId = ri.Ingredient.Id;
        }

        await _context.Recettes.AddAsync(recette);
        await _context.SaveChangesAsync();
    }

    public async Task ModifierAsync(Recette recette)
{
    var recetteExistante = await _context.Recettes
        .Include(r => r.Ingredients)
        .FirstOrDefaultAsync(r => r.Id == recette.Id);

    if (recetteExistante == null)
        return;

    // Mise à jour des infos simples
    recetteExistante.Nom = recette.Nom;
    recetteExistante.Description = recette.Description;
    recetteExistante.NbPersonnes = recette.NbPersonnes;
    recetteExistante.Categorie = recette.Categorie;
    recetteExistante.TypeCuisine = recette.TypeCuisine;

    // Supprimer anciens ingrédients
    _context.RecetteIngredients.RemoveRange(recetteExistante.Ingredients);

    // Ajouter nouveaux ingrédients
    recetteExistante.Ingredients = recette.Ingredients
        .Select(ri => new RecetteIngredient
        {
            IngredientId = ri.Ingredient.Id,
            Quantite = ri.Quantite,
            RecetteId = recette.Id
        })
        .ToList();

    await _context.SaveChangesAsync();
}

    public async Task SupprimerAsync(int id)
    {
        var r = await _context.Recettes.FindAsync(id);

        if (r != null)
        {
            _context.Recettes.Remove(r);
            await _context.SaveChangesAsync();
        }
    }

    // ───────────────────────────────
    // ANALYTICS (optimisé async)
    // ───────────────────────────────

    public async Task<Dictionary<string, int>> RepartitionParCategorie()
    {
        var recettes = await GetAllAsync();

        return Categories.ToDictionary(
            c => c,
            c => recettes.Count(r => r.Categorie == c)
        );
    }

    public async Task<Dictionary<string, int>> RepartitionParTypeCuisine()
    {
        var recettes = await GetAllAsync();

        return recettes
            .GroupBy(r => r.TypeCuisine)
            .ToDictionary(g => g.Key, g => g.Count());
    }

    public async Task<Dictionary<string, double>> CaloriesMoyennesParCategorie()
    {
        var recettes = await GetAllAsync();

        return Categories
            .Where(c => recettes.Any(r => r.Categorie == c))
            .ToDictionary(
                c => c,
                c => recettes
                    .Where(r => r.Categorie == c)
                    .Average(r => r.CaloriesParPersonne)
            );
    }
}