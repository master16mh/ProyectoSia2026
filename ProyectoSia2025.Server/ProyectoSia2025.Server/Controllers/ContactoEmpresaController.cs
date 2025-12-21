using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProyectoSia2025.BD;
using ProyectoSia2025.BD.Data.Entities;
using ProyectoSia2025.Shared.DTOS;

namespace ProyectoSia2025.Server.Controllers
{
    [ApiController]
    [Route("api/ContactoEmpresa")]
    public class ContactoEmpresaController : ControllerBase
    {
        private readonly AppDbContext context;


        // Constructor que recibe el contexto de la base de datos
        public ContactoEmpresaController (AppDbContext context)
        {
            this.context = context;

        }
    }
}
