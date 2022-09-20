using FavouriteMonstersAPI.Models;
using FavouriteMonstersAPI.TokenAuthentication;
using Microsoft.EntityFrameworkCore;

namespace FavouriteMonstersAPI.Data
{
  public class MonstersDbContext : DbContext
  {
    public MonstersDbContext(DbContextOptions<MonstersDbContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
      builder.Entity<Elements>().HasData(
          new Elements { Name = "Fire", Color = "#cf3b47" },
          new Elements { Name = "Water", Color = "#4f6cd0" },
          new Elements { Name = "Grass", Color = "#5d7a28" },
          new Elements { Name = "Electric", Color = "#ffbf00" }
          );
    }

    public DbSet<Monsters> Monsters { get; set; }
    public DbSet<Elements> Elements { get; set; }
    public DbSet<Token> Tokens { get; set; }
    public DbSet<Teams> Teams { get; set; }
    public DbSet<TeamMonsters> TeamMonsters { get; set; }
  }
}
