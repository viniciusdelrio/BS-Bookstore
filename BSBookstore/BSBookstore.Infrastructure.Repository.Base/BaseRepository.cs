using BSBookstore.Domain.Contract;
using System;
using System.Collections.Generic;
using System.Text;

namespace BSBookstore.Infrastructure.Repository
{
    public abstract class BaseRepository<TModel, TId> : IRepository<TModel, TId>
        where TModel : class, IEntity<TId>
        where TId : struct
    {
        public abstract void Insert(TModel model);

        public abstract void Update(TModel model);

        public abstract void InsertOrUpdate(TModel model);

        public abstract void Delete(TId id);

        public abstract void Delete(TModel model);

        public abstract TModel FindById(TId id);

        public abstract IList<TModel> GetAll();
    }
}
