using Autofac;
using Autofac.Extensions.DependencyInjection;
using System;

namespace BSBookstore.Infrastructure.IoC
{
    public static class AutofacIoC
    {
        #region Attributes

        private static IContainer _container;

        #endregion

        #region Methods

        public static IServiceProvider Config()
        {
            var builder = new ContainerBuilder();

            builder.RegisterAssemblyTypes(AppDomain.CurrentDomain.GetAssemblies())
                   .AsImplementedInterfaces();

            _container = builder.Build();

            return new AutofacServiceProvider(_container);
        }

        public static T Resolve<T>()
        {
            return _container.Resolve<T>();
        }

        #endregion

    }
}
