using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoSia2026.BD.Data.Entities
{
    public class NoConformidad
    {
        public int Id { get; set; }

        public int InspeccionId { get; set; }
        public Inspecciones Inspeccion { get; set; }

        public string Descripcion { get; set; }

        public DateTime FechaLimiteCorreccion { get; set; }

        public bool Corregida { get; set; }

        public DateTime? FechaCorreccion { get; set; }
    }
}
