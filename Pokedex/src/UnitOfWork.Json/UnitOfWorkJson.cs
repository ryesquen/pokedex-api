using UnitOfWork.Interfaces;

namespace UnitOfWork.Json
{
    public class UnitOfWorkJson : IUnitOfWork
    {
        public IUnitOfWorkAdapter Create()
        {
            return new UnitOfWorkJsonAdapter();
        }
    }
}