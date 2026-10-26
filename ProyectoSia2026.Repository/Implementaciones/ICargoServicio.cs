using ProyectoSia2026.Shared.DTOS.Cargos;

namespace ProyectoSia2026.Repository.Implementaciones
{
    public interface ICargoServicio
    {
        Task<string> AddRole(CargosDTO cargos);
        Task<List<CargosDTO>> GetRoles();
        Task<string> UpdateRole(CargosDTO modifyCargos);
    }
}