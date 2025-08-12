using Microsoft.AspNetCore.Mvc;
using ModaQuisqueya.Application.Contract;
using ModaQuisqueya.Application.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ModaQuisqueya.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TendenciasController : ControllerBase
    {
        private readonly ITendenciaService _tendenciaService;

        public TendenciasController(ITendenciaService tendenciaService)
        {
            _tendenciaService = tendenciaService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<TendenciaDto>>> GetTodas()
        {
            var tendencias = await _tendenciaService.ObtenerTodasAsync();
            return Ok(tendencias);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TendenciaDto>> GetPorId(int id)
        {
            var tendencia = await _tendenciaService.ObtenerPorIdAsync(id);
            if (tendencia == null) return NotFound();
            return Ok(tendencia);
        }

        [HttpPost]
        public async Task<IActionResult> Agregar([FromBody] TendenciaDto dto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            await _tendenciaService.AgregarAsync(dto);
            return CreatedAtAction(nameof(GetPorId), new { id = dto.Id }, dto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Actualizar(int id, [FromBody] TendenciaDto dto)
        {
            if (id != dto.Id) return BadRequest("El ID de la URL no coincide con el del cuerpo.");

            await _tendenciaService.ActualizarAsync(dto);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Eliminar(int id)
        {
            var existente = await _tendenciaService.ObtenerPorIdAsync(id);
            if (existente == null) return NotFound();

            await _tendenciaService.EliminarAsync(id);
            return NoContent();
        }
    }
}
