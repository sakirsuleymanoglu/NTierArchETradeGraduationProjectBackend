using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Linq.Expressions;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfProductDal : EfEntityRepositoryBase<Product, MarmaraMarketContext>, IProductDal
    {
        public List<ProductDetailsDto> GetAllWithDetails(Expression<Func<ProductDetailsDto, bool>> filter)
        {
            using (MarmaraMarketContext context = new MarmaraMarketContext())
            {
                var result = from p in context.Products
                             join b in context.Brands
                             on p.BrandId equals b.Id
                             join c in context.Categories
                             on p.CategoryId equals c.Id
                             select new ProductDetailsDto
                             {
                                 Id = p.Id,
                                 Name = p.Name,
                                 BrandName = b.Name,
                                 CategoryName = c.Name,
                                 Description = p.Description,
                                 Price = p.Price,
                                 ImagePath = p.DefaultImagePath
                             };

                return filter != null ? result.Where(filter).ToList()
                    : result.ToList();
            }
        }

        public ProductDetailsDto GetWithDetails(Expression<Func<ProductDetailsDto, bool>> filter)
        {
            using (MarmaraMarketContext context = new MarmaraMarketContext())
            {
                var result = from p in context.Products
                             join b in context.Brands
                             on p.BrandId equals b.Id
                             join c in context.Categories
                             on p.CategoryId equals c.Id
                             select new ProductDetailsDto
                             {
                                 Id = p.Id,
                                 Name = p.Name,
                                 BrandName = b.Name,
                                 CategoryName = c.Name,
                                 Description = p.Description,
                                 Price = p.Price,
                             };

                return result.SingleOrDefault(filter);
            }
        }
    }
}
