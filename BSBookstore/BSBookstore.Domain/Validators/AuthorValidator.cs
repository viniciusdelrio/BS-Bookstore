using System;
using System.Collections.Generic;
using System.Text;
using BSBookstore.Domain.Entity;
using FluentValidation;

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

        }

        #endregion
    }
}
