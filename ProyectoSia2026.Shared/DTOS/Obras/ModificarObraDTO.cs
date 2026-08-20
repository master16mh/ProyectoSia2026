using ProyectoSia2026.Shared.ENUM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoSia2026.Shared.DTOS.Obras
{
    public class ModificarObraDTO
    {
        public int EmpresaId { get; set; }
        public string NombreObra { get; set; }
        public string Descripcion { get; set; }
        public string Ubicacion { get; set; }
        public decimal Presupuesto { get; set; }
        public DateTime FechaUltimaHabilitacion { get; set; }
        public DateTime FechaVencimientoHabilitacion { get; set; }
        public string MotivoNoHabilitacion { get; set; }
        public EnumEstadoObra EstadoObra { get; set; }
    }
}
