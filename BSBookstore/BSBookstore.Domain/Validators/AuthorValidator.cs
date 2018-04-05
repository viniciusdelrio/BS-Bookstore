using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using BSBookstore.Domain.Contract;
using BSBookstore.Domain.Entity;
using BSBookstore.Infrastructure.IoC;
using FluentValidation;
using FluentValidation.Results;

namespace BSBookstore.Domain.Validators
{
    public class AuthorValidator : BaseValidator<Author>
    {
        #region Constructors

        public AuthorValidator()
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
            RuleFor(x => x).Custom((author, context) =>
            {
                var rep = IoC.Resolve<IAuthorRepository>();

                if (rep.HasRelationship(author))
                {
                    throw new ValidationException(BSResources.HasRelationship);
                }
            });
        }

        #endregion
    }
}
