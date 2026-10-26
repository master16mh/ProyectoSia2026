using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProyectoSia2026.BD;
using ProyectoSia2026.BD.Data.Entities;
using ProyectoSia2026.Repository.Implementaciones;
using ProyectoSia2026.Shared;
using ProyectoSia2026.Shared.DTOS;
using ProyectoSia2026.Shared.DTOS.EmpleadosPropios;
using ProyectoSia2026.Shared.DTOS.EmpleadosYcontactos;
using ProyectoSia2026.Shared.DTOS.EmpleadosYcontactos.EmpleadosPropios;

namespace ProyectoSia2026.Server.Controllers
{
    [ApiController]
    [Route("api/Empleados")]
    public class EmpleadoController : ControllerBase
    {
        private readonly IEmpleadoServicio empleadoServicio;
        public EmpleadoController(IEmpleadoServicio empleadoServicio)
        {
            this.empleadoServicio = empleadoServicio;
        }

        [HttpGet]
        public async Task<ActionResult<List<EmpleadosPropiosListaDTO>>> GetAllEmployees()
        {
            var employees = await empleadoServicio.GetAllEmployees();
            if (employees == null)
            {
                return NotFound();
            }
            return Ok(employees);
        }

        [HttpGet("Id/{id:int}")]
        public async Task<ActionResult<EmpleadoPropioDTO>> GetEmployeeById(int Id)
        {
            var employee = await empleadoServicio.GetEmployeeById(Id);
            if (employee == null)
            {
                return NotFound();
            }
            return Ok(employee);
        }

        [HttpGet("Nombre{nombre}")]
        public async Task<ActionResult<EmpleadoPropioDTO>> GetEmployeeByName(string nombre)
        {
            var employee = await empleadoServicio.GetEmployeeByName(nombre);
            if (employee == null)
            {
                return NotFound();
            }
            return Ok(employee);
        }

        [HttpPost]
        public async Task<ActionResult> Post(EmpleadoPropioCargarDTO cargarDTO)
        {
            var employeCargar = new EmpleadosPropios
            {
                Nombre = cargarDTO.Nombre,
                Apellido = cargarDTO.Apellido,
                DNI = cargarDTO.DNI,
                Email = cargarDTO.Email,
                Telefono = cargarDTO.Telefono,
                DireccionHogarEmpleado = cargarDTO.DireccionHogarEmpleado
            };
            var resultado = await empleadoServicio.AddEmployee(cargarDTO);
            return Ok(resultado);
        }
    }
}
