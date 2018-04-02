using BSBookstore.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace BSBookstore.Domain.Contract
{
    public interface IAuthorService
    {
        IList<Author> GetAll();

        Author Get(Guid id);

        void Insert(Author model);

        void Delete(Guid id);
    }
}
