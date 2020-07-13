using Common.Collection;
using Models;
using System.Threading.Tasks;


namespace Repository.Interfaces
{
    public interface IPokemonRepository// : IReadRepository<Pokemon, int>
    {
        Task<DataCollection<Pokemon>> GetAllAsync(int page, int take);
        Task<Pokemon> GetByIdAsync(int id);
    }
}
