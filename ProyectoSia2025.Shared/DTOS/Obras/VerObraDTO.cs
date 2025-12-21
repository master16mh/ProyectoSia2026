using ProyectoSia2025.Shared.DTOS.ContactosEmpresas;
using ProyectoSia2025.Shared.DTOS.EmpleadosPropios;
using ProyectoSia2025.Shared.DTOS.Empresas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoSia2025.Shared.DTOS.Obras
{
    public class VerObraDTO
    {
        public int Id { get; set; }
        public string NombreObra { get; set; }
        public string Descripcion { get; set; }
        public string Ubicacion { get; set; }
        public decimal Presupuesto { get; set; }
        public string Estado { get; set; }

        // Dueña de la obra
        public EmpresaAsociadaDTO EmpresaDueña { get; set; }

        // Otras empresas chilas trabajando
        public List<EmpresaSimpleDTO> EmpresasInvolucradas { get; set; } = new();

        public List<EmpleadosPropiosDTO> EmpleadosPropios { get; set; } = new();
        public List<ContactosEmpresasDTO> EmpleadosExternos { get; set; } = new();
    }
}
