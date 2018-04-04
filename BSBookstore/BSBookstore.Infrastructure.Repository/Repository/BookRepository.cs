using BSBookstore.Domain.Contract;
using BSBookstore.Domain.Entity;
using BSBookstore.Infrastructure.Repository.Dapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace BSBookstore.Infrastructure.Repository
{
    public class BookRepository : DapperRepository<Book>, IBookRepository
    { }
}
