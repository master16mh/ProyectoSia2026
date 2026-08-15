using Microsoft.EntityFrameworkCore;
using ProyectoSia2025.Shared.ENUM;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoSia2025.BD.Data.Entities
{
    [Index(nameof(CUIT), Name = "Empresa_CUIT", IsUnique = true)] // Índice único en el campo CUIT
    public class Empresas 
    {
        [Key]
        public int Id { get; set; }
        public bool EsMiEmpresa { get; set; }

        [Required(ErrorMessage = "Especifique Nombre de la Empresa.")]
        public required string Nombre { get; set; }

        [Required(ErrorMessage = "Especifique Razon Social de la Empresa.")]
        public required string RazonSocial { get; set; }

        [Required(ErrorMessage = "Especifique el CUIT de la Empresa.")]
        public required string CUIT { get; set; }

        [Required(ErrorMessage = "Especifique la direccion de la Empresa.")]
        public required string Direccion { get; set; }

        [Required(ErrorMessage = "Especifique el telefono de la Empresa.")]
        public required string Telefono { get; set; }

        public EnumEstadoEmpresa Estado { get; set; }
        public List<EmpleadosPropios>? EmpleadosPropios { get; set; }
        public List<Obras> Obras { get; set; }
        public ICollection<ContactosEmpresas> ContactosEmpresas { get; set; }
    }
}
