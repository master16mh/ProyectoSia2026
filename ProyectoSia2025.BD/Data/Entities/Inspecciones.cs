using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoSia2025.BD.Data.Entities
{
    public class Inspecciones
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int ObraId { get; set; }
        public Obras Obra { get; set; }
        [Required]
        public DateTime FechaProgramada { get; set; }
        public DateTime? FechaRealizacion { get; set; }

        [Required]
        public string estadoInspeccion { get; set; }
        public string? Observaciones { get; set; }
        public int? EmpleadoPropioId { get; set; }
        public EmpleadosPropios? EmpleadoPropio { get; set; }
    }
}
