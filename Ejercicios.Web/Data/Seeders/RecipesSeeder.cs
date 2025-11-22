using Ejercicios.Web.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Ejercicios.Web.Data.Seeders
{
    public class RecipesSeeder
    {
        private readonly DataContext _context;

        public RecipesSeeder(DataContext context)
        {
            _context = context;
        }

        public async Task SeedAsync()
        {
            await SeedCategoriesAsync();
            await SeedRecipesAsync();
        }

        private async Task SeedCategoriesAsync()
        {
            if (!await _context.RecipeCategories.AnyAsync())
            {
                var categories = new List<RecipeCategory>
                {
                    new RecipeCategory { Name = "Postres" },
                    new RecipeCategory { Name = "Pastas" },
                    new RecipeCategory { Name = "Carnes" },
                    new RecipeCategory { Name = "Sopas" },
                    new RecipeCategory { Name = "Ensaladas" },
                    new RecipeCategory { Name = "Desayunos" }
                };

                _context.RecipeCategories.AddRange(categories);
                await _context.SaveChangesAsync();
            }
        }

        private async Task SeedRecipesAsync()
        {
            if (!await _context.Recipes.AnyAsync())
            {
                // Obtener categorías creadas
                var postres = await _context.RecipeCategories.FirstAsync(c => c.Name == "Postres");
                var pastas = await _context.RecipeCategories.FirstAsync(c => c.Name == "Pastas");

                var recipes = new List<Recipe>
                {
                    new Recipe
                    {
                        Title = "Brownies de Chocolate",
                        Description = "Brownies húmedos y deliciosos hechos con cacao y nueces.",
                        CategoryId = postres.Id
                    },
                    new Recipe
                    {
                        Title = "Pasta Alfredo",
                        Description = "Pasta en salsa cremosa de queso parmesano.",
                        CategoryId = pastas.Id
                    }
                };

                _context.Recipes.AddRange(recipes);
                await _context.SaveChangesAsync();

                // Ingredientes de ejemplo
                var ingredients = new List<RecipeIngredient>
                {
                    new RecipeIngredient { RecipeId = recipes[0].Id, Ingredient = "Harina" },
                    new RecipeIngredient { RecipeId = recipes[0].Id, Ingredient = "Cacao" },
                    new RecipeIngredient { RecipeId = recipes[0].Id, Ingredient = "Huevos" },
                    new RecipeIngredient { RecipeId = recipes[0].Id, Ingredient = "Nueces" },

                    new RecipeIngredient { RecipeId = recipes[1].Id, Ingredient = "Pasta" },
                    new RecipeIngredient { RecipeId = recipes[1].Id, Ingredient = "Crema de leche" },
                    new RecipeIngredient { RecipeId = recipes[1].Id, Ingredient = "Queso parmesano" },
                    new RecipeIngredient { RecipeId = recipes[1].Id, Ingredient = "Mantequilla" }
                };

                _context.RecipeIngredients.AddRange(ingredients);
                await _context.SaveChangesAsync();
            }
        }
    }
}
