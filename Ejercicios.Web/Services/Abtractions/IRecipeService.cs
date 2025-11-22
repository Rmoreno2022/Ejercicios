using Ejercicios.Web.DTOs;

namespace Ejercicios.Web.Services.Abstractions
{
    public interface IRecipeService
    {
        Task<IEnumerable<RecipeDTO>> GetAllAsync(string? search, int? categoryId);
        Task<RecipeDTO?> GetByIdAsync(int id);
        Task CreateAsync(RecipeDTO dto);
        Task UpdateAsync(RecipeDTO dto);
        Task DeleteAsync(int id);
        Task<IEnumerable<RecipeCategoryDTO>> GetCategoriesAsync();
    }
}
