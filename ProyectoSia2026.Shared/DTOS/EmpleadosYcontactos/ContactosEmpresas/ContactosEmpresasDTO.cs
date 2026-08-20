using ProyectoSia2026.Shared.ENUM;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoSia2026.Shared.DTOS.ContactosEmpresas
{
    public class ContactosEmpresasDTO
    {
        public int EmpresaId { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string DNI { get; set; }
        public string Email { get; set; }
        public string Telefono { get; set; }

        [Required(ErrorMessage = "El cargo del contacto es obligatorio")]
        public EnumCargoEmpleadoYcontacto Cargo { get; set; }
    }
}
