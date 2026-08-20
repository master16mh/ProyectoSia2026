using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using ProyectoSia2026.BD;
using ProyectoSia2026.BD.Data.Entities;
using ProyectoSia2026.Repository.Implementaciones;
using ProyectoSia2026.Repository.Servicios;
using ProyectoSia2026.Shared.DTOS.Obras;

namespace ProyectoSia2026.Server.Controllers
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
        public async Task<ActionResult<List<ObraListaDTO>>> GetWorks()
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
        public async Task<ActionResult> Post(ObraCrearDTO crearObraDTO)
        {
            var obraCrear = new Obras
            {
                EmpresaId = crearObraDTO.EmpresaId,
                NombreObra = crearObraDTO.NombreObra,
                Descripcion = crearObraDTO.Descripcion,
                Ubicacion = crearObraDTO.Ubicacion,
                Presupuesto = crearObraDTO.Presupuesto,
                EstadoObra = crearObraDTO.Estado,
            };
            var resultado = await obrasServicio.AddWork(obraCrear);

            if (resultado != "OK")
            {
                return BadRequest(resultado);
            }
            return Ok("Obra agregada exitosamente.");
        }

        [HttpPut("{workId}")]
        public async Task<ActionResult> Put(int workId, ModificarObraDTO modificarObraDTO)
        {
            var resultado = await obrasServicio.ModifyWork(modificarObraDTO, workId);
            if (resultado != "OK")
            {
                return BadRequest(resultado);
            }
            return Ok("Obra modificada exitosamente.");
        }
    }
}
