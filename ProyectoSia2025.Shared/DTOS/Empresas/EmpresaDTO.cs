using ProyectoSia2025.Shared.DTOS.ContactosEmpresas;
using ProyectoSia2025.Shared.DTOS.EmpleadosPropios;
using ProyectoSia2025.Shared.DTOS.EmpleadosYcontactos;
using ProyectoSia2025.Shared.DTOS.Obras;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ProyectoSia2025.Shared.DTOS.Empresas
{
    public class EmpresaDTO
    {
        public int EmpresaId { get; set; }
        public string Nombre { get; set; }
        public string RazonSocial { get; set; }
        public string CUIT { get; set; }
        public string Direccion { get; set; }
        public bool EsMiEmpresa { get; set; }

        public List<ContactoSimpleDTO> Contactos { get; set; } = new();
        public List<EmpleadoSimpleDTO> Empleados { get; set; } = new();
        public List<ObraAsociadaDTO> Obras { get; set; } = new();
    }
}
