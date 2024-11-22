
namespace CrudColegio.Domain.DomainObjects
{
    public class Grado
    {
        public int Id { get; set; }
        public string? Nombre { get; set; }
        public int? ProfesorId { get; set; }
        public Profesor? Profesor { get; set; }
        public ICollection<AlumnoGrado>? Salones { get; set; }
    }
}
