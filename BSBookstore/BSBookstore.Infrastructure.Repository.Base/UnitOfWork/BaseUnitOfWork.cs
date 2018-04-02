using BSBookstore.Domain.Contract;
using System;
using System.Collections.Generic;
using System.Text;

namespace BSBookstore.Infrastructure.Repository.Base
{
    public abstract class BaseUnitOfWork : IBaseUnitOfWork, IDisposable
    {
        #region Attributes

        private readonly IDictionary<string, IRepository> _repos;

        #endregion

        #region Constructors

        public BaseUnitOfWork()
        {
            _repos = new Dictionary<string, IRepository>();
        }

        #endregion

        #region Methods

        public abstract void Commit();

        public abstract void Rollback();

        public virtual TRepository GetRepository<TRepository>()
            where TRepository : IRepository
        {
            string key = typeof(TRepository).ToString();

            if (!_repos.ContainsKey(key))
            { 
                var rep = IoC.IoC.Resolve<TRepository>();

                _repos.Add(key, rep);
            }

            return (TRepository)_repos[key];
        }

        public virtual void Dispose()
        { }

        #endregion
    }
}
