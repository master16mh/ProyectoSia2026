using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProyectoSia2025.Shared.ENUM;

namespace ProyectoSia2025.Shared.DTOS.Obras
{
    public class CrearObraDTO
    {
        public int EmpresaId { get; set; }
        public string NombreObra { get; set; }
        public string Descripcion {  get; set; }
        public string Ubicacion { get; set; }
        public decimal Presupuesto { get; set; }
        public EnumEstadoObra EstadoObra { get; set; } = EnumEstadoObra.Iniciada;
    }
}
