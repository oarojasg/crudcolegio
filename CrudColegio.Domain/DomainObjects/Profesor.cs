
namespace CrudColegio.Domain.DomainObjects
{
    public class Profesor
    {
        public int Id { get; set; }
        public string? Nombre { get; set; }
        public string? Apellidos { get; set; }
        public char? Genero { get; set; }
        public ICollection<Grado>? Grados { get; set; }
    }
}
