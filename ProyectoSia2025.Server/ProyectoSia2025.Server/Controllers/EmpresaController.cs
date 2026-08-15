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

        [HttpGet]
        public async Task<ActionResult<List<EmpresaListaDTO>>> GetAllEnterprises()
        {
            var enterprises = await empresasServicio.GetAllEnterprises();
            return Ok(enterprises);
        }

        [HttpGet("Id/{Id:int}")]
        public async Task<ActionResult<Empresas>> GetEnterpriseById(int Id)
        {
            var enterprise = await empresasServicio.GetEnterpriseById(Id);
            if (enterprise == null)
            {
                return NotFound();
            }
            return Ok(enterprise);
        }

        [HttpGet("Cuit/{cuit}")]
        public async Task<ActionResult<Empresas>> GetEnterpriseByCUIT(string cuit)
        {
            var enterprise = await empresasServicio.GetEnterpriseByCUIT(cuit);
            if (enterprise == null)
            {
                return NotFound();
            }
            return Ok(enterprise);
        }

        [HttpGet("Nombre/{nombre}")]
        public async Task<ActionResult<Empresas>> GetEnterpriseByName(string nombre)
        {
            var enterprise = await empresasServicio.GetEnterpriseByName(nombre);
            if (enterprise == null)
            {
                return NotFound();
            }
            return Ok(enterprise);
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
                Telefono = empresaCrearDTO.Telefono,
                Estado = empresaCrearDTO.Estado,
            };
            var resutado = await empresasServicio.AddEnterprise(empresaCrear);
            return Ok (resutado);
        }

        [HttpPut("Id/{id:int}")]
        public async Task<ActionResult> Put(EmpresaModificarDTO empresaModificarDTO, int id)
        {
            var empresaModificar = await empresasServicio.GetEnterpriseById(id);
            
            if (empresaModificar == null) 
            { 
                return NotFound(); 
            }

            empresaModificar.Nombre = empresaModificarDTO.Nombre;
            empresaModificar.RazonSocial = empresaModificarDTO.RazonSocial;
            empresaModificar.Direccion = empresaModificarDTO.Direccion;
            empresaModificar.Estado = empresaModificarDTO.Estado;

            var resultado = await empresasServicio.ModifyEnterprise(empresaModificar, id);
            return Ok(resultado);
        }
    }
}
