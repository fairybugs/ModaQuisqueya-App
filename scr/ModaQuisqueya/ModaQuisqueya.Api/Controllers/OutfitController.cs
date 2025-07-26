using Microsoft.AspNetCore.Mvc;
using ModaQuisqueya.Infrastructure.Interfaces;
using ModaQuisqueya.Infrastructure.Modelos;
using ModaQusiqueya.Infrastructure.Modelos;

namespace ModaQuisqueya.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OutfitController : ControllerBase
    {
        private readonly IOutfitRepositorio _repositorio;

        public OutfitController(IOutfitRepositorio repositorio)
        {
            _repositorio = repositorio;
        }

        [HttpGet]
        public async Task<ActionResult<List<OutfitModel>>> GetAll()
        {
            var outfits = await _repositorio.ObtenerTodosAsync();
            return Ok(outfits);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<OutfitModel>> GetById(int id)
        {
            var outfit = await _repositorio.ObtenerPorIdAsync(id);
            if (outfit == null) return NotFound();
            return Ok(outfit);
        }

        [HttpPost]
        public async Task<ActionResult> Create(OutfitModel outfit)
        {
            await _repositorio.CrearAsync(outfit);
            return CreatedAtAction(nameof(GetById), new { id = outfit.Id }, outfit);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, OutfitModel outfit)
        {
            if (id != outfit.Id) return BadRequest("ID no coincide");
            await _repositorio.ActualizarAsync(outfit);
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
