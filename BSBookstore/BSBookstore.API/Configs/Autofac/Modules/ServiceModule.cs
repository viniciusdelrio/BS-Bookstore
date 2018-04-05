using Autofac;
using BSBookstore.Application;
using BSBookstore.Domain.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BSBookstore.API.Configs.Autofac
{
    /// <summary>
    /// Registra todas as injeções de dependências referentes a Service
    /// </summary>
    public class ServiceModule : Module
    {
        #region Methods

        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<AuthorService>().As<IAuthorService>();
            builder.RegisterType<CategoryService>().As<ICategoryService>();
            builder.RegisterType<BookService>().As<IBookService>();
        }

        #endregion
    }
}
