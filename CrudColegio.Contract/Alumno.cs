
namespace CrudColegio.Contract
{
    public record Alumno(int Id, string? Nombre, string? Apellidos, char? Genero, DateTime FechaNacimiento);
}
