using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoSia2026.BD.Data.Entities
{
    public class ObrasContactos
    {
        public int ObraId { get; set; }
        public Obras Obra { get; set; }

        public int ContactoEmpresaId { get; set; }
        public ContactosEmpresas ContactoEmpresa { get; set; }
    }
}
