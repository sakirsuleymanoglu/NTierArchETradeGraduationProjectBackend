using Business.Abstract;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;

namespace Business.Concrete
{
    public class ProductManager : IProductService
    {
        private readonly IProductDal _productDal;

        private readonly ICategoryService _categoryService;

        private readonly IBrandService _brandService;

        public ProductManager(IProductDal productDal, ICategoryService categoryService, IBrandService brandService)
        {
            _productDal = productDal;

            _categoryService = categoryService;

            _brandService = brandService;
        }

        public IResult Add(Product product)
        {
            _productDal.Add(product);

            return new SuccessResult();
        }

        public IResult Delete(Product product)
        {
            var result = BusinessRules.Run(CheckIfExistsProduct(product.Id));

            if (result != null)
            {
                return result;
            }

            _productDal.Delete(product);

            return new SuccessResult();
        }

        public IDataResult<List<Product>> GetAll()
        {
            var result = _productDal.GetAll();

            return new SuccessDataResult<List<Product>>(result);
        }

        public IDataResult<List<Product>> GetAllByBrand(int brandId)
        {
            var result = BusinessRules.Run(CheckIfExistsBrand(brandId));

            if (result != null)
            {
                return new ErrorDataResult<List<Product>>(result.Message);
            }

            var productListByBrand = _productDal.GetAll(p => p.BrandId == brandId);

            return new SuccessDataResult<List<Product>>(productListByBrand);
        }

        public IDataResult<List<Product>> GetAllByCategory(int categoryId)
        {
            var result = BusinessRules.Run(CheckIfExistsCategory(categoryId));

            if (result != null)
            {
                return new ErrorDataResult<List<Product>>(result.Message);
            }

            var productListByCategory = _productDal.GetAll(p => p.CategoryId == categoryId);

            return new SuccessDataResult<List<Product>>
                (productListByCategory);
        }

        public IDataResult<Product> GetById(int id)
        {
            var result = BusinessRules.Run(CheckIfExistsProduct(id));

            if (result != null)
            {
                return new ErrorDataResult<Product>(result.Message);
            }

            var product = _productDal.Get(p => p.Id == id);

            return new SuccessDataResult<Product>(product);
        }

        public IResult Update(Product product)
        {
            var result = BusinessRules.Run(CheckIfExistsProduct(product.Id));

            if (result != null)
            {
                return result;
            }

            _productDal.Update(product);

            return new SuccessResult();
        }

        private IResult CheckIfExistsProduct(int productId)
        {
            var result = _productDal.Get(p => p.Id == productId);

            if (result == null)
            {
                return new ErrorResult();
            }

            return new SuccessResult();
        }

        private IResult CheckIfExistsBrand(int brandId)
        {
            var result = _brandService.GetById(brandId);

            if (result == null)
            {
                return new ErrorResult();
            }

            return new SuccessResult();
        }

        private IResult CheckIfExistsCategory(int categoryId)
        {
            var result = _categoryService.GetById(categoryId);

            if (result == null)
            {
                return new ErrorResult();
            }

            return new SuccessResult();
        }
    }
}
