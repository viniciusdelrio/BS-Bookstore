﻿using BSBookstore.Domain.Contract;
using BSBookstore.Domain.Entity;
using BSBookstore.Domain.Validators;
using BSBookstore.Infrastructure.IoC;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace BSBookstore.Application
{
    public class AuthorService : IAuthorService
    {
        #region Attributes

        private readonly IUnitOfWork _unitOfWork;

        #endregion

        #region Constructors

        public AuthorService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Busca um autor pelo Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Author Get(Guid id)
        {
            var model = _unitOfWork.AuthorRepository.FindById(id);

            return model;
        }

        /// <summary>
        /// Lista todos os autores
        /// </summary>
        /// <returns></returns>
        public IList<Author> GetAll()
        {
            var models = _unitOfWork.AuthorRepository.GetAll();

            return models;
        }

        /// <summary>
        /// Cria ou atualiza um autor
        /// </summary>
        /// <param name="model"></param>
        public void Insert(Author model)
        {
            model.ValidateAndThrow(AuthorValidator.InsertRules);

            _unitOfWork.AuthorRepository.InsertOrUpdate(model);
            _unitOfWork.Commit();
        }

        /// <summary>
        /// Exclui um autor
        /// </summary>
        /// <param name="id"></param>
        public void Delete(Guid id)
        {
            var model = Get(id);

            model.ValidateAndThrow(AuthorValidator.DeleteRules);

            _unitOfWork.AuthorRepository.Delete(model);
            _unitOfWork.Commit();
        }

        #endregion
    }
}
