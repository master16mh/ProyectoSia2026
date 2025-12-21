using ProyectoSia2025.Shared.DTOS.Empresas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoSia2025.Shared.DTOS.Obras
{
    public class ObraAsociadaDTO
    {
        public int Id { get; set; }
        public string NombreObra { get; set; }
        public string Descripcion { get; set; }
        public string Ubicacion { get; set; }
        public decimal Presupuesto { get; set; }
        public string Estado { get; set; }

        // Quién es la empresa dueña de la obra
        public EmpresaSimpleDTO EmpresaDueña { get; set; }

        // True si esta obra pertenece a MI empresa
        public bool EsObraPropia { get; set; }

        // Empleados (tanto míos como externos) trabajando en la obra
        public List<EmpleadoSimpleDTO> EmpleadosAsignados { get; set; } = new();
    }
}
