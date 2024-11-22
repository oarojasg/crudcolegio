using CrudColegio.Domain.Database;
using CrudColegio.Domain.DomainObjects;

namespace CrudColegio.Domain.Services
{
    public interface IGradoService : ISqlServerRepository<Grado>
    {
    }
    public class GradoService : SqlServerRepository<Grado>, IGradoService
    {
        public GradoService(ApplicationContext context) : base(context) { }
    }
}
