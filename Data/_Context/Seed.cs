using StarWars.Core;

namespace StarWars.Data
{
    public class StarWarsSeed
    {
        public StarWarsSeed(StarWarsContext db)
        {
            new DroidSeed(db);
            new FilmSeed(db);
        }
    }
}
