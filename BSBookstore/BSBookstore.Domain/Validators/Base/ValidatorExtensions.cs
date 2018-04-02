using BSBookstore.Domain.Contract;
using BSBookstore.Infrastructure.IoC;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace BSBookstore.Domain.Validators
{
    public static class ValidatorExtensions
    {
        #region Methods

        public static void ValidateAndThrow<T>(this T model, string ruleSet)
            where T : class, IEntity
        {
            var validator = IoC.Resolve<IValidator<T>>();

            validator.ValidateAndThrow(model, ruleSet);
        }

        #endregion
    }
}
