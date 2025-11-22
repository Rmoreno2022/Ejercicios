using System.ComponentModel.DataAnnotations;

namespace Ejercicios.Web.DTOs
{
    public class ToggleMaterialStatusDTO
    {
        [Required(ErrorMessage = "El campo {0} es requerido.")]
        public Guid MaterialId { get; set; }

        public bool Hide { get; set; } = true;
    }
}
