using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication7.Data;
using WebApplication7.Models;

[Route("api/[controller]")]
[ApiController]
public class AboutControllerAPI : ControllerBase
{
    private readonly ApplicationDbContext _context;

    public AboutControllerAPI(ApplicationDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<AboutAPI>>> GetAbout()
    {
        var about = await _context.About.ToListAsync();
        return Ok(about);
    }
}
