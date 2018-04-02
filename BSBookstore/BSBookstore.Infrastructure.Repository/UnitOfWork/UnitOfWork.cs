using BSBookstore.Domain.Contract;
using BSBookstore.Infrastructure.Repository.Dapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace BSBookstore.Infrastructure.Repository
{
    public class UnitOfWork : DapperUnitOfWork, IUnitOfWork
    {
        public IAuthorRepository AuthorRepository => GetRepository<IAuthorRepository>();
    }
}
