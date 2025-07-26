using Microsoft.AspNetCore.Mvc;
using ModaQuisqueya.Infrastructure.Interfaces;
using ModaQuisqueya.Infrastructure.Modelos;

namespace ModaQuisqueya.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DiseñadorController : ControllerBase
    {
        private readonly IDiseñadorRepositorio _repositorio;

        public DiseñadorController(IDiseñadorRepositorio repositorio)
        {
            _repositorio = repositorio;
        }

        [HttpGet]
        public async Task<ActionResult<List<DiseñadorModel>>> GetAll()
        {
            var diseñadores = await _repositorio.ObtenerTodosAsync();
            return Ok(diseñadores);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<DiseñadorModel>> GetById(int id)
        {
            var diseñador = await _repositorio.ObtenerPorIdAsync(id);
            if (diseñador == null) return NotFound();
            return Ok(diseñador);
        }

        [HttpPost]
        public async Task<ActionResult> Create(DiseñadorModel diseñador)
        {
            await _repositorio.CrearAsync(diseñador);
            return CreatedAtAction(nameof(GetById), new { id = diseñador.Id }, diseñador);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, DiseñadorModel diseñador)
        {
            if (id != diseñador.Id) return BadRequest("ID no coincide");
            await _repositorio.ActualizarAsync(diseñador);
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
