using CrudColegio.Domain.DomainObjects;
using CrudColegio.Domain.Services;
using Microsoft.AspNetCore.Mvc;

namespace CrudColegio.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GradoController : ControllerBase
    {
        private readonly IGradoService _gradoService;
        public GradoController(IGradoService gradoService)
        {
            _gradoService = gradoService;
        }
        [HttpGet]
        public async Task<ActionResult<Contract.Grados>> Read()
        {
            try
            {
                var grados = await Leer();
                return Ok(grados);
            }
            catch (Exception)
            {
                return BadRequest("Error interno");
            }
        }
        [HttpPost]
        public async Task<ActionResult<int>> Create(Contract.Grado grado)
        {
            try
            {
                await Crear(grado);
                return Ok(1);
            }
            catch (Exception)
            {
                return BadRequest("Error interno");
            }
        }
        [HttpPut]
        public async Task<ActionResult<int>> Update(Contract.Grado grado)
        {
            try
            {
                await Actualizar(grado);
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
        private async Task<Contract.Grados> Leer()
        {
            var grados = await _gradoService.Read();
            Contract.Grado[] gradosDTO = grados.Select(grado => new Contract.Grado(
                grado.Id, grado.Nombre, grado.ProfesorId))
                .ToArray();
            return new Contract.Grados(gradosDTO);
        }
        private async Task Crear(Contract.Grado grado)
        {
            var gradoBackend = new Grado
            {
                Id = grado.Id,
                Nombre = grado.Nombre,
                ProfesorId = grado.ProfesorId
            };
            await _gradoService.Create(gradoBackend);
        }
        private async Task Actualizar(Contract.Grado grado)
        {
            var gradoBackend = new Grado
            {
                Id = grado.Id,
                Nombre = grado.Nombre,
                ProfesorId = grado.ProfesorId
            };
            await _gradoService.Update(gradoBackend);
        }
        private async Task Eliminar(int id)
        {
            await _gradoService.Delete(id);
        }
    }
}
