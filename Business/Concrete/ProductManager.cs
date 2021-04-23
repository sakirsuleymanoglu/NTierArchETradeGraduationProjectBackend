using Business.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class ProductManager : IProductService
    {
        IProductDal _productDal;

        public ProductManager(IProductDal productDal)
        {
            _productDal = productDal;
        }

        public IResult Add(Product product)
        {
            //iş kuralları

            if (product.CategoryId == 1)
            {
                return new ErrorResult("Bu kategoriye ürün kabul edilmiyor");
            }
            else
            {
                _productDal.Add(product);
                return new SuccessResult("Ürün eklendi");
            }

        }

        public IResult Delete(Product product)
        {
            throw new NotImplementedException();
        }

        public IDataResult<List<Product>> GetAll()
        {
            return new SuccessDataResult<List<Product>>(_productDal.GetAll(),"Ürünler listelendi");
        }

        public IDataResult<List<Product>> GetAllByBrand(int brandId)
        {
            throw new NotImplementedException();
        }

        public IDataResult<List<Product>> GetAllByCategory(int categoryId)
        {
            return new SuccessDataResult<List<Product>>
                (_productDal.GetAll(p=>p.CategoryId==categoryId), 
                "Ürünler listelendi");
        }

        public IDataResult<Product> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public IResult Update(Product product)
        {
            throw new NotImplementedException();
        }
    }
}
