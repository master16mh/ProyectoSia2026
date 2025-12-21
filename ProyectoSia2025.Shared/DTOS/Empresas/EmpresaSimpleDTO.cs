using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoSia2025.Shared.DTOS.Empresas
{
    public class EmpresaSimpleDTO
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public bool EsMiEmpresa { get; set; }  
    }
}
