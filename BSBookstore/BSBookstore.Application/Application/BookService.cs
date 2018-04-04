using BSBookstore.Domain.Contract;
using BSBookstore.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Text;
using BSBookstore.Domain.Validators;

namespace BSBookstore.Application
{
    public class BookService : IBookService
    {
        #region Attributes

        private readonly IUnitOfWork _unitOfWork;

        #endregion

        #region Constructors

        public BookService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        #endregion

        #region Methods

        public Book Get(Guid id)
        {
            var model = _unitOfWork.BookRepository.FindById(id);

            return model;
        }

        public IList<Book> GetAll()
        {
            var models = _unitOfWork.BookRepository.GetAll();

            return models;
        }

        public void Insert(Book model)
        {
            model.ValidateAndThrow(BookValidator.InsertRules);

            _unitOfWork.BookRepository.InsertOrUpdate(model);
            _unitOfWork.Commit();
        }

        public void Delete(Guid id)
        {
            var model = Get(id);

            model.ValidateAndThrow(BookValidator.DeleteRules);

            _unitOfWork.BookRepository.Delete(model);
            _unitOfWork.Commit();
        }

        #endregion
    }
}
