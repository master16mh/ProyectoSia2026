using ProyectoSia2026.Shared.ENUM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoSia2026.Shared.DTOS.EmpleadosYcontactos.EmpleadosPropios
{
    public class EmpleadosPropiosListaDTO
    {
        public int Id { get; set; }
        public int EmpresaId { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public int CargoId { get; set; }
        public string Cargo { get; set; }
    }
}
