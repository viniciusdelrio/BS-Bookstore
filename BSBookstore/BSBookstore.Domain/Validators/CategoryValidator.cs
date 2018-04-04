using BSBookstore.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Text;
using FluentValidation;

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

        }

        #endregion
    }
}
