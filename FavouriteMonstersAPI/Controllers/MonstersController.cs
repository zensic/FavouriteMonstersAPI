using FavouriteMonstersAPI.Data;
using FavouriteMonstersAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FavouriteMonstersAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MonstersController : ControllerBase
    {
        private readonly MonstersDbContext _context;

        public MonstersController(MonstersDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IEnumerable<Monsters>> Get()
        {
            return await _context.Monsters.ToListAsync();
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(Monsters), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetById(int id)
        {
            var monster = await _context.Monsters.FindAsync(id);
            return monster == null ? NotFound() : Ok(monster);
        }

        [HttpPost]
        public async Task<IActionResult> Create(Monsters monster)
        {
            await _context.Monsters.AddAsync(monster);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetById), new {id = monster.Id}, monster);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Update(int id, Monsters monster)
        {
            if (id != monster.Id) return BadRequest();

            _context.Entry(monster).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var monsterToDelete = await _context.Monsters.FindAsync(id);
            if (monsterToDelete == null) return NotFound();

            _context.Monsters.Remove(monsterToDelete);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
