using Microsoft.EntityFrameworkCore;
using ProyectoSia2025.BD;
using ProyectoSia2025.BD.Data.Entities;
using ProyectoSia2025.Shared.ENUM;
using ProyectoSia2025.Repository.Implementaciones;
using ProyectoSia2025.Shared.DTOS.Empresas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoSia2025.Repository.Servicios
{
    public class EmpresasServicio : IEmpresasServicio
    {
        private readonly AppDbContext dataBase;

        public EmpresasServicio(AppDbContext dataBase)
        {
            this.dataBase = dataBase;
        }

        public async Task<List<EmpresaListaDTO>> GetAllEnterprises()
        {
            try
            {
                var enterprises = await dataBase.Empresas.Select(e => new EmpresaListaDTO
                {
                    Id = e.Id,
                    Nombre = e.Nombre,
                    Direccion = e.Direccion,
                    Telefono = e.Telefono
                }).ToListAsync();
               
                if (enterprises.Count == 0)
                {
                    Console.WriteLine("No se encontraron empresas.");
                }

                return enterprises;

            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                return new List<EmpresaListaDTO>();
            }
        }

        public async Task<Empresas> GetEnterpriseById(int enterpriseId)
        {
            try
            {
                var enterprise = await dataBase.Empresas.FirstOrDefaultAsync(e => e.Id == enterpriseId);
                if (enterprise == null)
                {
                    Console.WriteLine("No existe la empresa.");
                    return null;
                }
                return enterprise;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                return null;
            }
        }

        public async Task<List<Empresas>> GetEnterpriseByName(string nombre)
        {
            try
            {
                var enterprise = await dataBase.Empresas.Where(e => EF.Functions.Collate(e.Nombre, "Latin1_General_100_CI_AI").Contains(nombre)).ToListAsync();
                if (enterprise == null)
                {
                    Console.WriteLine("No existe la empresa con el nombre proporcionado.");
                    return null;
                }
                return enterprise;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                return null;
            }
        }

        public async Task<Empresas> GetEnterpriseByCUIT(string cuit)
        {
            try
            {
                var enterprise = await dataBase.Empresas.FirstOrDefaultAsync(e => e.CUIT == cuit);
                if (enterprise == null)
                {
                    Console.WriteLine("No existe la empresa con el CUIT proporcionado.");
                    return null;
                }
                return enterprise;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                return null;
            }
        }

        public async Task<string> AddEnterprise(Empresas enterprise)
        {
            try
            {
                var existingEnterprise = await dataBase.Empresas.AnyAsync(e => e.CUIT == enterprise.CUIT);
                if(existingEnterprise)
                {
                    return "Ya existe una empresa con el mismo CUIT.";
                }

                if (string.IsNullOrWhiteSpace(enterprise.Nombre) || string.IsNullOrWhiteSpace(enterprise.RazonSocial) ||
                   string.IsNullOrWhiteSpace(enterprise.CUIT) || string.IsNullOrWhiteSpace(enterprise.Direccion) || string.IsNullOrWhiteSpace(enterprise.Telefono))
                {
                    return "Faltan datos obligatorios en campos de la empresa.";
                }

                enterprise.Nombre = enterprise.Nombre;
                enterprise.RazonSocial = enterprise.RazonSocial;
                enterprise.CUIT = enterprise.CUIT;
                enterprise.Direccion = enterprise.Direccion;
                enterprise.Telefono = enterprise.Telefono;
                enterprise.Estado = EnumEstadoEmpresa.Vinculada;

                await dataBase.Empresas.AddAsync(enterprise);
                await dataBase.SaveChangesAsync();

                return "Empresa agregada exitosamente.";
            }
            catch (Exception ex)
            {
                return $"Error al añadir la empresa: {ex.Message}";
            }
        }

        public async Task<string> ModifyEnterprise(Empresas enterprise, int enterpriseId)
        {
            try
            {
                var existingEnterprise = await dataBase.Empresas.FirstOrDefaultAsync(e => e.Id == enterpriseId);
                if (existingEnterprise == null)
                {
                    return "La empresa no existe.";
                }
                if (string.IsNullOrWhiteSpace(enterprise.Nombre) || string.IsNullOrWhiteSpace(enterprise.RazonSocial) ||
                   string.IsNullOrWhiteSpace(enterprise.CUIT) || string.IsNullOrWhiteSpace(enterprise.Direccion))
                {
                    return "Faltan datos obligatorios en campos de la empresa.";
                }
                existingEnterprise.Nombre = enterprise.Nombre;
                existingEnterprise.RazonSocial = enterprise.RazonSocial;
                existingEnterprise.Direccion = enterprise.Direccion;
                existingEnterprise.Estado = enterprise.Estado;

                dataBase.Empresas.Update(existingEnterprise);
                await dataBase.SaveChangesAsync();

                return "Empresa modificada exitosamente.";
            }
            catch (Exception ex)
            {
                return $"Error al modificar la empresa: {ex.Message}";
            }
        }
    }
}
