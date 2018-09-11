using System.Threading.Tasks;

namespace StarWars.Core
{
    public interface IDroidRepository
    {
        Task<Droid[]> Get();
        Task<Droid> Get(int id);
        Task<Droid> Get(string name);
        Task<int> Add(Droid droid);
    }
}
