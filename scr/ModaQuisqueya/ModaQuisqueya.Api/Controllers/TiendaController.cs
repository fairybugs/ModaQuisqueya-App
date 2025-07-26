using Microsoft.AspNetCore.Mvc;
using ModaQuisqueya.Infrastructure.Interfaces;
using ModaQuisqueya.Infrastructure.Modelos;

namespace ModaQuisqueya.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TiendaController : ControllerBase
    {
        private readonly ITiendaRepositorio _repositorio;

        public TiendaController(ITiendaRepositorio repositorio)
        {
            _repositorio = repositorio;
        }

        [HttpGet]
        public async Task<ActionResult<List<TiendaModel>>> GetAll()
        {
            var tiendas = await _repositorio.ObtenerTodosAsync();
            return Ok(tiendas);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TiendaModel>> GetById(int id)
        {
            var tienda = await _repositorio.ObtenerPorIdAsync(id);
            if (tienda == null) return NotFound();
            return Ok(tienda);
        }

        [HttpPost]
        public async Task<ActionResult> Create(TiendaModel tienda)
        {
            await _repositorio.CrearAsync(tienda);
            return CreatedAtAction(nameof(GetById), new { id = tienda.Id }, tienda);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, TiendaModel tienda)
        {
            if (id != tienda.Id) return BadRequest("ID no coincide");
            await _repositorio.ActualizarAsync(tienda);
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

