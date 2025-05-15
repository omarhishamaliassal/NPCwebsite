using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication7.Data;
using WebApplication7.Models;

[Route("api/[controller]")]
[ApiController]
public class NewsControllerAPI : ControllerBase
{
    private readonly ApplicationDbContext _context;

    public NewsControllerAPI(ApplicationDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<object>>> GetNews()
    {
       
        var news = await _context.News
            .Where(n => n.IsActive == 1)
            .Select(n => new
            {
                n.Title,
                n.NewsText,
                n.SmallPhoto,
                n.LargPhoto,
                n.PublishDate,
                n.NewsSource,
                n.URL,
                n.OnClockTopic,
                n.OnMainPage
            })
            .ToListAsync();

        return Ok(news);
    }
}
