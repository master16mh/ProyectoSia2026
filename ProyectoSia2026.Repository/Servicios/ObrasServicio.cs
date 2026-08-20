using Microsoft.EntityFrameworkCore;
using ProyectoSia2026.BD;
using ProyectoSia2026.BD.Data.Entities;
using ProyectoSia2026.Repository.Implementaciones;
using ProyectoSia2026.Shared.DTOS.Obras;
using ProyectoSia2026.Shared.ENUM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoSia2026.Repository.Servicios
{
    public class ObrasServicio : IObrasServicio
    {
        private readonly AppDbContext dataBase;

        public ObrasServicio(AppDbContext dataBase)
        {
            this.dataBase = dataBase;
        }

        public async Task<List<ObraListaDTO>> GetAllWorks()
        {
            try 
            { 
               var works = await dataBase.Obras.Select( o => new ObraListaDTO
               {
                   
                   NombreObra = o.NombreObra,
                   Estado = o.EstadoObra.ToString()

               }).ToListAsync();

                if (works.Count == 0)
                {
                    Console.WriteLine("No se encontraron obras.");
                }
                return works;
            }
            catch (Exception ex) 
            {
                Console.WriteLine($"Error: {ex.Message}");
                return new List<ObraListaDTO>();
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

        public async Task<List<Obras>> GetWorkByName(string nombre)
        {
            try
            {
                var works = await dataBase.Obras.Where(o => EF.Functions.Collate(o.NombreObra, "Latin1_General_100_CI_AI").Contains(nombre)).ToListAsync();
                if (works == null)
                {
                    Console.WriteLine("No se encontraron obras con el nombre proporcionado.");
                    return null;
                }
                return works;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                return null;
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

        

        public async Task<string> AddWork(Obras work)
        {
            try
            {
                var enterpriseExist = await dataBase.Empresas.FirstOrDefaultAsync(e => e.Id == work.EmpresaId);
                if (enterpriseExist == null)
                {
                    return "La empresa indicada no existe.";
                }

                var workExist = await dataBase.Obras.FirstOrDefaultAsync(w => w.NombreObra == work.NombreObra && w.EmpresaId == work.EmpresaId);
                if (workExist != null)
                {
                    return "Ya existe una obra con ese nombre para esta empresa.";
                }

                if (string.IsNullOrWhiteSpace(work.NombreObra) || string.IsNullOrWhiteSpace(work.Ubicacion))
                {
                    return "Debe especificar el nombre de la obra y su ubicación.";
                }

                if (work.Presupuesto <= 0)
                { 
                    return "El presupuesto debe ser mayor a cero.";
                }

                await dataBase.Obras.AddAsync(work);
                await dataBase.SaveChangesAsync();

                return "Obra agregada exitosamente.";
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al agregar obra: {ex}");
                return $"Error al agregar la obra: {ex.Message}";
            }
        }

        public async Task<string> ModifyWork(ModificarObraDTO work, int workId)
        {
            try
            {
                var existingWork = await dataBase.Obras
                    .FirstOrDefaultAsync(w => w.Id == workId);

                if (existingWork == null)
                {
                    return "No existe la obra.";
                }

                if (string.IsNullOrWhiteSpace(work.NombreObra))
                {
                    return "Debe especificar el nombre de la obra.";
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
                    return "Debe especificar un estado válido para la obra.";
                }

                existingWork.EmpresaId = work.EmpresaId;
                existingWork.NombreObra = work.NombreObra;
                existingWork.Ubicacion = work.Ubicacion;
                existingWork.Presupuesto = work.Presupuesto;
                existingWork.EstadoObra = work.EstadoObra;
                existingWork.Descripcion = work.Descripcion;
                existingWork.FechaUltimaHabilitacion = work.FechaUltimaHabilitacion;
                existingWork.FechaVencimientoHabilitacion = work.FechaVencimientoHabilitacion;
                existingWork.MotivoNoHabilitacion = work.MotivoNoHabilitacion;

                await dataBase.SaveChangesAsync();

                return "OK";
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
