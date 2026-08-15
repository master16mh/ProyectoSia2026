using ProyectoSia2025.Shared.ENUM;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoSia2025.Shared.DTOS.Empresas
{
    public class EmpresaCrearDTO
    {
        [Required(ErrorMessage = "El nombre de la empresa es obligatorio")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "La razón social de la empresa es obligatorio")]
        public string RazonSocial { get; set; }

        [Required(ErrorMessage = "El cuit de la empresa es obligatorio")]
        public string CUIT { get; set; }

        [Required(ErrorMessage = "La dirección de la empresa es obligatorio")]
        public string Direccion { get; set; }
        [Required(ErrorMessage = "El teléfono de la empresa es obligatorio")]
        public string Telefono { get; set; }

        public EnumEstadoEmpresa Estado { get; set; } = EnumEstadoEmpresa.Vinculada;
    }
}
