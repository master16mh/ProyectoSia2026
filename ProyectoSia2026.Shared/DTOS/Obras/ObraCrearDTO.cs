using ProyectoSia2026.Shared.ENUM;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoSia2026.Shared.DTOS.Obras
{
    public class ObraCrearDTO
    {
        public int EmpresaId { get; set; }

        [Required]
        public required string NombreObra { get; set; }

        public string? Descripcion { get; set; }

        [Required]
        public required string Ubicacion { get; set; }

        [Required]
        public decimal Presupuesto { get; set; }

        public EnumEstadoObra Estado { get; set; }
    }
}
