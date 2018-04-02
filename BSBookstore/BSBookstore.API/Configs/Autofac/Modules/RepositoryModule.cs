using Autofac;
using BSBookstore.Domain.Contract;
using BSBookstore.Infrastructure.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BSBookstore.API.Configs.Autofac
{
    public class RepositoryModule : Module
    {
        #region Methods

        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<UnitOfWork>().As<IUnitOfWork>();
            builder.RegisterType<AuthorRepository>().As<IAuthorRepository>();
        }

        #endregion
    }
}
