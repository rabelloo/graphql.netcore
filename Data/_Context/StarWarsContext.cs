using Microsoft.EntityFrameworkCore;
using StarWars.Core;

namespace StarWars.Data
{
    public class StarWarsContext : DbContext
    {
        public StarWarsContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Droid> Droids { get; set; }
        public DbSet<Film> Films { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .ApplyConfiguration(new DroidConfig())
                .ApplyConfiguration(new FilmConfig())
                ;
        }
    }
}
