using Microsoft.EntityFrameworkCore;

namespace CrudColegio.Domain.Database
{
    public interface ISqlServerRepository<T> where T : class
    {
        Task Create(T item);
        Task<IEnumerable<T>> Read();
        Task Update(T item);
        Task Delete(int id);
    }
    public abstract class SqlServerRepository<T> : ISqlServerRepository<T> where T : class
    {
        private readonly ApplicationContext _context;
        private readonly DbSet<T> _dbSet;
        public SqlServerRepository(ApplicationContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }
        public async Task Create(T item)
        {
            await _context.AddAsync(item);
            await _context.SaveChangesAsync();
        }
        public async Task<IEnumerable<T>> Read() => await _dbSet.ToListAsync();
        public async Task Update(T item)
        {
            _dbSet.Update(item);
            await _context.SaveChangesAsync();
        }
        public async Task Delete(int id)
        {
            var item = await GetByIdAsync(id);
            if (item != null)
            {
                _dbSet.Remove(item!);
                await _context.SaveChangesAsync();
            }
            else throw new KeyNotFoundException("No existe registro");
        }
        public async Task<T?> GetByIdAsync(object id)
        {
            return await _dbSet.FindAsync(id);
        }
    }
}
