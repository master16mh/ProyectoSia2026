using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProyectoSia2025.BD.Enums;

namespace ProyectoSia2025.BD.Data.Entities
{
    public class Obras
    {
        [Key]
        public int Id { get; set; }

        public int EmpresaId { get; set; }
        public Empresas Empresa { get; set; }

        [Required(ErrorMessage = "Especifique nombre de la obra.")]
        public required string NombreObra { get; set; }

        public string? Descripcion { get; set; }


        [Required(ErrorMessage = "Especifique la ubicacion de la obra.")]
        public required string Ubicacion { get; set; }


        [Required(ErrorMessage = "Especifique el presupuesto estimado.")]
        public required decimal Presupuesto { get; set; }

        public DateTime? FechaUltimaHabilitacion { get; set; }
        public DateTime? FechaVencimientoHabilitacion { get; set; }
        public int? InformeHabilitanteId { get; set; }
        public InformeInspeccion? InformeHabilitante { get; set; }
        public string? MotivoNoHabilitacion { get; set; }
        public EnumEstadoObra EstadoObra { get; set; } = EnumEstadoObra.Iniciada;
        public EnumEstadoHabilitacionObra EstadoHabilitacion { get; set; } = EnumEstadoHabilitacionObra.EnInspeccion;
        public ICollection<ObrasEmpleados> ObrasEmpleados { get; set; } = new List<ObrasEmpleados>();
        public ICollection<ObrasContactos> ObrasContactos { get; set; } = new List<ObrasContactos>();
    }
}
