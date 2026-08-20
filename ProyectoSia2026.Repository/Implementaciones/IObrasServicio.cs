using ProyectoSia2026.BD.Data.Entities;
using ProyectoSia2026.Shared.DTOS.Obras;

namespace ProyectoSia2026.Repository.Implementaciones
{
    public interface IObrasServicio
    {
        Task<List<ObraListaDTO>> GetAllWorks();
        Task<Obras> GetWorkById(int Id);
        Task<List<Obras>> GetWorkByName(string nombre);
        Task<List<Obras>> GetWorksByEnterprise(int enterpriseId);
        Task<string> AddWork(Obras work);
        Task<string> ModifyWork(ModificarObraDTO dto, int workId);
    }
}