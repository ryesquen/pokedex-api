using Repository.Interfaces;
using Repository.Json;
using UnitOfWork.Interfaces;

namespace UnitOfWork.Json
{
    public class UnitOfWorkJsonRepository : IUnitOfWorkRepository
    { 
        public IPokemonRepository IPokemonRepository { get; }

        public UnitOfWorkJsonRepository()
        {
            IPokemonRepository = new PokemonRepository();
        }

    }
}