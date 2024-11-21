using CrudColegio.Domain.DomainObjects;
using CrudColegio.Domain.Services;
using Microsoft.AspNetCore.Mvc;

namespace CrudColegio.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AlumnoController : ControllerBase
    {
        private readonly IAlumnoService _alumnoService;
        public AlumnoController (IAlumnoService alumnoService)
        {
            _alumnoService = alumnoService;
        }
        [HttpGet]
        public async Task<ActionResult<Contract.Alumnos>> Read()
        {
            try
            {
                var alumnos = await Leer();
                return Ok(alumnos);
            }
            catch (Exception)
            {
                return BadRequest("Error interno");
            }
        }
        [HttpPost]
        public async Task<ActionResult<int>> Create(Contract.Alumno alumno)
        {
            try
            {
                await Crear(alumno);
                return Ok(1);
            }
            catch (Exception)
            {
                return BadRequest("Error interno");
            }
        }
        [HttpPut]
        public async Task<ActionResult<int>> Update(Contract.Alumno alumno)
        {
            try
            {
                await Actualizar(alumno);
                return Ok(1);
            }
            catch (KeyNotFoundException ex)
            {
                return BadRequest(ex.Message);
            }
            
        }
        [HttpDelete]
        public async Task<ActionResult<int>> Delete(int id)
        {
            try
            {
                await Eliminar(id);
                return Ok(1);
            }
            catch (KeyNotFoundException ex)
            {
                return BadRequest(ex.Message);
            }
        }
        private async Task<Contract.Alumnos> Leer()
        {
            var alumnos = await _alumnoService.Read();
            Contract.Alumno[] alumnosDTO = alumnos.Select(alumno => new Contract.Alumno(
                alumno.Id, alumno.Nombre, alumno.Apellidos, alumno.Genero, alumno.FechaNacimiento))
                .ToArray();
            return new Contract.Alumnos(alumnosDTO);
        }
        private async Task Crear(Contract.Alumno alumno)
        {
            var alumnoBackend = new Alumno
            {
                Id = alumno.Id,
                Nombre = alumno.Nombre,
                Apellidos = alumno.Apellidos,
                Genero = alumno.Genero,
                FechaNacimiento = alumno.FechaNacimiento
            };
            await _alumnoService.Create(alumnoBackend);
        }
        private async Task Actualizar(Contract.Alumno alumno)
        {
            var alumnoBackend = new Alumno
            {
                Id = alumno.Id,
                Nombre = alumno.Nombre,
                Apellidos = alumno.Apellidos,
                Genero = alumno.Genero,
                FechaNacimiento = alumno.FechaNacimiento
            };
            await _alumnoService.Update(alumnoBackend);
        }
        private async Task Eliminar(int id)
        {
            await _alumnoService.Delete(id);
        }
    }
}
