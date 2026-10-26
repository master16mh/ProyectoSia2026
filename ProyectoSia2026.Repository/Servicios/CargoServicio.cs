using Microsoft.EntityFrameworkCore;
using ProyectoSia2026.BD;
using ProyectoSia2026.BD.Data.Entities;
using ProyectoSia2026.Repository.Implementaciones;
using ProyectoSia2026.Shared.DTOS.Cargos;
using ProyectoSia2026.Shared.DTOS.EmpleadosYcontactos.EmpleadosPropios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoSia2026.Repository.Servicios
{
    public class CargoServicio : ICargoServicio
    {
        private readonly AppDbContext dataBase;
        public CargoServicio(AppDbContext dataBase)
        {
            this.dataBase = dataBase;
        }

        public async Task<List<CargosDTO>> GetRoles()
        {
            try
            {
                var roles = await dataBase.Cargos.Select(e => new CargosDTO
                {
                    Id = e.Id,
                    Nombre = e.Nombre,

                }).ToListAsync();
                if (roles.Count == 0)
                {
                    Console.WriteLine("No se encontraron cargos.");
                }
                return roles;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                return new List<CargosDTO>();
            }
        }

        public async Task<string> AddRole(CargosDTO cargos)
        {
            try
            {
                var ExistingRoles = await dataBase.Cargos.AnyAsync(r => r.Id == cargos.Id && r.Nombre == cargos.Nombre);
                if (ExistingRoles)
                {
                    return "Ya existe un cargo con ese Id o Nombre";
                }
                if (string.IsNullOrEmpty(cargos.Nombre))
                {
                    return "Debe especificar un nombre al cargo";
                }
                var NewRol = new Cargos
                {
                    Id = cargos.Id,
                    Nombre = cargos.Nombre
                };
                dataBase.Cargos.Add(NewRol);
                await dataBase.SaveChangesAsync();
                return "Cargo agregado exitosamente.";
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                return "Error al agregar el cargo.";
            }
        }

        public async Task<string> UpdateRole(CargosDTO modifyCargos)
        {
            try
            {
                var existingRoles = await dataBase.Cargos.FirstOrDefaultAsync(r => r.Id == modifyCargos.Id);
                if (existingRoles == null)
                {
                    return "No existe el cargo";
                }
                if (string.IsNullOrEmpty(modifyCargos.Nombre))
                {
                    return "Debe especificar un nombre";
                }
                existingRoles.Nombre = modifyCargos.Nombre;

                await dataBase.SaveChangesAsync();

                return "Cargo actualizado exitosamente.";

            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                return "Error al actualizar el cargo.";
            }
        }
    }
}
