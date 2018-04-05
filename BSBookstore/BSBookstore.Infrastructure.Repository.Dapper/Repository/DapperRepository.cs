using BSBookstore.Domain.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using DapperExtensions;
using DapperExtensions.Mapper;

namespace BSBookstore.Infrastructure.Repository.Dapper
{
    public class DapperRepository<TModel, TId> : BaseRepository<TModel, TId>, IRepository<TModel, TId>
        where TModel : class, IEntity<TId>
        where TId : struct, IEquatable<TId>
    {
        #region Attributes

        protected IDbConnection _connection;

        #endregion

        #region Constructors

        public DapperRepository()
            : this(IoC.IoC.Resolve<IDbConnection>())
        { }

        public DapperRepository(IDbConnection connection)
        {
            _connection = connection;

            DapperExtensions.DapperExtensions.DefaultMapper = typeof(AutoClassMapper<TModel>);
        }

        #endregion

        #region Methods

        public override IList<TModel> GetAll()
        {
            return _connection.GetList<TModel>().ToList();
        }

        public override TModel FindById(TId id)
        {
            return _connection.Get<TModel>(id);
        }

        public override void Insert(TModel model)
        {
            _connection.Insert(model);
        }

        public override void Update(TModel model)
        {
            if (model.Id.Equals(default(TId)))
            {
                string entityName = GetEntityName();

                throw new Exception($"Falha ao atualizar registro da entidade '{entityName}'. O ID não pode ser vazio!");
            }

            _connection.Update(model);
        }

        public override void InsertOrUpdate(TModel model)
        {
            if (model.Id.Equals(default(TId)))
            {
                Insert(model);
            }
            else
            {
                Update(model);
            }
        }

        public override void Delete(TModel model)
        {
            _connection.Delete(model);
        }

        public override void Delete(TId id)
        {
            var model = FindById(id);

            if (model == null)
            {
                var entityName = GetEntityName();

                throw new Exception($"Falha ao remover registro da entidade '{entityName}'. O ID {model.Id} não existe no banco de dados.");
            }

            Delete(model);
        }

        private string GetEntityName()
        {
            return typeof(TModel).Name;
        }

        #endregion
    }

    public class DapperRepository<TModel> : DapperRepository<TModel, Guid>, IRepository<TModel>
        where TModel : class, IEntity
    {
        #region Methods

        public override void Insert(TModel model)
        {
            if (model.Id == Guid.Empty)
            {
                model.Id = Guid.NewGuid();
            }

            base.Insert(model);
        }

        #endregion
    }
}
