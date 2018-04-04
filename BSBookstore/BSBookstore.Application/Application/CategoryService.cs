using BSBookstore.Domain.Contract;
using BSBookstore.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Text;
using BSBookstore.Domain.Validators;

namespace BSBookstore.Application
{
    public class CategoryService : ICategoryService
    {
        #region Attributes

        private readonly IUnitOfWork _unitOfWork;

        #endregion

        #region Constructors

        public CategoryService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        #endregion

        #region Methods

        public Category Get(Guid id)
        {
            var model = _unitOfWork.CategoryRepository.FindById(id);

            return model;
        }

        public IList<Category> GetAll()
        {
            var models = _unitOfWork.CategoryRepository.GetAll();

            return models;
        }

        public void Insert(Category model)
        {
            model.ValidateAndThrow(CategoryValidator.InsertRules);

            _unitOfWork.CategoryRepository.InsertOrUpdate(model);
            _unitOfWork.Commit();
        }

        public void Delete(Guid id)
        {
            var model = Get(id);

            model.ValidateAndThrow(CategoryValidator.DeleteRules);

            _unitOfWork.CategoryRepository.Delete(model);
            _unitOfWork.Commit();
        }

        #endregion
    }
}
