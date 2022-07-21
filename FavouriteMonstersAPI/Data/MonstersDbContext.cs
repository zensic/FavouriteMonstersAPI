using FavouriteMonstersAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace FavouriteMonstersAPI.Data
{
    public class MonstersDbContext : DbContext
    {
        public MonstersDbContext(DbContextOptions<MonstersDbContext> options)
            : base(options)
        {
        }

        public DbSet<Monsters> Monsters { get; set; }
    }
}
