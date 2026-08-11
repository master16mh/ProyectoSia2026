using Microsoft.EntityFrameworkCore;
using ProyectoSia2025.BD;
using ProyectoSia2025.BD.Data.Entities;
using ProyectoSia2025.Repository.Implementaciones;
using ProyectoSia2025.Shared.DTOS.Obras;
using ProyectoSia2025.Shared.ENUM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoSia2025.Repository.Servicios
{
    public class ObrasServicio : IObrasServicio
    {
        private readonly AppDbContext dataBase;

        public ObrasServicio(AppDbContext dataBase)
        {
            this.dataBase = dataBase;
        }

        public async Task<List<ObraListaDTO>> GetAllWorks(ObraListaDTO obraListaDTO)
        {
            try
            {
                var works = await dataBase.Obras.Select(o => new ObraListaDTO
                {
                    NombreObra = o.NombreObra,
                    Estado = o.EstadoObra.ToString()
                }).ToListAsync();

                if (works.Count == 0)
                {
                    Console.WriteLine("No hay Obras disponibles");
                    return new List<ObraListaDTO>();
                }
                return works;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                return new List<ObraListaDTO>();
            }
        }

        public async Task<List<Obras>> GetWorksByEnterprise(int enterpriseId)
        {
            try
            {
                var enterprise = await dataBase.Empresas.Include(b => b.Obras).FirstOrDefaultAsync(b => b.Id == enterpriseId);

                if (enterprise == null)
                {
                    Console.WriteLine("No existe la empresa.");
                    return new List<Obras>();
                }
                return enterprise.Obras.ToList();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                return new List<Obras>();
            }
        }

        public async Task<Obras> GetWorkById(int workId)
        {
            try 
            {
                var work = await dataBase.Obras.FirstOrDefaultAsync(o => o.Id == workId);
                if (work == null)
                {
                    Console.WriteLine("No existe la obra.");
                    return null;
                }
                return work;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                return null;
            }
        }

        public async Task<string> AddWork(Obras work, int enterpriseId)
        {
            try
            {
                var enterpriseExist = await dataBase.Empresas.FirstOrDefaultAsync(e => e.Id == enterpriseId);
                if (enterpriseExist == null)
                {
                    return "La empresa no existe.";
                }

                var workExist = await dataBase.Obras.FirstOrDefaultAsync(w => w.NombreObra == work.NombreObra && w.EmpresaId == enterpriseId);
                if (workExist != null)
                {
                    return "Ya existe una obra con ese nombre para la empresa especificada.";
                }

                if (string.IsNullOrWhiteSpace(work.NombreObra) || string.IsNullOrWhiteSpace(work.Ubicacion))
                    return "El nombre y la ubicación de la obra no pueden estar vacíos.";

                if (work.Presupuesto <= 0)
                    return "El presupuesto debe ser mayor a cero.";

                if (work.EstadoObra == 0)
                    return "Debe especificar un estado válido de la obra.";

                work.EmpresaId = enterpriseExist.Id;
                work.EstadoObra = EnumEstadoObra.Iniciada;

                await dataBase.Obras.AddAsync(work);
                await dataBase.SaveChangesAsync();

                return "Obra agregada!";
            }
            catch (Exception ex)
            {
                return $"Error al añadir la obra: {ex.Message}";
            }
        }

        public async Task<string> ModifyWork(Obras work, int enterpriseId, int workId)
        {
            try
            {
                var existingWork = await dataBase.Obras.FirstOrDefaultAsync(w => w.Id == workId);
                if (existingWork == null)
                {
                    return "No existe la obra";
                }

                bool noName = string.IsNullOrWhiteSpace(work.NombreObra);
                bool noDescription = string.IsNullOrWhiteSpace(work.Descripcion);
                if (noName && noDescription)
                {
                    return "Debe especificar nombre y descripción de obra.";
                }

                if (string.IsNullOrWhiteSpace(work.Ubicacion))
                {
                    return "Debe especificar la ubicación de la obra.";
                }

                if (work.Presupuesto <= 0)
                {
                    return "El presupuesto debe ser mayor a cero.";
                }

                if (work.EstadoObra == EnumEstadoObra.Ninguno)
                {
                    return "Debe especificar un estado válido a la obra.";
                }

                if (existingWork.EmpresaId != enterpriseId)
                {
                    return "La obra no pertenece a ninguna empresa.";
                }

                existingWork.NombreObra = work.NombreObra;
                existingWork.Ubicacion = work.Ubicacion;
                existingWork.Presupuesto = work.Presupuesto;
                existingWork.EstadoObra = work.EstadoObra;
                existingWork.Descripcion = work.Descripcion;

                await dataBase.SaveChangesAsync();

                return "Obra modificada correctamente.";
            }
            catch (Exception ex)
            {
                return $"Error al modificar la obra: {ex.Message}";
            }
        }

        public async Task<string> FinalizeWork(int workId)
        {
           try
           {
              var work = await dataBase.Obras.FirstOrDefaultAsync(o => o.Id == workId);
                if (work == null)
                {
                    return "No existe la obra";
                }

                work.EstadoObra = EnumEstadoObra.Terminada;

                await dataBase.SaveChangesAsync();

                return "Estado de Obra finalizada!";
           }
           catch (Exception ex)
           {
                return $"Error inesperado: {ex.Message}";
           }
        } 
    }
}
