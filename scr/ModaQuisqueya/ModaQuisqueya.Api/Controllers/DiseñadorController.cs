using Microsoft.AspNetCore.Mvc;
using ModaQuisqueya.Application.Contract;
using ModaQuisqueya.Application.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ModaQuisqueya.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DiseñadoresController : ControllerBase
    {
        private readonly IDiseñadorService _diseñadorService;

        public DiseñadoresController(IDiseñadorService diseñadorService)
        {
            _diseñadorService = diseñadorService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<DiseñadorDto>>> GetTodos()
        {
            var diseñadores = await _diseñadorService.ObtenerTodosAsync();
            return Ok(diseñadores);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<DiseñadorDto>> GetPorId(int id)
        {
            var diseñador = await _diseñadorService.ObtenerPorIdAsync(id);
            if (diseñador == null) return NotFound();
            return Ok(diseñador);
        }

        [HttpPost]
        public async Task<IActionResult> Agregar([FromBody] DiseñadorDto dto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            await _diseñadorService.AgregarAsync(dto);
            return CreatedAtAction(nameof(GetPorId), new { id = dto.Id }, dto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Actualizar(int id, [FromBody] DiseñadorDto dto)
        {
            if (id != dto.Id)
                return BadRequest("El ID de la URL no coincide con el del cuerpo.");

            await _diseñadorService.ActualizarAsync(dto);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Eliminar(int id)
        {
            var diseñador = await _diseñadorService.ObtenerPorIdAsync(id);
            if (diseñador == null) return NotFound();

            await _diseñadorService.EliminarAsync(id);
            return NoContent();
        }
    }
}
