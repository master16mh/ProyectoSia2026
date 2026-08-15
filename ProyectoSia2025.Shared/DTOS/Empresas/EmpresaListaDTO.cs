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
    public class EmpresaListaDTO
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
    }
}
