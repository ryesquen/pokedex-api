using Common.Collection;
using Models;
using System.Threading.Tasks;
using UnitOfWork.Interfaces;

namespace Services
{
    public interface IPokemonService
    {
        Task<DataCollection<Pokemon>> GetAllAsync(int page, int take);
        Task<Pokemon> GetAsync(int id);
    }
    public class PokemonService : IPokemonService
    {
        private readonly IUnitOfWork _unitOfWork;
        public PokemonService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<DataCollection<Pokemon>> GetAllAsync(int page, int take)
        {
            using (var context = _unitOfWork.Create())
            {
                return await context.Repositories.IPokemonRepository.GetAllAsync(page, take);
            }
        }

        public async Task<Pokemon> GetAsync(int id)
        {
            using (var context = _unitOfWork.Create())
            {
                var result = await context.Repositories.IPokemonRepository.GetByIdAsync(id);

                return result;
            }
        }
    }
}
