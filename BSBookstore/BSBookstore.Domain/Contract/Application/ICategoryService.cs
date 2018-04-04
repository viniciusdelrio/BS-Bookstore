using BSBookstore.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace BSBookstore.Domain.Contract
{
    public interface ICategoryService
    {
        IList<Category> GetAll();

        Category Get(Guid id);

        void Insert(Category model);

        void Delete(Guid id);
    }
}
