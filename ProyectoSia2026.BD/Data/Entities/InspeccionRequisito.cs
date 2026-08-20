using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoSia2026.BD.Data.Entities
{
    public class InspeccionRequisito
    {
        [Key]
        public int Id { get; set; }
        public int InspeccionId { get; set; }
        public Inspecciones Inspeccion { get; set; }

        public int RequisitoSeguridadId { get; set; }
        public RequisitoSeguridad RequisitoSeguridad { get; set; }

        public bool Cumple { get; set; }
        public string? Observacion { get; set; }
    }
}
