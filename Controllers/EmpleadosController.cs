using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Ofima_Management.DAL;
using Ofima_Management.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ofima_Management.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmpleadosController : ControllerBase
    {
        private readonly DataBaseContext _context;

        public EmpleadosController(DataBaseContext context) => _context = context;

        // GET: api/empleados
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Empleado>>> GetEmpleados()
        {
            try
            {
                return await _context.Empleados.ToListAsync();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error interno del servidor: {ex.Message}");
            }
        }

        // GET: api/empleados/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<Empleado>> GetEmpleadoById(int id)
        {
            try
            {
                var empleado = await _context.Empleados.FindAsync(id);

                if (empleado == null)
                    return NotFound($"Empleado con ID {id} no encontrado.");

                return empleado;
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error interno del servidor: {ex.Message}");
            }
        }

        // POST: api/empleados
        [HttpPost]
        public async Task<ActionResult<Empleado>> CreateEmpleado([FromBody] Empleado empleado)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (empleado.FechaContratacion > DateTime.Now)
                return BadRequest("La fecha de contratación no puede estar en el futuro.");

            try
            {
                _context.Empleados.Add(empleado);
                await _context.SaveChangesAsync();

                return CreatedAtAction(nameof(GetEmpleadoById), new { id = empleado.Id }, empleado);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error interno del servidor: {ex.Message}");
            }
        }

        // PUT: api/empleados/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateEmpleado(int id, [FromBody] Empleado empleado)
        {
            if (id != empleado.Id)
                return BadRequest("El ID del empleado no coincide con el ID en la ruta.");

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (empleado.FechaContratacion > DateTime.Now)
                return BadRequest("La fecha de contratación no puede estar en el futuro.");

            try
            {
                var existingEmpleado = await _context.Empleados.FindAsync(id);
                if (existingEmpleado == null)
                    return NotFound($"Empleado con ID {id} no encontrado.");

                // Actualizar propiedades
                existingEmpleado.Nombre = empleado.Nombre;
                existingEmpleado.Email = empleado.Email;
                existingEmpleado.Cargo = empleado.Cargo;
                existingEmpleado.Departamento = empleado.Departamento;
                existingEmpleado.Telefono = empleado.Telefono;
                existingEmpleado.Direccion = empleado.Direccion;
                existingEmpleado.FechaContratacion = empleado.FechaContratacion;
                existingEmpleado.Activo = empleado.Activo;

                _context.Entry(existingEmpleado).State = EntityState.Modified;
                await _context.SaveChangesAsync();

                return NoContent();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.Empleados.Any(e => e.Id == id))
                    return NotFound($"Empleado con ID {id} no encontrado.");

                throw;
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error interno del servidor: {ex.Message}");
            }
        }

        // DELETE: api/empleados/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmpleado(int id)
        {
            try
            {
                var empleado = await _context.Empleados.FindAsync(id);
                if (empleado == null)
                    return NotFound($"Empleado con ID {id} no encontrado.");

                _context.Empleados.Remove(empleado);
                await _context.SaveChangesAsync();

                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error interno del servidor: {ex.Message}");
            }
        }
    }
}
