using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using ModaQuisqueya.Api.Data;

[ApiController]
[Route("api/prueba")]
public class PruebaController : ControllerBase
{
    private readonly ModaQuisqueyaDbContext _context;

    public PruebaController(ModaQuisqueyaDbContext context)
    {
        _context = context;
    }

    [HttpGet("diseñadores")]
    public async Task<IActionResult> GetDiseñadores()
    {
        var lista = await _context.Diseñadores.ToListAsync();
        return Ok(lista);
    }
}
