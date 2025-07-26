using Microsoft.AspNetCore.Mvc;
using ModaQuisqueya.Infrastructure.Interfaces;
using ModaQuisqueya.Infrastructure.Modelos;
using ModaQusiqueya.Infrastructure.Modelos;

namespace ModaQuisqueya.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TendenciaController : ControllerBase
    {
        private readonly ITendenciaRepositorio _repositorio;

        public TendenciaController(ITendenciaRepositorio repositorio)
        {
            _repositorio = repositorio;
        }

        [HttpGet]
        public async Task<ActionResult<List<TendenciaModel>>> GetAll()
        {
            var tendencias = await _repositorio.ObtenerTodosAsync();
            return Ok(tendencias);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TendenciaModel>> GetById(int id)
        {
            var tendencia = await _repositorio.ObtenerPorIdAsync(id);
            if (tendencia == null) return NotFound();
            return Ok(tendencia);
        }

        [HttpPost]
        public async Task<ActionResult> Create(TendenciaModel tendencia)
        {
            await _repositorio.CrearAsync(tendencia);
            return CreatedAtAction(nameof(GetById), new { id = tendencia.Id }, tendencia);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, TendenciaModel tendencia)
        {
            if (id != tendencia.Id) return BadRequest("ID no coincide");
            await _repositorio.ActualizarAsync(tendencia);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await _repositorio.EliminarAsync(id);
            return NoContent();
        }
    }
}
