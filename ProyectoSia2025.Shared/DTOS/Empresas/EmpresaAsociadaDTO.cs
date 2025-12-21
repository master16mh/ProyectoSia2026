using ProyectoSia2025.Shared.DTOS.ContactosEmpresas;
using ProyectoSia2025.Shared.DTOS.Obras;
using ProyectoSia2025.Shared.ENUM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoSia2025.Shared.DTOS.Empresas
{
    public class EmpresaAsociadaDTO
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string RazonSocial { get; set; }
        public string CUIT { get; set; }
        public string Direccion { get; set; }
        public bool EsMiEmpresa { get; set; }
        public EnumEstadoEmpresa Estado { get; set; }

        // empleados externos de esta empresa
        public List<EmpleadoSimpleDTO> Empleados { get; set; } = new();
    }
}
