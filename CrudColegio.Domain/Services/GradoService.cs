using CrudColegio.Domain.Database;
using CrudColegio.Domain.DomainObjects;
using Microsoft.EntityFrameworkCore;

namespace CrudColegio.Domain.Services
{
    public interface IGradoService
    {
        Task Create(Grado grado);
        Task<IEnumerable<Grado>> Read();
        Task Update(Grado grado);
        Task Delete(int id);
    }
    public class GradoService : IGradoService
    {
        private readonly ApplicationContext _context;
        public GradoService(ApplicationContext context)
        {
            _context = context;
        }
        public async Task Create(Grado grado)
        {
            await _context.Grados!.AddAsync(grado);
            await _context.SaveChangesAsync();
        }
        public async Task<IEnumerable<Grado>> Read() => await _context.Grados!.ToListAsync();
        public async Task Update(Grado grado)
        {
            var gradoBD = _context.Grados!.Find(grado.Id);
            if (gradoBD != null)
            {
                gradoBD.Nombre = grado.Nombre;
                gradoBD.ProfesorId = grado.ProfesorId;
                await _context.SaveChangesAsync();
            }
            else throw new KeyNotFoundException("No existe registro");
        }
        public async Task Delete(int id)
        {
            var gradoBD = await _context.Grados!.FirstOrDefaultAsync(al => al.Id.Equals(id));
            if (gradoBD != null)
            {
                _context.Grados!.Remove(gradoBD);
                await _context.SaveChangesAsync();
            }
            else throw new KeyNotFoundException("No existe registro");
        }
    }
}
