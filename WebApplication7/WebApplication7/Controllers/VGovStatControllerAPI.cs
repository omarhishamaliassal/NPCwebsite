using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication7.Data;
using WebApplication7.Models;

[Route("api/[controller]")]
[ApiController]
public class VGovStatControllerAPI : ControllerBase
{
    private readonly ApplicationDbContext _context;

    public VGovStatControllerAPI(ApplicationDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<VGovStatAPI>>> GetVGovStats()
    {
        var stats = await _context.VGovStat.ToListAsync();
        return Ok(stats);
    }
}
