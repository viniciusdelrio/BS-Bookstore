using Autofac;
using System;
using System.Collections.Generic;
using System.Text;

namespace BSBookstore.Infrastructure.IoC
{
    public static class IoC
    {
        #region Attributes

        public static IContainer Container;

        #endregion

        #region Methods

        public static T Resolve<T>()
        {
            return Container.Resolve<T>();
        }

        #endregion
    }
}
