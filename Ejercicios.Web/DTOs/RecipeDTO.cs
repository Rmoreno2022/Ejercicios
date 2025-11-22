using System.Collections.Generic;

namespace Ejercicios.Web.DTOs
{
    public class RecipeDTO
    {
        public int Id { get; set; }

        public string Title { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;

        public int CategoryId { get; set; }

        public List<string> Ingredients { get; set; } = new();
    }
}
