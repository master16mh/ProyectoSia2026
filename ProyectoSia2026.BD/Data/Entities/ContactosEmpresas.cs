using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoSia2026.BD.Data.Entities
{
    [Index(nameof(DNI), Name = "Contacto_DNI", IsUnique = true)] 
    public class ContactosEmpresas
    {
        public int Id { get; set; }
        public int EmpresaId { get; set; }
        public Empresas Empresa { get; set; }
        public string Nombre { get; set; }
        public int DNI { get; set; }
        public string Rol { get; set; }
        public string Telefono { get; set; }
        public ICollection<ObrasContactos> ObrasContactos { get; set; } = new List<ObrasContactos>();
    }
}
