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

        /// <summary>
        /// Busca um livro pelo Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Book Get(Guid id)
        {
            var model = _unitOfWork.BookRepository.FindById(id);

            return model;
        }

        /// <summary>
        /// Lista todos os livros
        /// </summary>
        /// <returns></returns>
        public IList<Book> GetAll()
        {
            var models = _unitOfWork.BookRepository.GetAll();

            return models;
        }

        /// <summary>
        /// Cria ou atualiza um livro
        /// </summary>
        /// <param name="model"></param>
        public void Insert(Book model)
        {
            model.ValidateAndThrow(BookValidator.InsertRules);

            _unitOfWork.BookRepository.InsertOrUpdate(model);
            _unitOfWork.Commit();
        }

        /// <summary>
        /// Exclui um livro
        /// </summary>
        /// <param name="id"></param>
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
