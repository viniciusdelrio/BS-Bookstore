using BSBookstore.Domain.Contract;
using BSBookstore.Domain.Entity;
using BSBookstore.Infrastructure.Repository.Dapper;
using System;
using System.Collections.Generic;
using System.Text;
using Dapper;
using System.Linq;

namespace BSBookstore.Infrastructure.Repository
{
    public class BookRepository : DapperRepository<Book>, IBookRepository
    {
        /// <summary>
        /// Lista todos os livros
        /// </summary>
        /// <returns></returns>
        public override IList<Book> GetAll()
        {
            string sql = @"SELECT
                                *

                           FROM
                                Book

                                INNER JOIN Author
                                ON Book.IdAuthor = Author.Id

                                INNER JOIN Category
                                ON Book.IdCategory = Category.Id

                           ORDER BY
                                Book.Title";

            var result =_connection.Query<Book, Author, Category, Book>(sql, (book, author, category) =>
            {
                book.Author = author;
                book.Category = category;

                return book;
            });

            return result.ToList();

        }
    }
}
