using System;
using System.Collections.Generic;
using System.Text;

namespace BSBookstore.Domain.Contract
{
    public interface IBaseUnitOfWork
    {
        TRepository GetRepository<TRepository>() where TRepository : IRepository;
    }
}
