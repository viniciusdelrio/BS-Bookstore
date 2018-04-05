using Autofac;
using BSBookstore.Domain.Contract;
using BSBookstore.Infrastructure.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BSBookstore.API.Configs.Autofac
{
    /// <summary>
    /// Registra todas as injeções de dependências referentes a Repository
    /// </summary>
    public class RepositoryModule : Module
    {
        #region Methods

        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<UnitOfWork>().As<IUnitOfWork>();
            builder.RegisterType<AuthorRepository>().As<IAuthorRepository>();
            builder.RegisterType<CategoryRepository>().As<ICategoryRepository>();
            builder.RegisterType<BookRepository>().As<IBookRepository>();
        }

        #endregion
    }
}
