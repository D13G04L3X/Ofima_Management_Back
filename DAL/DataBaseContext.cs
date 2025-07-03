using Microsoft.EntityFrameworkCore;
using Ofima_Management.DAL.Entities;

namespace Ofima_Management.DAL
{
    public class DataBaseContext : DbContext
    {
        public DataBaseContext(DbContextOptions<DataBaseContext> options) : base(options) { }

        public DbSet<Empleado> Empleados { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Aquí se ejecutará el seeder
            modelBuilder.Entity<Empleado>().HasData(
                new Empleado
                {
                    Id = 1,
                    Nombre = "Ana Torres",
                    Email = "ana.torres@ofima.com",
                    Cargo = "Analista de Datos",
                    Departamento = "Inteligencia de Negocios",
                    Telefono = "3214567890",
                    Direccion = "Cra 12 #45-89",
                    FechaContratacion = new DateTime(2023, 10, 10),
                    Activo = true
                },
                new Empleado
                {
                    Id = 2,
                    Nombre = "Carlos Mendoza",
                    Email = "carlos.mendoza@ofima.com",
                    Cargo = "Desarrollador .NET",
                    Departamento = "TI",
                    Telefono = "3123456789",
                    Direccion = "Calle 23 #12-45",
                    FechaContratacion = new DateTime(2023, 5, 18),
                    Activo = true
                }
            );
        }
    }
}
