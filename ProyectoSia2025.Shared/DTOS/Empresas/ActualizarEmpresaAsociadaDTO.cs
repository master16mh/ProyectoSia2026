using ProyectoSia2025.Shared.ENUM;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoSia2025.Shared.DTOS.Empresas
{
    public class ActualizarEmpresaAsociadaDTO
    {
        [Required]
        public int Id { get; set; }

        public string? Nombre { get; set; }
        public string? RazonSocial { get; set; }
        public string CUIT { get; set; }
        public string Direccion { get; set; }

        [Required(ErrorMessage = "El estado de la empresa es obligatorio")]
        public EnumEstadoEmpresa Estado { get; set; }
    }
}
