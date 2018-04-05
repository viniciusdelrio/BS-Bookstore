using BSBookstore.Domain.Contract;
using BSBookstore.Domain.Entity;
using BSBookstore.Infrastructure.Repository.Dapper;
using DapperExtensions;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace BSBookstore.Infrastructure.Repository
{
    public class CategoryRepository : DapperRepository<Category>, ICategoryRepository
    {
        /// <summary>
        /// Verifica se a categoria possui vinculo com algum outro registro
        /// </summary>
        /// <param name="category"></param>
        /// <returns></returns>
        public bool HasRelationship(Category category)
        {
            var p = Predicates.Field<Book>(x => x.IdCategory, Operator.Eq, category.Id);

            var book = _connection.GetList<Book>(Predicates.Exists<Book>(p)).FirstOrDefault();

            return book != null;
        }
    }
}
