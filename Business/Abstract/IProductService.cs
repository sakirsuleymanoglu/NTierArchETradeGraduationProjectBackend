using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IProductService
    {
        IDataResult<List<Product>> GetAll();
        IDataResult<List<ProductDetailsDto>> GetAllWithDetails();
        IDataResult<List<ProductDetailsDto>> GEtAllWithDetailsByCategoryName(string categoryName);
        IDataResult<Product> GetById(int id);
        IDataResult<List<Product>> GetAllByCategory(int categoryId);
        IDataResult<List<Product>> GetAllByBrand(int brandId);
        IResult Add(Product product);
        IResult Delete(Product product);
        IResult Update(Product product);
        IDataResult<List<ProductDetailsDto>> GetAllWithDetailsByBrandName(string brandName);
        IDataResult<List<ProductDetailsDto>> GetAllWithDetailsByPrice(decimal begin, decimal end);
        IDataResult<List<ProductDetailsDto>> GetAllWithDetailsBySearchValue(string value);
    }
}
