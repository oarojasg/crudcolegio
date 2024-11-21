using CrudColegio.Domain.DomainObjects;
using CrudColegio.Domain.Services;
using Microsoft.AspNetCore.Mvc;

namespace CrudColegio.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProfesorController : ControllerBase
    {
        private readonly IProfesorService _profesorService;
        public ProfesorController(IProfesorService profesorService)
        {
            _profesorService = profesorService;
        }
        [HttpGet]
        public async Task<ActionResult<Contract.Profesores>> Read()
        {
            try
            {
                var profesores = await Leer();
                return Ok(profesores);
            }
            catch (Exception)
            {
                return BadRequest("Error interno");
            }
        }
        [HttpPost]
        public async Task<ActionResult<int>> Create(Contract.Profesor profesor)
        {
            try
            {
                await Crear(profesor);
                return Ok(1);
            }
            catch (Exception)
            {
                return BadRequest("Error interno");
            }
        }
        [HttpPut]
        public async Task<ActionResult<int>> Update(Contract.Profesor profesor)
        {
            try
            {
                await Actualizar(profesor);
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
        private async Task<Contract.Profesores> Leer()
        {
            var profesores = await _profesorService.Read();
            Contract.Profesor[] profesoresDTO = profesores.Select(profesor => new Contract.Profesor(
                profesor.Id, profesor.Nombre, profesor.Apellidos, profesor.Genero))
                .ToArray();
            return new Contract.Profesores(profesoresDTO);
        }
        private async Task Crear(Contract.Profesor profesor)
        {
            var profesorBackend = new Profesor
            {
                Id = profesor.Id,
                Nombre = profesor.Nombre,
                Apellidos = profesor.Apellidos,
                Genero = profesor.Genero
            };
            await _profesorService.Create(profesorBackend);
        }
        private async Task Actualizar(Contract.Profesor profesor)
        {
            var profesorBackend = new Profesor
            {
                Id = profesor.Id,
                Nombre = profesor.Nombre,
                Apellidos = profesor.Apellidos,
                Genero = profesor.Genero
            };
            await _profesorService.Update(profesorBackend);
        }
        private async Task Eliminar(int id)
        {
            await _profesorService.Delete(id);
        }
    }
}
