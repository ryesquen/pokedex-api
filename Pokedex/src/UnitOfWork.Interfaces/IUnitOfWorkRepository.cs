using Repository.Interfaces;

namespace UnitOfWork.Interfaces
{
    public interface IUnitOfWorkRepository
    {
        IPokemonRepository IPokemonRepository { get; }
    }
}
