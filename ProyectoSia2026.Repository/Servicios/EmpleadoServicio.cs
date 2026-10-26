using Microsoft.EntityFrameworkCore;
using ProyectoSia2026.BD;
using ProyectoSia2026.BD.Data.Entities;
using ProyectoSia2026.Repository.Implementaciones;
using ProyectoSia2026.Shared.DTOS.EmpleadosPropios;
using ProyectoSia2026.Shared.DTOS.EmpleadosYcontactos.EmpleadosPropios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoSia2026.Repository.Servicios
{
    public class EmpleadoServicio : IEmpleadoServicio
    {
        private readonly AppDbContext dataBase;
        public EmpleadoServicio(AppDbContext dataBase)
        {
            this.dataBase = dataBase;
        }
        public async Task<List<EmpleadosPropiosListaDTO>> GetAllEmployees()
        {
            try
            {
                var employees = await dataBase.EmpleadoPropio.Select(e => new EmpleadosPropiosListaDTO
                {
                    Id = e.Id,
                    EmpresaId = e.EmpresaId,
                    Nombre = e.Nombre,
                    Apellido = e.Apellido,
                    CargoId = e.CargoId,
                    Cargo = e.Cargo.Nombre,
                }).ToListAsync();
                if (employees.Count == 0)
                {
                    Console.WriteLine("No se encontraron empleados.");
                }
                return employees;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                return new List<EmpleadosPropiosListaDTO>();
            }
        }

        public async Task<EmpleadoPropioDTO> GetEmployeeById(int employeeId)
        {
            try
            {
                var employee = await dataBase.EmpleadoPropio.FirstOrDefaultAsync(e => e.Id == employeeId);
                if (employee == null)
                {
                    Console.WriteLine("No existe el empleado.");
                    return null;
                }
                return new EmpleadoPropioDTO
                {
                    Id = employee.Id,
                    EmpresaId = employee.EmpresaId,
                    Nombre = employee.Nombre,
                    Apellido = employee.Apellido,
                    DNI = employee.DNI,
                    Email = employee.Email,
                    Telefono = employee.Telefono,
                    DireccionEmpleado = employee.DireccionHogarEmpleado,
                    Cargo = employee.Cargo.Nombre
                };
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                return null;
            }
        }

        public async Task<List<EmpleadoPropioDTO>> GetEmployeeByName(string nombre)
        {
            try
            {
                var employees = await dataBase.EmpleadoPropio.Where(e => EF.Functions.Collate(e.Nombre, "Latin1_General_100_CI_AI").Contains(nombre)).ToListAsync();
                if (employees == null || employees.Count == 0)
                {
                    Console.WriteLine("No se encontraron empleados con el nombre proporcionado.");
                    return new List<EmpleadoPropioDTO>();
                }
                return employees.Select(employee => new EmpleadoPropioDTO
                {
                    Id = employee.Id,
                    EmpresaId = employee.EmpresaId,
                    Nombre = employee.Nombre,
                    Apellido = employee.Apellido,
                    DNI = employee.DNI,
                    Email = employee.Email,
                    Telefono = employee.Telefono,
                    DireccionEmpleado = employee.DireccionHogarEmpleado,
                    Cargo = employee.Cargo.Nombre
                }).ToList();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                return new List<EmpleadoPropioDTO>();
            }
        }

        public async Task<string> AddEmployee(EmpleadoPropioCargarDTO employee)
        {
            try
            {
                var existingEmployee = await dataBase.EmpleadoPropio.AnyAsync(e => e.DNI == employee.DNI && e.EmpresaId == employee.EmpresaId);
                if (existingEmployee)
                {
                    return "El empleado ya existe.";
                }

                if (string.IsNullOrEmpty(employee.Nombre) || string.IsNullOrEmpty(employee.Apellido) || string.IsNullOrEmpty(employee.DNI) ||
                    string.IsNullOrEmpty(employee.Email) || string.IsNullOrEmpty(employee.Telefono) || string.IsNullOrEmpty(employee.DireccionHogarEmpleado))
                {
                    return "Todos los campos son obligatorios.";
                }
                var existingCargo = await dataBase.Cargos.AnyAsync(c => c.Id == employee.CargoId);
                if (!existingCargo)
                {
                    return "El cargo seleccionado no existe.";
                }

                var newEmployee = new EmpleadosPropios
                {
                    EmpresaId = employee.EmpresaId,
                    Nombre = employee.Nombre,
                    Apellido = employee.Apellido,
                    DNI = employee.DNI,
                    Email = employee.Email,
                    Telefono = employee.Telefono,
                    DireccionHogarEmpleado = employee.DireccionHogarEmpleado,
                    CargoId = employee.CargoId
                };

                dataBase.EmpleadoPropio.Add(newEmployee);
                await dataBase.SaveChangesAsync();
                return "Empleado agregado exitosamente.";
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                return "Error al agregar el empleado.";
            }
        }

        public async Task<string> UpdateEmployee(EmpleadoPropioModificarDTO modifyEmployee)
        {
            try
            {
                var existingEmployee = await dataBase.EmpleadoPropio.FirstOrDefaultAsync(e => e.Id == modifyEmployee.Id);
                if (existingEmployee == null)
                {
                    return "El empleado no existe.";
                }
                if (string.IsNullOrEmpty(modifyEmployee.Nombre) || string.IsNullOrEmpty(modifyEmployee.Apellido) || string.IsNullOrEmpty(modifyEmployee.DNI) ||
                    string.IsNullOrEmpty(modifyEmployee.Email) ||  string.IsNullOrEmpty(modifyEmployee.Telefono) || string.IsNullOrEmpty(modifyEmployee.DireccionHogarEmpleado))
                {
                    return "Todos los campos son obligatorios.";
                }

                var dniExists = await dataBase.EmpleadoPropio
                    .AnyAsync((e => e.DNI == modifyEmployee.DNI && e.EmpresaId == existingEmployee.EmpresaId && e.Id != modifyEmployee.Id));
                if (dniExists)
                {
                    return "El DNI ya pertenece a otro empleado.";
                }

                var cargoExists = await dataBase.Cargos.AnyAsync(c => c.Id == modifyEmployee.CargoId);
                if (!cargoExists)
                {
                    return "El cargo seleccionado no existe.";
                }
                existingEmployee.Nombre = modifyEmployee.Nombre;
                existingEmployee.Apellido = modifyEmployee.Apellido;
                existingEmployee.DNI = modifyEmployee.DNI;
                existingEmployee.Email = modifyEmployee.Email;
                existingEmployee.Telefono = modifyEmployee.Telefono;
                existingEmployee.DireccionHogarEmpleado = modifyEmployee.DireccionHogarEmpleado;
                existingEmployee.CargoId = modifyEmployee.CargoId;

                await dataBase.SaveChangesAsync();

                return "Empleado actualizado exitosamente.";
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                return "Error al actualizar el empleado.";
            }
        }
    }
}
