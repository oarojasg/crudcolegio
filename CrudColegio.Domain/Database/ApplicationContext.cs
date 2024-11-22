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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Grado>()
                .HasOne(ag => ag.Profesor)
                .WithMany(a => a.Grados)
                .HasForeignKey(ag => ag.ProfesorId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<AlumnoGrado>()
                .HasOne(ag => ag.Grado)
                .WithMany(g => g.Salones)
                .HasForeignKey(ag => ag.GradoId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<AlumnoGrado>()
                .HasOne(ag => ag.Alumno)
                .WithMany(g => g.Salones)
                .HasForeignKey(ag => ag.AlumnoId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
