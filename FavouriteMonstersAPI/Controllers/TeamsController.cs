using FavouriteMonstersAPI.Data;
using FavouriteMonstersAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

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

    // Returns a list of team display objects based on current logged in user
    [HttpGet("{id}")]
    public async Task<IActionResult> GetTeamsById(Guid id)
    {
      // Grab all teams from current logged in user
      List<TeamDisplay> teamDisplayList = new();
      teamDisplayList = await (from teams in _context.Teams
                               where teams.UserId == id
                               select new TeamDisplay(
                                 teams.Id,
                                 teams.UserId,
                                 teams.CreatedAt
                                 ))
                                  .AsNoTracking()
                                  .ToListAsync();

      // Populate the monster teams with userId and datetime
      if (teamDisplayList.Count > 0)
      {
        // Populate the monster teams into the teamList
        for (int i = 0; i < teamDisplayList.Count; i++)
        {
          // Grab monster ids of monsters in the team
          List<Monsters> monstersList = await (from teamMonsters in _context.TeamMonsters
                                               join monsters in _context.Monsters on teamMonsters.MonsterId equals monsters.Id
                                               where teamMonsters.TeamId == teamDisplayList[i].Id
                                               select monsters)
                                              .AsNoTracking()
                                              .ToListAsync();
        }

        return Ok(teamDisplayList);
      }
      else
      {
        return Ok(teamDisplayList);
      }
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    public async Task<IActionResult> CreateTeam([FromBody] TeamNew teamNew)
    {
      // Generate unique id for teams
      Guid teamGuid = Guid.NewGuid();

      // Add each selected team monster to team monsters table
      foreach (Guid teamMonsterId in teamNew.MonsterIds)
      {
        _context.Add(new TeamMonsters(teamGuid, teamMonsterId));
        await _context.SaveChangesAsync();
      }

      // Add new team to teams table
      Teams teamTemp = new();
      teamTemp.Id = teamGuid;
      teamTemp.UserId = Guid.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));

      _context.Add(teamTemp);
      await _context.SaveChangesAsync();

      return CreatedAtAction(nameof(CreateTeam), new { id = teamTemp.Id}, teamTemp);
    }
  }
}
