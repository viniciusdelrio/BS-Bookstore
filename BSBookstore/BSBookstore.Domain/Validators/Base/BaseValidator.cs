using BSBookstore.Domain.Contract;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace BSBookstore.Domain.Validators
{
    public class BaseValidator<TModel> : AbstractValidator<TModel>, IValidator<TModel>
        where TModel : class, IEntity
    {
        #region Attributes

        public const string InsertRules = "InsertRules";
        public const string DeleteRules = "DeleteRules";

        #endregion
    }
}
