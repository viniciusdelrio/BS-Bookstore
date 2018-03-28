using Autofac;
using Autofac.Extensions.DependencyInjection;
using System;

namespace BSBookstore.Infrastructure.IoC
{
    public static class AutofacConfig
    {
        public static IServiceProvider Config()
        {
            var builder = new ContainerBuilder();

            builder.RegisterAssemblyTypes(AppDomain.CurrentDomain.GetAssemblies())
                   .AsImplementedInterfaces();

            var container = builder.Build();

            return new AutofacServiceProvider(container);
        }
    }
}
