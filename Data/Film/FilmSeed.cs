using StarWars.Core;
using System;
using System.Linq;

namespace StarWars.Data
{
    public class FilmSeed
    {
        public FilmSeed(StarWarsContext db)
        {
            if (db.Films.Any())
                return;

            db.Films.AddRange(new Film[] {
                new Film { ReleaseDate = new DateTime(1977, 05, 25), Episode = 4, Title = "A New Hope" },
                new Film { ReleaseDate = new DateTime(1980, 05, 21), Episode = 5, Title = "The Empire Strikes Back" },
                new Film { ReleaseDate = new DateTime(1983, 05, 25), Episode = 6, Title = "Return of the Jedi" },
                new Film { ReleaseDate = new DateTime(1999, 05, 19), Episode = 1, Title = "The Phantom Menace" },
                new Film { ReleaseDate = new DateTime(2002, 05, 16), Episode = 2, Title = "Attack of the Clones" },
                new Film { ReleaseDate = new DateTime(2005, 05, 19), Episode = 3, Title = "Revenge of the Sith" },
                new Film { ReleaseDate = new DateTime(2015, 12, 18), Episode = 7, Title = "The Force Awakens" },
                new Film { ReleaseDate = new DateTime(2017, 12, 15), Episode = 8, Title = "The Last Jedi" },
                new Film { ReleaseDate = new DateTime(2019, 12, 20), Episode = 9, Title = "TBA" },
                new Film { ReleaseDate = new DateTime(2016, 12, 16), Title = "Rogue One" },
                new Film { ReleaseDate = new DateTime(2018, 05, 25), Title = "Solo" },
            });
            db.SaveChanges();
        }
    }
}
