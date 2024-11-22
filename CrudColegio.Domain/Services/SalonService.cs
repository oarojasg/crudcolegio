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
    public interface ISalonService : ISqlServerRepository<AlumnoGrado>
    {
    }
    public class SalonService : SqlServerRepository<AlumnoGrado>, ISalonService
    {
        public SalonService(ApplicationContext context) : base(context) { }
    }
}
