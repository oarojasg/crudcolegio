
namespace CrudColegio.Domain.DomainObjects
{
    public class Alumno
    {
        public int Id { get; set; }
        public string? Nombre { get; set; }
        public string? Apellidos { get; set; }
        public char? Genero { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public ICollection<AlumnoGrado>? Salones { get; set; }
    }
}
