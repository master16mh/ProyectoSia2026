using ProyectoSia2025.BD.Enums;
using ProyectoSia2025.BD.Migrations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoSia2025.BD.Data.Entities
{
    public class InformeInspeccion
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int InspeccionId { get; set; }
        public Inspecciones Inspeccion { get; set; }

        [Required]
        public EnumResultadoInspeccion Resultado { get; set; }

        public DateTime FechaEmision { get; set; }

        public string? Conclusiones { get; set; }

        public string? RutaPdfInforme { get; set; }
    }
}
