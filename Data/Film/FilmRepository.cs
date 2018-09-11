using Microsoft.EntityFrameworkCore;
using StarWars.Core;
using System.Linq;
using System.Threading.Tasks;

namespace StarWars.Data
{
    public class FilmRepository : IFilmRepository
    {
        private readonly StarWarsContext _db;

        public FilmRepository(StarWarsContext context)
        {
            _db = context;
        }

        public Task<Film[]> Get()
        {
            return _db.Films.ToArrayAsync();
        }

        public Task<Film> Get(int id)
        {
            return _db.Films.FindAsync(id);
        }

        public Task<Film> Get(string title)
        {
            return _db.Films.Where(d => d.Title == title).FirstOrDefaultAsync();
        }

        public Task<Film> GetByEpisode(int episode)
        {
            return _db.Films.Where(d => d.Episode == episode).FirstOrDefaultAsync();
        }

        public async Task<int> Add(Film film)
        {
            _db.Films.Add(film);
            await _db.SaveChangesAsync();
            
            return film.Id;
        }
    }
}
