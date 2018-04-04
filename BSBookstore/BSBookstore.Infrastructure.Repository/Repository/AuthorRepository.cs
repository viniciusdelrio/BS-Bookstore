using BSBookstore.Domain.Contract;
using BSBookstore.Domain.Entity;
using BSBookstore.Infrastructure.Repository.Dapper;
using BSBookstore.Infrastructure.Repository.Mapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace BSBookstore.Infrastructure.Repository
{
    public class AuthorRepository : DapperRepository<Author>, IAuthorRepository
    { }
}
