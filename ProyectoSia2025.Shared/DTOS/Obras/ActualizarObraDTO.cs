using ProyectoSia2025.Shared.ENUM;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoSia2025.Shared.DTOS.Obras
{
    public class ActualizarObraDTO
    {
        public int Id { get; set; }
        public string? NombreObra { get; set; }
        public string? Descripcion { get; set; }
        public string? Ubicacion { get; set; }
        public decimal? Presupuesto { get; set; }

        [Required(ErrorMessage = "El estado de la obra es obligatorio")]
        public EnumEstadoObra EstadoObra { get; set; }
    }
}
