using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoSia2026.Shared.DTOS.EmpleadosYcontactos.EmpleadosPropios
{
    public class EmpleadoPropioCargarDTO
    {
        public int EmpresaId { get; set; }
        public int CargoId { get; set; }

        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string DNI { get; set; }
        public string Email { get; set; }
        public string Telefono { get; set; }
        public string DireccionHogarEmpleado { get; set; }
    }
}
