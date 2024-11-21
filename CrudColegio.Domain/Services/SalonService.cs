using CrudColegio.Domain.Database;
using CrudColegio.Domain.DomainObjects;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrudColegio.Domain.Services
{
    public interface ISalonService
    {
        Task Create(AlumnoGrado salon);
        Task<IEnumerable<AlumnoGrado>> Read();
        Task Update(AlumnoGrado salon);
        Task Delete(int id);
    }
    public class SalonService : ISalonService
    {
        private readonly ApplicationContext _context;
        public SalonService(ApplicationContext context)
        {
            _context = context;
        }
        public async Task Create(AlumnoGrado salon)
        {
            await _context.Salones!.AddAsync(salon);
            await _context.SaveChangesAsync();
        }
        public async Task<IEnumerable<AlumnoGrado>> Read() => await _context.Salones!.ToListAsync();
        public async Task Update(AlumnoGrado salon)
        {
            var salonBD = _context.Salones!.Find(salon.Id);
            if (salonBD != null)
            {
                salonBD.AlumnoId = salon.AlumnoId;
                salonBD.GradoId = salon.GradoId;
                salonBD.Seccion = salon.Seccion;
                await _context.SaveChangesAsync();
            }
            else throw new KeyNotFoundException("No existe registro");
        }
        public async Task Delete(int id)
        {
            var salonBD = await _context.Salones!.FirstOrDefaultAsync(al => al.Id.Equals(id));
            if (salonBD != null)
            {
                _context.Salones!.Remove(salonBD);
                await _context.SaveChangesAsync();
            }
            else throw new KeyNotFoundException("No existe registro");
        }
    }
}
