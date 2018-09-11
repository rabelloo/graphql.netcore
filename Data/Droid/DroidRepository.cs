using Microsoft.EntityFrameworkCore;
using StarWars.Core;
using System.Linq;
using System.Threading.Tasks;

namespace StarWars.Data
{
    public class DroidRepository : IDroidRepository
    {
        private readonly StarWarsContext _db;

        public DroidRepository(StarWarsContext context)
        {
            _db = context;
        }

        public Task<Droid[]> Get()
        {
            return _db.Droids.ToArrayAsync();
        }

        public Task<Droid> Get(int id)
        {
            return _db.Droids.FindAsync(id);
        }

        public Task<Droid> Get(string name)
        {
            return _db.Droids.Where(d => d.Name == name).FirstOrDefaultAsync();
        }

        public async Task<int> Add(Droid droid)
        {
            _db.Droids.Add(droid);
            await _db.SaveChangesAsync();
            
            return droid.Id;
        }
    }
}
