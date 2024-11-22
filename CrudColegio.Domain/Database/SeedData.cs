using CrudColegio.Domain.DomainObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrudColegio.Domain.Database
{
    public static class SeedData
    {
        public static async Task Initialize(IServiceProvider serviceProvider)
        {
            using var context = new ApplicationContext(serviceProvider
                .GetRequiredService<DbContextOptions<ApplicationContext>>());
            await context.Database.EnsureCreatedAsync();

            if (await context.Alumnos!.AnyAsync())
            {
                return;   // DB has been seeded
            }

            // Alumnos
            var thomas = await context.AddAsync(new Alumno { Nombre = "Thomas", Apellidos = "Fringe", Genero = 'M', FechaNacimiento = new DateTime(2008, 06, 06) });
            var jane = await context.AddAsync(new Alumno { Nombre = "Jane", Apellidos = "Haircomb", Genero = 'F', FechaNacimiento = new DateTime(2010, 02, 25) });
            var william = await context.AddAsync(new Alumno { Nombre = "William", Apellidos = "Scissors", Genero = 'M', FechaNacimiento = new DateTime(2015, 11, 14) });
            var jessica = await context.AddAsync(new Alumno { Nombre = "Jessica", Apellidos = "Clipper", Genero = 'F', FechaNacimiento = new DateTime(2010, 08, 30) });
            var edward = await context.AddAsync(new Alumno { Nombre = "Edward", Apellidos = "Sideburn", Genero = 'M', FechaNacimiento = new DateTime(2012, 04, 22) });
            await context.AddAsync(new Alumno { Nombre = "Oliver", Apellidos = "Bold", Genero = 'M', FechaNacimiento = new DateTime(2013, 12, 10) });

            context.SaveChanges();

            if (await context.Profesores!.AnyAsync())
            {
                return;   // DB has been seeded
            }

            // Profesores
            var claudia = await context.AddAsync(new Profesor { Nombre = "Claudia", Apellidos = "González", Genero = 'F' });
            var nestor = await context.AddAsync(new Profesor { Nombre = "Nestor", Apellidos = "Lorenzo", Genero = 'M' });
            await context.AddAsync(new Profesor { Nombre = "Gabriel", Apellidos = "Iglesias", Genero = 'M' });
            await context.AddAsync(new Profesor { Nombre = "Carlos", Apellidos = "Marínez", Genero = 'M' });
            await context.AddAsync(new Profesor { Nombre = "Gloria Inés", Apellidos = "Duarte", Genero = 'F' });
            await context.AddAsync(new Profesor { Nombre = "Alex", Apellidos = "Cancino Romero", Genero = 'M' });

            context.SaveChanges();

            if (await context.Grados!.AnyAsync())
            {
                return;   // DB has been seeded
            }

            // Grados
            var salon601 = await context.AddAsync(new Grado { Nombre = "601", ProfesorId = claudia.Entity.Id });
            var salon1103 = await context.AddAsync(new Grado { Nombre = "1103", ProfesorId = nestor.Entity.Id });
            await context.AddAsync(new Grado { Nombre = "702", ProfesorId = claudia.Entity.Id });

            context.SaveChanges();

            if (await context.Salones!.AnyAsync())
            {
                return;   // DB has been seeded
            }

            // Salones
            await context.AddAsync(new AlumnoGrado { AlumnoId = thomas.Entity.Id, GradoId = salon601.Entity.Id, Seccion = 5 });
            await context.AddAsync(new AlumnoGrado { AlumnoId = jane.Entity.Id, GradoId = salon601.Entity.Id, Seccion = 6 });
            await context.AddAsync(new AlumnoGrado { AlumnoId = william.Entity.Id, GradoId = salon1103.Entity.Id, Seccion = 4 });
            await context.AddAsync(new AlumnoGrado { AlumnoId = jessica.Entity.Id, GradoId = salon1103.Entity.Id, Seccion = 3 });
            await context.AddAsync(new AlumnoGrado { AlumnoId = edward.Entity.Id, GradoId = salon1103.Entity.Id, Seccion = 2 });

            context.SaveChanges();
        }
    }
}
