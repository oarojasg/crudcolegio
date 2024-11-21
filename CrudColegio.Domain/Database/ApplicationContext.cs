using CrudColegio.Domain.DomainObjects;
using Microsoft.EntityFrameworkCore;

namespace CrudColegio.Domain.Database
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options)
            : base(options){ }
        public DbSet<Alumno>? Alumnos { get; set; }
        public DbSet<Profesor>? Profesores { get; set; }
        public DbSet<Grado>? Grados { get; set; }
        public DbSet<AlumnoGrado>? Salones { get; set; }
    }
}
