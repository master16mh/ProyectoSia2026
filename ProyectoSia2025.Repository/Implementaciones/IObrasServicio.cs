using ProyectoSia2025.BD.Data.Entities;
using ProyectoSia2025.Shared.DTOS.Obras;

namespace ProyectoSia2025.Repository.Implementaciones
{
    public interface IObrasServicio
    {
        Task<List<ObraListaDTO>> GetAllWorks(ObraListaDTO obraListaDTO);
        Task<Obras> GetWorkById(int workId);
        Task<List<Obras>> GetWorksByEnterprise(int enterpriseId);
        Task<string> AddWork(Obras workId, int enterpriseId);
        Task<string> ModifyWork(Obras work, int enterpriseId, int workId);
    }
}