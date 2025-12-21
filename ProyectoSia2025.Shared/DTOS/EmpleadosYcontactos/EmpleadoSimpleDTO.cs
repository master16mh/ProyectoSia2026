using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoSia2025.Shared.DTOS
{
    public class EmpleadoSimpleDTO
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }

        // Opcional dependiendo del sistema
        public string? Puesto { get; set; }
    }
}
