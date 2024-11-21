using CrudColegio.Domain.Database;
using CrudColegio.Domain.DomainObjects;
using Microsoft.EntityFrameworkCore;

namespace CrudColegio.Domain.Services
{
    public interface IAlumnoService
    {
        Task Create(Alumno alumno);
        Task<IEnumerable<Alumno>> Read();
        Task Update(Alumno alumno);
        Task Delete(int id);
    }
    public class AlumnoService : IAlumnoService
    {
        private readonly ApplicationContext _context;
        public AlumnoService(ApplicationContext context)
        {
            _context = context;
        }
        public async Task Create(Alumno alumno)
        {
            await _context.Alumnos!.AddAsync(alumno);
            await _context.SaveChangesAsync();
        }
        public async Task<IEnumerable<Alumno>> Read() => await _context.Alumnos!.ToListAsync();
        public async Task Update(Alumno alumno)
        {
            var alumnoBD = _context.Alumnos!.Find(alumno.Id);
            if (alumnoBD != null)
            {
                alumnoBD.Nombre = alumno.Nombre;
                alumnoBD.Apellidos = alumno.Apellidos;
                alumnoBD.Genero = alumno.Genero;
                alumnoBD.FechaNacimiento = alumno.FechaNacimiento;
                await _context.SaveChangesAsync();
            }
            else throw new KeyNotFoundException("No existe registro");
        }
        public async Task Delete(int id)
        {
            var alumnoBD = await _context.Alumnos!.FirstOrDefaultAsync(al => al.Id.Equals(id));
            if (alumnoBD != null)
            {
                _context.Alumnos!.Remove(alumnoBD);
                await _context.SaveChangesAsync();  
            }
            else throw new KeyNotFoundException("No existe registro");
        }
    }
}
