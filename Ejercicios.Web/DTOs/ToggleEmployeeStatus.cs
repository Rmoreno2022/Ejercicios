using System;
using System.ComponentModel.DataAnnotations;

namespace Ejercicios.Web.DTOs
{
    public class ToggleEmployeeStatusDTO
    {
        [Required(ErrorMessage = "El campo {0} es requerido.")]
        public Guid EmployeeId { get; set; }

        public bool Activate { get; set; } = true; // true = activar, false = desactivar
    }
}
