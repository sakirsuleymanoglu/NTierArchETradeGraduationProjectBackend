using Business.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class ProductImageManager : IProductImageService
    {
        IProductImageDal _productImageDal;

        public ProductImageManager(IProductImageDal productImageDal)
        {
            _productImageDal = productImageDal;
        }

        public IResult Add(ProductImage productImage)
        {
            _productImageDal.Add(productImage);

            return new SuccessResult();
        }

        public IResult Delete(ProductImage productImage)
        {
            _productImageDal.Delete(productImage);

            return new SuccessResult();
        }

        public IDataResult<List<ProductImage>> GetAll()
        {
            var result = _productImageDal.GetAll();

            return new SuccessDataResult<List<ProductImage>>(result);
        }

        public IDataResult<ProductImage> GetById(int id)
        {
            var result = _productImageDal.Get(pImage => pImage.Id == id);

            return new SuccessDataResult<ProductImage>(result);
        }

        public IResult Update(ProductImage productImage)
        {
            _productImageDal.Update(productImage);

            return new SuccessResult();
        }
    }
}
