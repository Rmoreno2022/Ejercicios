using System.ComponentModel.DataAnnotations;

namespace Ejercicios.Web.DTOs
{
    public class ToggleOrderStatusDTO
    {
        [Required(ErrorMessage = "El campo {0} es requerido.")]
        public Guid OrderId { get; set; }

        public bool Hide { get; set; } = true;
    }
}
