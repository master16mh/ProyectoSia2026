using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using ProyectoSia2025.BD;
using ProyectoSia2025.BD.Data.Entities;
using ProyectoSia2025.Repository.Implementaciones;
using ProyectoSia2025.Repository.Servicios;
using ProyectoSia2025.Shared.DTOS.Obras;

namespace ProyectoSia2025.Server.Controllers
{
    [ApiController]
    [Route("api/Obras")]
    public class ObrasController : ControllerBase
    {
        private readonly IObrasServicio obrasServicio;

        public ObrasController(IObrasServicio obrasServicio)
        {
            this.obrasServicio = obrasServicio;
        }

        [HttpPost]
        public async Task<ActionResult> Post(CrearObraDTO crearObraDTO)
        {
            var obraCrear = new Obras
            {
                EmpresaId = crearObraDTO.EmpresaId,
                NombreObra = crearObraDTO.NombreObra,
                Descripcion = crearObraDTO.Descripcion,
                Ubicacion = crearObraDTO.Ubicacion,
                Presupuesto = crearObraDTO.Presupuesto,
                FechaUltimaHabilitacion = crearObraDTO.FechaUltimaHabilitacion,
                FechaVencimientoHabilitacion = crearObraDTO.FechaVencimientoHabilitacion,
                MotivoNoHabilitacion = crearObraDTO.MotivoNoHabilitacion,
                EstadoObra = crearObraDTO.Estado,
            };
            var resultado = await obrasServicio.AddWork(obraCrear, crearObraDTO.EmpresaId);

            if (resultado != null)
            {
                return BadRequest(resultado);
            }
            return Ok(resultado);
        }
    }
}
