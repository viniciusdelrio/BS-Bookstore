using BSBookstore.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Text;
using FluentValidation;
using BSBookstore.Infrastructure.IoC;
using BSBookstore.Domain.Contract;

namespace BSBookstore.Domain.Validators
{
    public class CategoryValidator : BaseValidator<Category>
    {
        #region Constructors

        public CategoryValidator()
        {
            RuleSet(InsertRules, InsertValidate);
            RuleSet(DeleteRules, DeleteValidate);
        }

        #endregion

        #region Methods

        private void InsertValidate()
        {
            RuleFor(x => x.Name).NotEmpty();
        }

        private void DeleteValidate()
        {
            RuleFor(x => x).Custom((category, context) =>
            {
                var rep = IoC.Resolve<ICategoryRepository>();

                if (rep.HasRelationship(category))
                {
                    throw new ValidationException(BSResources.HasRelationship);
                }
            });
        }

        #endregion
    }
}
