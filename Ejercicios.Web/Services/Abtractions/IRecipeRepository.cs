using Ejercicios.Web.Data.Entities;

namespace Ejercicios.Web.Data.Abstractions
{
    public interface IRecipeRepository
    {
        Task<IEnumerable<Recipe>> GetAllAsync(string? search, int? categoryId);
        Task<Recipe?> GetByIdAsync(int id);
        Task AddAsync(Recipe recipe, List<string> ingredients);
        Task UpdateAsync(Recipe recipe, List<string> ingredients);
        Task DeleteAsync(Recipe recipe);
        Task<List<RecipeCategory>> GetCategoriesAsync();
    }
}
