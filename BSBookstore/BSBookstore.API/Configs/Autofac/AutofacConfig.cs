using Autofac;
using Autofac.Extensions.DependencyInjection;
using BSBookstore.API.Configs.Autofac;
using BSBookstore.Infrastructure.IoC;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace BSBookstore.API
{
    /// <summary>
    /// Realiza a configuração do Autofac (Injeção de dependência)
    /// </summary>
    public static class AutofacConfig
    {
        public static IServiceProvider Config(IServiceCollection services, IConfiguration configuration)
        {
            var containerBuilder = new ContainerBuilder();

            //Registrando a conexão
            containerBuilder.Register(c => new SqlConnection(configuration.GetConnectionString("DefaultConnection"))).As<IDbConnection>();

            //Registrando os módulos
            containerBuilder.RegisterModule<ServiceModule>();
            containerBuilder.RegisterModule<RepositoryModule>();

            containerBuilder.Populate(services);

            IoC.Container = containerBuilder.Build();

            return new AutofacServiceProvider(IoC.Container);
        }
    }
}
