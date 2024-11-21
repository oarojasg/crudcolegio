using CrudColegio.Domain.Database;
using CrudColegio.Domain.DomainObjects;
using Microsoft.EntityFrameworkCore;

namespace CrudColegio.Domain.Services
{
    public interface IProfesorService
    {
        Task Create(Profesor profesor);
        Task<IEnumerable<Profesor>> Read();
        Task Update(Profesor profesor);
        Task Delete(int id);
    }
    public class ProfesorService : IProfesorService
    {
        private readonly ApplicationContext _context;
        public ProfesorService(ApplicationContext context)
        {
            _context = context;
        }
        public async Task Create(Profesor profesor)
        {
            await _context.Profesores!.AddAsync(profesor);
            await _context.SaveChangesAsync();
        }
        public async Task<IEnumerable<Profesor>> Read() => await _context.Profesores!.ToListAsync();
        public async Task Update(Profesor profesor)
        {
            var profesorBD = _context.Profesores!.Find(profesor.Id);
            if (profesorBD != null)
            {
                profesorBD.Nombre = profesor.Nombre;
                profesorBD.Apellidos = profesor.Apellidos;
                profesorBD.Genero = profesor.Genero;
                await _context.SaveChangesAsync();
            }
            else throw new KeyNotFoundException("No existe registro");
        }
        public async Task Delete(int id)
        {
            var profesorBD = await _context.Profesores!.FirstOrDefaultAsync(al => al.Id.Equals(id));
            if (profesorBD != null)
            {
                _context.Profesores!.Remove(profesorBD);
                await _context.SaveChangesAsync();
            }
            else throw new KeyNotFoundException("No existe registro");
        }
    }
}
