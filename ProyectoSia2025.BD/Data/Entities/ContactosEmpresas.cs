using Microsoft.EntityFrameworkCore;
using ProyectoSia2025.BD.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoSia2025.BD.Data.Entities
{
    [Index(nameof(DNI), Name = "Contacto_DNI", IsUnique = true)] // Índice único en el campo DNI
    public class ContactosEmpresas
    {
        [Key]
        public int Id { get; set; }
        public int EmpresaId { get; set; } //  Clave foránea con Empresas
        public Empresas Empresa { get; set; } // Navegación

        [Required(ErrorMessage = "El Nombre de contacto es obligatorio.")]
        public string Nombre { get; set; }


        [Required(ErrorMessage = "El Apellido de contacto es obligatorio.")]
        public string Apellido { get; set; }


        [Required(ErrorMessage = "El DNI de contacto es obligatorio.")]
        public string DNI { get; set; }


        [Required(ErrorMessage = "El Email de contacto es obligatorio.")]
        public string Email { get; set; }


        [Required(ErrorMessage = "El Teléfono de contacto es obligatorio.")]
        public string Telefono { get; set; }


        [Required(ErrorMessage = "Especifique el cargo o relacion de contacto.")]
        public required EnumCargoEmpleadoYcontacto CargoContacto { get; set; }

        public ICollection<ObrasContactos> ObrasContactos { get; set; }
    }
}
