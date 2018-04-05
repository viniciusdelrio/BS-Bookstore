using BSBookstore.Infrastructure.Repository.Mapper;
using DapperExtensions.Mapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace BSBookstore.Infrastructure.Repository
{
    public static class DapperConfig
    {
        #region Methods

        public static void Config()
        {
            //Configura qual o assembly que está as classes de mapeamento
            DapperExtensions.DapperExtensions.SetMappingAssemblies(new[] { typeof(AuthorMapper).Assembly });
        }

        #endregion
    }
}
