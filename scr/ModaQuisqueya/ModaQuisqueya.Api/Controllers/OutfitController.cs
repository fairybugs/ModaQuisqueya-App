using Microsoft.AspNetCore.Mvc;
using ModaQuisqueya.Application.Contract;
using ModaQuisqueya.Application.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ModaQuisqueya.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OutfitsController : ControllerBase
    {
        private readonly IOutfitService _outfitService;

        public OutfitsController(IOutfitService outfitService)
        {
            _outfitService = outfitService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<OutfitDto>>> GetTodos()
        {
            var outfits = await _outfitService.ObtenerTodosAsync();
            return Ok(outfits);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<OutfitDto>> GetPorId(int id)
        {
            var outfit = await _outfitService.ObtenerPorIdAsync(id);
            if (outfit == null) return NotFound();
            return Ok(outfit);
        }

        [HttpPost]
        public async Task<IActionResult> Agregar([FromBody] OutfitDto dto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            await _outfitService.AgregarAsync(dto);
            return CreatedAtAction(nameof(GetPorId), new { id = dto.Id }, dto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Actualizar(int id, [FromBody] OutfitDto dto)
        {
            if (id != dto.Id) return BadRequest("El ID de la URL no coincide con el del cuerpo.");

            await _outfitService.ActualizarAsync(dto);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Eliminar(int id)
        {
            var outfit = await _outfitService.ObtenerPorIdAsync(id);
            if (outfit == null) return NotFound();

            await _outfitService.EliminarAsync(id);
            return NoContent();
        }
    }
}
