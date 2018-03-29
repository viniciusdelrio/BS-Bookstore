using BSBookstore.Infrastructure.IoC;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace BSBookstore.Infrastructure.Repository.Dapper
{
    public class DapperUnitOfWork : BaseUnitOfWork
    {
        #region Attributes

        private IDbConnection _connection;
        private IDbTransaction _transaction;

        #endregion

        #region Constructors

        public DapperUnitOfWork()
            : this(AutofacIoC.Resolve<IDbConnection>())
        { }

        public DapperUnitOfWork(IDbConnection connection)
        {
            _connection = connection;
            _transaction = _connection.BeginTransaction();
        }

        #endregion

        #region Methods

        public override void Commit()
        {
            _transaction.Commit();

            Dispose();
        }

        public override void Rollback()
        {
            _transaction.Rollback();

            Dispose();
        }

        public override void Dispose()
        {
            if (_transaction != null)
            {
                _transaction.Dispose();
            }

            base.Dispose();
        }

        #endregion
    }
}
