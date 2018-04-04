using BSBookstore.Domain.Entity;
using FluentValidation;

namespace BSBookstore.Domain.Validators
{
    public class BookValidator : BaseValidator<Book>
    {
        #region Constructors

        public BookValidator()
        {
            RuleSet(InsertRules, InsertValidate);
        }

        #endregion

        #region Methods

        private void InsertValidate()
        {
            RuleFor(x => x.Title).NotEmpty();
            RuleFor(x => x.PublishedYear).NotEmpty();
            RuleFor(x => x.IdAuthor).NotEmpty();
            RuleFor(x => x.IdCategory).NotEmpty();
        }

        #endregion
    }
}
