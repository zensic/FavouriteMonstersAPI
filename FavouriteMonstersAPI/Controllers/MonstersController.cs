using FavouriteMonstersAPI.Data;
using FavouriteMonstersAPI.Filters;
using FavouriteMonstersAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FavouriteMonstersAPI.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  [TokenAuthenticationFilter]
  public class MonstersController : ControllerBase
  {
    private readonly MonstersDbContext _context;

    public MonstersController(MonstersDbContext context)
    {
      _context = context;
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
      var monsterList = await (from monsters in _context.Monsters
                               join elements in _context.Elements on monsters.ElementId equals elements.Id
                               select new
                               {
                                 Id = monsters.Id,
                                 Name = monsters.Name,
                                 Element = elements.Name,
                                 Color = elements.Color,
                                 Url = monsters.ImageUrl
                               })
                              .AsNoTracking()
                              .ToListAsync();

      return Ok(monsterList);
    }

    [HttpGet("{id}")]
    [ProducesResponseType(typeof(Monsters), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetById(Guid id)
    {
      var monster = await _context.Monsters.FindAsync(id);
      return monster == null ? NotFound() : Ok(monster);
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    public async Task<IActionResult> Create([FromBody] Monsters monster)
    {
      await _context.Monsters.AddAsync(monster);
      await _context.SaveChangesAsync();

      return CreatedAtAction(nameof(GetById), new { id = monster.Id }, monster);
    }

    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Update(Guid id, [FromBody] Monsters monster)
    {
      if (id != monster.Id) return BadRequest();

      _context.Entry(monster).State = EntityState.Modified;
      await _context.SaveChangesAsync();

      return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(Guid id)
    {
      var monsterToDelete = await _context.Monsters.FindAsync(id);
      if (monsterToDelete == null) return NotFound();

      _context.Monsters.Remove(monsterToDelete);
      await _context.SaveChangesAsync();

      return NoContent();
    }
  }
}
