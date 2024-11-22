using CrudColegio.Domain.Database;
using CrudColegio.Domain.DomainObjects;

namespace CrudColegio.Domain.Services
{
    public interface IProfesorService : ISqlServerRepository<Profesor>
    {
    }
    public class ProfesorService : SqlServerRepository<Profesor>, IProfesorService
    {
        public ProfesorService(ApplicationContext context) : base(context) { }
    }
}
