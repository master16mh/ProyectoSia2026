using Microsoft.EntityFrameworkCore;
using ProyectoSia2026.BD.Data.Entities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoSia2026.BD
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        public DbSet<Empresas> Empresas { get; set; }
        public DbSet<Obras> Obras { get; set; }
        public DbSet<Inspecciones> Inspecciones { get; set; }
        public DbSet<InformeInspeccion> InformeInspecciones { get; set; }
        public DbSet<InspeccionRequisito> InspeccionRequisitos { get; set; }
        public DbSet<NoConformidad> NoConformidades { get; set; }
        public DbSet<RequisitoSeguridad> RequisitoSeguridades { get; set; }
        public DbSet<Diseños> Diseños { get; set; }
        public DbSet<EmpleadosPropios> EmpleadoPropio { get; set; }
        public DbSet<ContactosEmpresas> ContactoEmpresas { get; set; }
        public DbSet<ObrasEmpleados> ObrasEmpleados { get; set; }
        public DbSet<ObrasContactos> ObrasContactos { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Presupuesto preciso
            modelBuilder.Entity<Obras>()
                .Property(o => o.Presupuesto)
                .HasPrecision(18, 2);

            // RELACIONES PRINCIPALES (1:N)

            // Empresa -> Obras (1:N)
            modelBuilder.Entity<Obras>()
                .HasOne(o => o.Empresa)
                .WithMany(e => e.Obras)
                .HasForeignKey(o => o.EmpresaId)
                .OnDelete(DeleteBehavior.Restrict);

            // Empresa -> EmpleadosPropios (1:N)
            modelBuilder.Entity<EmpleadosPropios>()
                .HasOne(e => e.Empresa)
                .WithMany(emp => emp.EmpleadosPropios)
                .HasForeignKey(e => e.EmpresaId)
                .OnDelete(DeleteBehavior.Restrict);

            // Empresa -> ContactosEmpresas (1:N)
            modelBuilder.Entity<ContactosEmpresas>()
                .HasOne(c => c.Empresa)
                .WithMany(emp => emp.ContactosEmpresas)
                .HasForeignKey(c => c.EmpresaId)
                .OnDelete(DeleteBehavior.Restrict);


            // RELACIONES MUCHOS A MUCHOS PERSONALIZADAS

            // ---------- ObraEmpleado ----------
            modelBuilder.Entity<ObrasEmpleados>()
                .HasKey(oe => new { oe.ObraId, oe.EmpleadoId });

            modelBuilder.Entity<ObrasEmpleados>()
                .HasOne(oe => oe.Obra)
                .WithMany(o => o.ObrasEmpleados)
                .HasForeignKey(oe => oe.ObraId);

            modelBuilder.Entity<ObrasEmpleados>()
                .HasOne(oe => oe.Empleado)
                .WithMany(e => e.ObrasEmpleados)
                .HasForeignKey(oe => oe.EmpleadoId);


            // ---------- ObraContacto ----------
            modelBuilder.Entity<ObrasContactos>()
                .HasKey(oc => new { oc.ObraId, oc.ContactoEmpresaId });

            modelBuilder.Entity<ObrasContactos>()
                .HasOne(oc => oc.Obra)
                .WithMany(o => o.ObrasContactos)
                .HasForeignKey(oc => oc.ObraId);

            modelBuilder.Entity<ObrasContactos>()
                .HasOne(oc => oc.ContactoEmpresa)
                .WithMany(c => c.ObrasContactos)
                .HasForeignKey(oc => oc.ContactoEmpresaId);
        }
    }
}
