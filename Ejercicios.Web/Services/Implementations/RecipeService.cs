using AutoMapper;
using Ejercicios.Web.Data.Abstractions;
using Ejercicios.Web.Data.Entities;
using Ejercicios.Web.DTOs;
using Ejercicios.Web.Services.Abstractions;

namespace Ejercicios.Web.Services.Implementations
{
    public class RecipeService : IRecipeService
    {
        private readonly IRecipeRepository _repo;
        private readonly IMapper _mapper;

        public RecipeService(IRecipeRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<IEnumerable<RecipeDTO>> GetAllAsync(string? search, int? categoryId)
        {
            var recipes = await _repo.GetAllAsync(search, categoryId);

            return recipes.Select(r => new RecipeDTO
            {
                Id = r.Id,
                Title = r.Title,
                Description = r.Description,
                CategoryId = r.CategoryId,
                Ingredients = r.Ingredients.Select(i => i.Ingredient).ToList()
            });
        }

        public async Task<RecipeDTO?> GetByIdAsync(int id)
        {
            var r = await _repo.GetByIdAsync(id);
            if (r == null) return null;

            return new RecipeDTO
            {
                Id = r.Id,
                Title = r.Title,
                Description = r.Description,
                CategoryId = r.CategoryId,
                Ingredients = r.Ingredients.Select(i => i.Ingredient).ToList()
            };
        }

        public async Task CreateAsync(RecipeDTO dto)
        {
            var recipe = new Recipe
            {
                Title = dto.Title,
                Description = dto.Description,
                CategoryId = dto.CategoryId
            };

            await _repo.AddAsync(recipe, dto.Ingredients);
        }

        public async Task UpdateAsync(RecipeDTO dto)
        {
            var recipe = await _repo.GetByIdAsync(dto.Id);
            if (recipe == null) return;

            recipe.Title = dto.Title;
            recipe.Description = dto.Description;
            recipe.CategoryId = dto.CategoryId;

            await _repo.UpdateAsync(recipe, dto.Ingredients);
        }

        public async Task DeleteAsync(int id)
        {
            var recipe = await _repo.GetByIdAsync(id);
            if (recipe != null)
                await _repo.DeleteAsync(recipe);
        }

        public async Task<IEnumerable<RecipeCategoryDTO>> GetCategoriesAsync()
        {
            var cats = await _repo.GetCategoriesAsync();
            return cats.Select(c => new RecipeCategoryDTO { Id = c.Id, Name = c.Name });
        }
    }
}
