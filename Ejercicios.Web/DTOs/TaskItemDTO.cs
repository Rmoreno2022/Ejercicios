using System.ComponentModel.DataAnnotations;

namespace Ejercicios.Web.DTOs
{
    public class TaskItemDTO
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El título es obligatorio")]
        [StringLength(100)]
        public string Title { get; set; } = string.Empty;

        [StringLength(300)]
        public string? Description { get; set; }

        public bool IsCompleted { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
