using CrudColegio.Domain.Database;
using CrudColegio.Domain.DomainObjects;

namespace CrudColegio.Domain.Services
{
    public interface IAlumnoService : ISqlServerRepository<Alumno>
    {
    }
    public class AlumnoService : SqlServerRepository<Alumno>, IAlumnoService
    {
        public AlumnoService(ApplicationContext context) : base(context) { }
    }
}
