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

        [HttpGet]
        public async Task<ActionResult<List<Obras>>> GetWorks()
        {
            var obras = await obrasServicio.GetAllWorks();
            return Ok(obras);
        }

        [HttpGet("Id/{Id:int}")]
        public async Task<ActionResult<Obras>> GetWorkById(int Id)
        {
            var work = await obrasServicio.GetWorkById(Id);
            if (work == null)
            {
                return NotFound();
            }
            return Ok(work);
        }

        [HttpGet("Nombre/{nombre}")]
        public async Task<ActionResult<Obras>> GetWorkByName(string nombre)
        {
            var obras = await obrasServicio.GetWorkByName(nombre);
            if (obras == null || obras.Count == 0)
            {
                return NotFound();
            }
            return Ok(obras);
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

            if (!resultado)
            {
                return BadRequest("No se pudo agregar la obra");
            }
            return Ok("Obra agregada exitosamente.");
        }
    }
}
