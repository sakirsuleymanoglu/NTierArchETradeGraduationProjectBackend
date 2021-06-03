using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IProductImageService
    {
        IDataResult<List<ProductImage>> GetAll();
        IDataResult<ProductImage> GetById(int id);
        IResult Add(ProductImage productImage);
        IResult Delete(ProductImage productImage);
        IResult Update(ProductImage productImage);
        IDataResult<List<ProductImage>> GetAllByProduct(int productId);
        IDataResult<ProductImage> GetFirstImageByProduct(int productId);
    }
}
