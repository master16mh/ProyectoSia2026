using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoSia2026.BD.Data.Entities
{
    public class RequisitoSeguridad
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }
        public bool EsObligatorio { get; set; }
    }
}
