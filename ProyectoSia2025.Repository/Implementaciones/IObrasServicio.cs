using ProyectoSia2025.BD.Data.Entities;
using ProyectoSia2025.Shared.DTOS.Obras;

namespace ProyectoSia2025.Repository.Implementaciones
{
    public interface IObrasServicio
    {
        Task<List<Obras>> GetAllWorks();
        Task<Obras> GetWorkById(int Id);
        Task<List<Obras>> GetWorkByName(string nombre);
        Task<List<Obras>> GetWorksByEnterprise(int enterpriseId);
        Task<bool> AddWork(Obras work, int enterpriseId);
        Task<string> ModifyWork(Obras work, int enterpriseId, int workId);
    }
}