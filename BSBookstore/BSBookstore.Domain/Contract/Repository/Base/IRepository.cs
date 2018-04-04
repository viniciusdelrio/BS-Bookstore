using System;
using System.Collections.Generic;
using System.Text;

namespace BSBookstore.Domain.Contract
{
    public interface IRepository
    { }

    public interface IRepository<TModel, TId> : IRepository
        where TModel : class, IEntity<TId>
        where TId : struct
    {
        void Insert(TModel model);

        TModel FindById(TId id);

        IList<TModel> GetAll();

        void Update(TModel model);

        void InsertOrUpdate(TModel model);

        void Delete(TModel model);

        void Delete(TId id);
    }

    public interface IRepository<TModel> : IRepository<TModel, Guid>
        where TModel : class, IEntity
    { }
}
