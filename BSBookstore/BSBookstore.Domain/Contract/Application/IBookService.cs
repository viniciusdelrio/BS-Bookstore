using BSBookstore.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace BSBookstore.Domain.Contract
{
    public interface IBookService
    {
        IList<Book> GetAll();

        Book Get(Guid id);

        void Insert(Book model);

        void Delete(Guid id);
    }
}
