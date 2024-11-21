
namespace CrudColegio.Domain.DomainObjects
{
    public class AlumnoGrado
    {
        public int Id { get; set; }
        public int? AlumnoId { get; set; }
        public int? GradoId { get; set; }
        public int? Seccion { get; set; }
    }
}
