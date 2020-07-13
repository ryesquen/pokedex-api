using System;
using UnitOfWork.Interfaces;

namespace UnitOfWork.Json
{
    public class UnitOfWorkJsonAdapter : IUnitOfWorkAdapter
    {
        public IUnitOfWorkRepository Repositories { get; set; }

        public UnitOfWorkJsonAdapter()
        {
            Repositories = new UnitOfWorkJsonRepository();
        }
        public void Dispose()
        {
            Repositories = null;
        }
    }
}