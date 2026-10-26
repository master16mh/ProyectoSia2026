using ProyectoSia2026.Shared.ENUM;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoSia2026.Shared.DTOS.EmpleadosPropios
{
    public class EmpleadoPropioDTO
    {
        public int Id { get; set; }
        public int EmpresaId {  get; set; }
        public int CargoId { get; set; }
        [Required(ErrorMessage = "El nombre del empleado es obligatorio")]
        public string Nombre { get; set; }
        [Required(ErrorMessage = "El apellido del empleado es obligatorio")]
        public string Apellido { get; set; }
        [Required(ErrorMessage = "El DNI del empleado es obligatorio")]
        public string DNI { get; set; }
        [Required(ErrorMessage = "El email del empleado es obligatorio")]
        public string Email { get; set; }
        [Required(ErrorMessage = "El teléfono del empleado es obligatorio")]
        public string Telefono { get; set; }
        [Required(ErrorMessage = "La dirección del empleado es obligatoria")]
        public string DireccionEmpleado { get; set; }

        [Required(ErrorMessage = "El cargo del empleado es obligatorio")]
        public string Cargo { get; set; }
    }
}
