using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoSia2026.BD.Data.Entities
{
    public class ObrasEmpleados
    {
        public int ObraId { get; set; }
        public Obras Obra { get; set; }

        public int EmpleadoId { get; set; }
        public EmpleadosPropios Empleado { get; set; }

        public DateTime FechaAsignacion { get; set; }
    }
}
