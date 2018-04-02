using Autofac;
using BSBookstore.Application;
using BSBookstore.Domain.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BSBookstore.API.Configs.Autofac
{
    public class ServiceModule : Module
    {
        #region Methods

        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<AuthorService>().As<IAuthorService>();
        }

        #endregion
    }
}
