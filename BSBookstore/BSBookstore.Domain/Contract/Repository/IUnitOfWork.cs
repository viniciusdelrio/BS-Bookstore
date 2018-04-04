using System;
using System.Collections.Generic;
using System.Text;

namespace BSBookstore.Domain.Contract
{
    public interface IUnitOfWork : IBaseUnitOfWork
    {
        IAuthorRepository AuthorRepository { get; }

        ICategoryRepository CategoryRepository { get; }

        IBookRepository BookRepository { get; }
    }
}
