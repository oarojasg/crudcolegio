using CrudColegio.Domain.DomainObjects;
using CrudColegio.Domain.Services;
using Microsoft.AspNetCore.Mvc;

namespace CrudColegio.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SalonController : ControllerBase
    {
        private readonly ISalonService _salonService;
        public SalonController(ISalonService salonService)
        {
            _salonService = salonService;
        }
        [HttpGet]
        public async Task<ActionResult<Contract.Salones>> Read()
        {
            try
            {
                var salones = await Leer();
                return Ok(salones);
            }
            catch (Exception)
            {
                return BadRequest("Error interno");
            }
        }
        [HttpPost]
        public async Task<ActionResult<int>> Create(Contract.Salon salon)
        {
            try
            {
                await Crear(salon);
                return Ok(1);
            }
            catch (Exception)
            {
                return BadRequest("Error interno");
            }
        }
        [HttpPut]
        public async Task<ActionResult<int>> Update(Contract.Salon salon)
        {
            try
            {
                await Actualizar(salon);
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
        private async Task<Contract.Salones> Leer()
        {
            var salones = await _salonService.Read();
            Contract.Salon[] salonesDTO = salones.Select(salon => new Contract.Salon(
                salon.Id, salon.AlumnoId, salon.GradoId, salon.Seccion))
                .ToArray();
            return new Contract.Salones(salonesDTO);
        }
        private async Task Crear(Contract.Salon salon)
        {
            var salonBackend = new AlumnoGrado
            {
                Id = salon.Id,
                AlumnoId = salon.AlumnoId,
                GradoId = salon.GradoId,
                Seccion = salon.Seccion
            };
            await _salonService.Create(salonBackend);
        }
        private async Task Actualizar(Contract.Salon salon)
        {
            var salonBackend = new AlumnoGrado
            {
                Id = salon.Id,
                AlumnoId = salon.AlumnoId,
                GradoId = salon.GradoId,
                Seccion = salon.Seccion
            };
            await _salonService.Update(salonBackend);
        }
        private async Task Eliminar(int id)
        {
            await _salonService.Delete(id);
        }
    }
}
