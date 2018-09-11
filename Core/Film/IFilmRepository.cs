using System.Threading.Tasks;

namespace StarWars.Core
{
    public interface IFilmRepository
    {
        Task<Film[]> Get();
        Task<Film> Get(int id);
        Task<Film> Get(string title);
        Task<Film> GetByEpisode(int episode);
        Task<int> Add(Film film);
    }
}
