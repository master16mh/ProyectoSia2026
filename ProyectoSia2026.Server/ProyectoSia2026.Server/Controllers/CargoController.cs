using Microsoft.AspNetCore.Mvc;
using ProyectoSia2026.BD.Data.Entities;
using ProyectoSia2026.Repository.Implementaciones;
using ProyectoSia2026.Repository.Servicios;
using ProyectoSia2026.Shared.DTOS.Cargos;
using ProyectoSia2026.Shared.DTOS.EmpleadosYcontactos.EmpleadosPropios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoSia2026.Server.Controllers
{
    [ApiController]
    [Route("api/Cargos")]
    public class CargoController : ControllerBase
    {
        private readonly ICargoServicio cargoServicio;
        public CargoController(ICargoServicio cargoServicio)
        {
            this.cargoServicio = cargoServicio;
        }

        [HttpGet]
        public async Task<ActionResult<List<CargosDTO>>> GetRoles()
        {
            var roles = await cargoServicio.GetRoles();
            if (roles == null)
            {
                return NotFound();
            }
            return Ok(roles);
        }

        [HttpPost]
        public async Task<ActionResult> Post(CargosDTO cargos)
        {
            var rolesCargar = new Cargos
            {
                Id = cargos.Id,
                Nombre = cargos.Nombre
            };
            var resultado = await cargoServicio.AddRole(cargos);
            return Ok(resultado);
        }

        //[HttpPut("Id/{id:int}")]
        //public async Task<ActionResult> Put(CargosDTO cargos, int id)
        //{
        //    var cargoModificar = await cargoServicio.
        //}
    }
}
