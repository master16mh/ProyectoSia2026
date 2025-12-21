using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProyectoSia2025.BD;
using ProyectoSia2025.BD.Data.Entities;
using ProyectoSia2025.Shared;
using ProyectoSia2025.Shared.DTOS;

namespace ProyectoSia2025.Server.Controllers
{
    [ApiController]
    [Route("api/Empresas")]
    public class EmpresaController : ControllerBase
    {
        private readonly AppDbContext context;

        // Constructor que recibe el contexto de la base de datos
        public EmpresaController(AppDbContext context)
        {
            this.context = context;
        }
    }
}
