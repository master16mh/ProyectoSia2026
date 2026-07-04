using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProyectoSia2025.BD;
using ProyectoSia2025.BD.Data.Entities;
using ProyectoSia2025.Repository.Implementaciones;
using ProyectoSia2025.Shared;
using ProyectoSia2025.Shared.DTOS;
using ProyectoSia2025.Shared.DTOS.Empresas;

namespace ProyectoSia2025.Server.Controllers
{
    [ApiController]
    [Route("api/Empresas")]
    public class EmpresaController : ControllerBase
    {
        private readonly IEmpresasServicio empresasServicio;

        public EmpresaController(IEmpresasServicio empresasServicio)
        {
            this.empresasServicio = empresasServicio;
        }

        [HttpPost]
        public async Task<ActionResult> Post(EmpresaCrearDTO empresaCrearDTO) 
        {
            var empresaCrear = new Empresas
            {
                Nombre = empresaCrearDTO.Nombre,
                RazonSocial = empresaCrearDTO.RazonSocial,
                CUIT = empresaCrearDTO.CUIT,
                Direccion = empresaCrearDTO.Direccion,
                Estado = empresaCrearDTO.Estado,
            };
            var resutado = await empresasServicio.AddEnterprise(empresaCrear);
            return Ok (resutado);
        }
    }
}
