using Microsoft.AspNetCore.Mvc;
using ModaQuisqueya.Application.Contract;
using ModaQuisqueya.Application.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ModaQuisqueya.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TiendasController : ControllerBase
    {
        private readonly ITiendaService _tiendaService;

        public TiendasController(ITiendaService tiendaService)
        {
            _tiendaService = tiendaService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<TiendaDto>>> GetTodas()
        {
            var tiendas = await _tiendaService.ObtenerTodasAsync();
            return Ok(tiendas);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TiendaDto>> GetPorId(int id)
        {
            var tienda = await _tiendaService.ObtenerPorIdAsync(id);
            if (tienda == null) return NotFound();
            return Ok(tienda);
        }

        [HttpPost]
        public async Task<IActionResult> Agregar([FromBody] TiendaDto dto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            await _tiendaService.AgregarAsync(dto);
            return CreatedAtAction(nameof(GetPorId), new { id = dto.Id }, dto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Actualizar(int id, [FromBody] TiendaDto dto)
        {
            if (id != dto.Id) return BadRequest("El ID de la URL no coincide con el del cuerpo.");

            await _tiendaService.ActualizarAsync(dto);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Eliminar(int id)
        {
            var tienda = await _tiendaService.ObtenerPorIdAsync(id);
            if (tienda == null) return NotFound();

            await _tiendaService.EliminarAsync(id);
            return NoContent();
        }
    }
}
