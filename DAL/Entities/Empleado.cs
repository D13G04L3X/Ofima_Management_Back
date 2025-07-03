using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Ofima_Management.DAL.Entities
{
    public class Empleado
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] // Auto-incremental ID
        public int Id { get; set; }
        [Required]
        public string Nombre { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        public string Cargo { get; set; }
        public string Departamento { get; set; } 
        public string Telefono { get; set; }
        public string Direccion { get; set; }       // Pendiente para implementar en algo más
        [Required]
        public DateTime FechaContratacion { get; set; }
        public bool Activo { get; set; } = true; // Por defecto, un empleado está activo

        // Constructor Vacío para Entity Framework Core
        public Empleado() { } // Necesario para EF Core

        public Empleado(int id, string nombre, string email, string cargo, string departamento, string telefono, string direccion, DateTime fechaContratacion, bool activo)
        {
            Id = id;
            Nombre = nombre;
            Email = email;
            Cargo = cargo;
            Departamento = departamento;
            Telefono = telefono;
            Direccion = direccion;
            FechaContratacion = fechaContratacion;
            Activo = activo;
        }
    }
}
