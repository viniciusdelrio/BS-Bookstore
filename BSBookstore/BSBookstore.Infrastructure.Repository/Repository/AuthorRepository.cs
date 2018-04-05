using BSBookstore.Domain.Contract;
using BSBookstore.Domain.Entity;
using BSBookstore.Infrastructure.Repository.Dapper;
using BSBookstore.Infrastructure.Repository.Mapper;
using System;
using System.Collections.Generic;
using System.Text;
using DapperExtensions;
using System.Linq;

namespace BSBookstore.Infrastructure.Repository
{
    public class AuthorRepository : DapperRepository<Author>, IAuthorRepository
    {
        /// <summary>
        /// Verifica se o autor possui vinculo com algum outro registro
        /// </summary>
        /// <param name="author"></param>
        /// <returns></returns>
        public bool HasRelationship(Author author)
        {
            var p = Predicates.Field<Book>(x => x.IdAuthor, Operator.Eq, author.Id);

            var book = _connection.GetList<Book>(Predicates.Exists<Book>(p)).FirstOrDefault();

            return book != null;
        }
    }
}
