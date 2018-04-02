using BSBookstore.Infrastructure.IoC;
using BSBookstore.Infrastructure.Repository.Base;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
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
            : this(IoC.IoC.Resolve<IDbConnection>())
        { }

        public DapperUnitOfWork(IDbConnection connection)
        {
            _connection = connection;
            _connection.Open();

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

            _connection.Dispose();

            base.Dispose();
        }

        #endregion
    }
}
