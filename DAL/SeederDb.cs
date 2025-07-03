using Ofima_Management.DAL.Entities;

namespace Ofima_Management.DAL
{
    public class SeederDb
    {
        public static void SeedInicial(DataBaseContext context)
        {
            if (!context.Empleados.Any())
            {
                context.Empleados.AddRange(
                    new Empleado
                    {
                        Nombre = "Luisa Ríos",
                        Email = "luisa.rios@ofima.com",
                        Cargo = "Diseñadora UX",
                        Departamento = "Diseño",
                        Telefono = "3109876543",
                        Direccion = "Av. 80 # 30-15",
                        FechaContratacion = new DateTime(2023, 10, 09),
                        Activo = true
                    },
                    new Empleado
                    {
                        Nombre = "Julián Herrera",
                        Email = "julian.herrera@ofima.com",
                        Cargo = "Tester QA",
                        Departamento = "Calidad",
                        Telefono = "3006543210",
                        Direccion = "Calle 44 #22-11",
                        FechaContratacion = new DateTime(2023, 5, 18),
                        Activo = false
                    }
                );

                context.SaveChanges();
            }
        }
    }
}
