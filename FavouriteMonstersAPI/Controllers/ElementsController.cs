using FavouriteMonstersAPI.Data;
using FavouriteMonstersAPI.Filters;
using FavouriteMonstersAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FavouriteMonstersAPI.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  [TokenAuthenticationFilter]
  public class ElementsController : ControllerBase
  {
    private readonly MonstersDbContext _context;

    public ElementsController(MonstersDbContext context)
    {
      _context = context;
    }

    [HttpGet]
    public async Task<IEnumerable<Elements>> Get()
    {
      return await _context.Elements.ToListAsync();
    }
  }
}
