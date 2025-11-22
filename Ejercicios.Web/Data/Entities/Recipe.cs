using System.Collections.Generic;

namespace Ejercicios.Web.Data.Entities
{
    public class Recipe
    {
        public int Id { get; set; }

        public string Title { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;

        public int CategoryId { get; set; }
        public RecipeCategory Category { get; set; }

        public List<RecipeIngredient> Ingredients { get; set; } = new();
    }
}
