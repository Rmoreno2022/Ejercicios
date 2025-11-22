namespace Ejercicios.Web.Data.Entities
{
    public class RecipeIngredient
    {
        public int Id { get; set; }

        public int RecipeId { get; set; }
        public Recipe Recipe { get; set; }

        public string Ingredient { get; set; } = string.Empty;
    }
}
