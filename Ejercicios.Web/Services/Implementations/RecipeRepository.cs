using Microsoft.EntityFrameworkCore;
using Ejercicios.Web.Data;
using Ejercicios.Web.Data.Abstractions;
using Ejercicios.Web.Data.Entities;

namespace Ejercicios.Web.Services.Implementations
{
    public class RecipeRepository : IRecipeRepository
    {
        private readonly DataContext _context;

        public RecipeRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Recipe>> GetAllAsync(string? search, int? categoryId)
        {
            var query = _context.Recipes
                .Include(r => r.Category)
                .Include(r => r.Ingredients)
                .AsQueryable();

            if (!string.IsNullOrWhiteSpace(search))
                query = query.Where(r => r.Title.Contains(search) || r.Description.Contains(search));

            if (categoryId.HasValue)
                query = query.Where(r => r.CategoryId == categoryId.Value);

            return await query.ToListAsync();
        }

        public async Task<Recipe?> GetByIdAsync(int id)
        {
            return await _context.Recipes
                .Include(r => r.Category)
                .Include(r => r.Ingredients)
                .FirstOrDefaultAsync(r => r.Id == id);
        }

        public async Task AddAsync(Recipe recipe, List<string> ingredients)
        {
            _context.Recipes.Add(recipe);
            await _context.SaveChangesAsync();

            foreach (var ing in ingredients)
            {
                _context.RecipeIngredients.Add(new RecipeIngredient
                {
                    RecipeId = recipe.Id,
                    Ingredient = ing
                });
            }

            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Recipe recipe, List<string> ingredients)
        {
            _context.Recipes.Update(recipe);

            var existing = _context.RecipeIngredients.Where(i => i.RecipeId == recipe.Id);
            _context.RecipeIngredients.RemoveRange(existing);

            foreach (var ing in ingredients)
            {
                _context.RecipeIngredients.Add(new RecipeIngredient
                {
                    RecipeId = recipe.Id,
                    Ingredient = ing
                });
            }

            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Recipe recipe)
        {
            _context.Recipes.Remove(recipe);
            await _context.SaveChangesAsync();
        }

        public async Task<List<RecipeCategory>> GetCategoriesAsync()
        {
            return await _context.RecipeCategories.ToListAsync();
        }
    }
}
