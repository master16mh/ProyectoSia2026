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
        [Required(ErrorMessage = "El nombre del contacto es obligatorio")]
        public string Nombre { get; set; }
        [Required(ErrorMessage = "El apellido del contacto es obligatorio")]
        public string Apellido { get; set; }
        [Required(ErrorMessage = "El DNI del contacto es obligatorio")]
        public string DNI { get; set; }
        [Required(ErrorMessage = "El email del contacto es obligatorio")]
        public string Email { get; set; }
        [Required(ErrorMessage = "El teléfono del contacto es obligatorio")]
        public string Telefono { get; set; }

        [Required(ErrorMessage = "El cargo del contacto es obligatorio")]
        public string Cargo { get; set; }
    }
}
