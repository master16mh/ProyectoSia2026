using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoSia2025.BD.Data.Entities
{
    public class Diseños
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int ObraId { get; set; }
        public Obras Obra { get; set; }

        [Required]
        public int EmpleadoPropioId { get; set; }
        public EmpleadosPropios EmpleadoPropio { get; set; }

        [Required]
        public DateTime FechaCreacion { get; set; }

        [Required]
        public int Version { get; set; }

        [Required]
        public string RutaArchivo { get; set; }   

        public string NombreArchivo { get; set; } 
        public string Extension { get; set; }    
        public long TamañoBytes { get; set; }

        public string? Observaciones { get; set; }
    }
}
