using Business.Abstract;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Business.Concrete
{
    public class CategoryManager : ICategoryService
    {
        private readonly ICategoryDal _categoryDal;
        public CategoryManager(ICategoryDal categoryDal)
        {
            _categoryDal = categoryDal;
        }
        public IResult Add(Category category)
        {
            var result = BusinessRules.Run(CheckIfAlreadyExitsCategoryName(category.Name));

            if (result != null)
            {
                return result;
            }

            _categoryDal.Add(category);

            return new SuccessResult();
        }

        public IResult Delete(Category category)
        {
            var result = BusinessRules.Run(CheckIfExistsCategory(category.Id));

            if (result != null)
            {
                return result;
            }

            _categoryDal.Delete(category);

            return new SuccessResult();
        }

        public IDataResult<List<Category>> GetAll()
        {
            var result = _categoryDal.GetAll();

            return new SuccessDataResult<List<Category>>(result);
        }

        public IDataResult<Category> GetById(int id)
        {
            var result = BusinessRules.Run(CheckIfExistsCategory(id));

            if (result != null)
            {
                return new ErrorDataResult<Category>(result.Message);
            }

            var category = _categoryDal.Get(c => c.Id == id);

            return new SuccessDataResult<Category>(category);
        }

        public IResult Update(Category category)
        {
            var result = BusinessRules.Run(CheckIfExistsCategory(category.Id), CheckIfAlreadyExitsCategoryName(category.Name));

            if (result != null)
            {
                return result;
            }

            _categoryDal.Update(category);

            return new SuccessResult();
        }

        private IResult CheckIfExistsCategory(int categoryId)
        {
            var result = _categoryDal.Get(c => c.Id == categoryId);

            if (result == null)
            {
                return new ErrorResult();
            }

            return new SuccessResult();
        }

        private IResult CheckIfAlreadyExitsCategoryName(string categoryName)
        {
            var result = _categoryDal.Get(c => c.Name == categoryName);

            if (result != null)
            {
                return new ErrorResult();
            }

            return new SuccessResult();
        }

        public IDataResult<List<Category>> GetTopFive()
        {
            var result = _categoryDal.GetAll().Take(5).ToList();

            return new SuccessDataResult<List<Category>>(result);
        }

        private IResult CheckIfAlreadyActiveCategory(bool active)
        {
            var result = active;

            if (result)
            {
                return new ErrorResult();
            }

            return new SuccessResult();
        }

        private IResult CheckIfAlreadyDeactiveCategory(bool active)
        {
            var result = active;

            if (!result)
            {
                return new ErrorResult();
            }

            return new SuccessResult();
        }
    }
}
