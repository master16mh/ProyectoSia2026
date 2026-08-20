using ProyectoSia2026.Shared.DTOS.ContactosEmpresas;
using ProyectoSia2026.Shared.DTOS.EmpleadosPropios;
using ProyectoSia2026.Shared.DTOS.EmpleadosYcontactos;
using ProyectoSia2026.Shared.DTOS.Obras;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ProyectoSia2026.Shared.DTOS.Empresas
{
    public class EmpresaListaDTO
    {
        public string Nombre { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
    }
}
