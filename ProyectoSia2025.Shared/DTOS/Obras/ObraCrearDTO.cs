using ProyectoSia2025.Shared.ENUM;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoSia2025.Shared.DTOS.Obras
{
    public class CrearObraDTO
    {
        public int EmpresaId { get; set; }

        [Required]
        public required string NombreObra { get; set; }

        public string? Descripcion { get; set; }

        [Required]
        public required string Ubicacion { get; set; }

        [Required]
        public decimal Presupuesto { get; set; }

        public DateTime? FechaUltimaHabilitacion { get; set; }
        public DateTime? FechaVencimientoHabilitacion { get; set; }
        public EnumEstadoObra Estado { get; set; }

        public string? MotivoNoHabilitacion { get; set; }
    }
}
