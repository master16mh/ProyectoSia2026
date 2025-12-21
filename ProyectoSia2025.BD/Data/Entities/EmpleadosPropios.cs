using ProyectoSia2025.BD.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoSia2025.BD.Data.Entities
{
    public class EmpleadosPropios
    {
        [Key]
        public int Id { get; set; }

        public int EmpresaId { get; set; }
        public Empresas Empresa { get; set; }

        [Required(ErrorMessage = "Especifique el nombre.")]
        public required string Nombre { get; set; }

        public string Apellido { get; set; }

        [Required(ErrorMessage = "Especifique el DNI.")]
        public string DNI { get; set; }

        [Required(ErrorMessage = "Especifique el TELEFONO.")]
        public required string Telefono { get; set; }

        [Required(ErrorMessage = "Especifique la DIRECCION.")]
        public required string DireccionHogarEmpleado { get; set; }

        [Required(ErrorMessage = "Especifique el cargo del EMPLEADO.")]
        public required EnumCargoEmpleadoYcontacto CargoEmpleado { get; set; }

        public ICollection<ObrasEmpleados> ObrasEmpleados { get; set; }
    }
}
