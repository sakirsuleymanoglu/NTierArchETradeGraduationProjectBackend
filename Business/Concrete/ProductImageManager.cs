using Business.Abstract;
using Core.Utilities.Business;
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
            var result = BusinessRules.Run(CheckIfProductImageThanFive(productImage.ProductId));

            if (result != null)
            {
                return result;
            }

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

        public IDataResult<List<ProductImage>> GetAllByProduct(int productId)
        {
            var result = _productImageDal.GetAll(p => p.ProductId == productId);

            return new SuccessDataResult<List<ProductImage>>(result);
        }

        public IDataResult<ProductImage> GetById(int id)
        {
            var result = _productImageDal.Get(pImage => pImage.Id == id);

            return new SuccessDataResult<ProductImage>(result);
        }

        public IDataResult<ProductImage> GetFirstImageByProduct(int productId)
        {
            var result = _productImageDal.First(pImage => pImage.ProductId == productId);

            return new SuccessDataResult<ProductImage>(result);
        }

        public IResult Update(ProductImage productImage)
        {
            _productImageDal.Update(productImage);

            return new SuccessResult();
        }

        private IResult CheckIfProductImageThanFive(int productId)
        {
            var result = _productImageDal.GetAll(pImage => pImage.ProductId == productId);

            if (result.Count > 5)
            {
                return new ErrorResult();
            }

            return new SuccessResult();
        }
    }
}
