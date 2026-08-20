using ProyectoSia2026.BD.Data.Entities;
using ProyectoSia2026.Shared.DTOS.Empresas;

namespace ProyectoSia2026.Repository.Implementaciones
{
    public interface IEmpresasServicio
    {
        Task<List<EmpresaListaDTO>> GetAllEnterprises();
        Task<Empresas> GetEnterpriseById(int Id);
        Task<List<Empresas>> GetEnterpriseByName(string nombre);
        Task<Empresas> GetEnterpriseByCUIT(string cuit);
        Task<string> AddEnterprise(Empresas enterpriseId);
        Task<string> ModifyEnterprise(Empresas enterprise, int enterpriseId);
    }
}