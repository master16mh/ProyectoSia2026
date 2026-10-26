using ProyectoSia2026.Shared.DTOS.EmpleadosPropios;
using ProyectoSia2026.Shared.DTOS.EmpleadosYcontactos.EmpleadosPropios;

namespace ProyectoSia2026.Repository.Implementaciones
{
    public interface IEmpleadoServicio
    {
        Task<List<EmpleadosPropiosListaDTO>> GetAllEmployees();
        Task<EmpleadoPropioDTO> GetEmployeeById(int employeeId);
        Task<List<EmpleadoPropioDTO>> GetEmployeeByName(string nombre);
        Task<string> AddEmployee(EmpleadoPropioCargarDTO employee);
        Task<string> UpdateEmployee(EmpleadoPropioModificarDTO modifyEmploye);
    }
}