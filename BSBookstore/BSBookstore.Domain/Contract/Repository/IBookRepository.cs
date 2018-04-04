using BSBookstore.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace BSBookstore.Domain.Contract
{
    public interface IBookRepository : IRepository<Book>
    { }
}
