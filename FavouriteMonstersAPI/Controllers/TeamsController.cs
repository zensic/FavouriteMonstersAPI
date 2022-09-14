using FavouriteMonstersAPI.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FavouriteMonstersAPI.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class TeamsController : ControllerBase
  {
    private readonly MonstersDbContext _context;

    public TeamsController(MonstersDbContext context)
    {
      _context = context;
    }
  }
}
