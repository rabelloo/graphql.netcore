using StarWars.Core;
using System.Linq;

namespace StarWars.Data
{
    public class DroidSeed
    {
        public DroidSeed(StarWarsContext db)
        {
            if (db.Droids.Any())
                return;

            db.Droids.AddRange(new Droid[] {
                new Droid { Name = "R2-D2" },
                new Droid { Name = "C3PO" }
            });
            db.SaveChanges();
        }
    }
}
