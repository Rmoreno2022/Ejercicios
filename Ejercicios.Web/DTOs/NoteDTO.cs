namespace Ejercicios.Web.DTOs
{
    public class NoteDTO
    {
        public int Id { get; set; }

        public string Title { get; set; } = string.Empty;

        public string Content { get; set; } = string.Empty;

        public int NoteCategoryId { get; set; }

        public string? CategoryName { get; set; }

        public DateTime CreatedAt { get; set; }
    }
}
