using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Linq;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfBasketDal : EfEntityRepositoryBase<Basket, MarmaraMarketContext>, IBasketDal
    {
        public List<BasketDetailsDto> GetAllWithDetails(Expression<Func<BasketDetailsDto, bool>> filter = null)
        {
            using (MarmaraMarketContext context = new MarmaraMarketContext())
            {
                var result = from b in context.Baskets
                             join p in context.Products
                             on b.ProductId equals p.Id
                             join u in context.Users
                             on b.UserId equals u.Id
                             join c in context.Categories
                             on p.CategoryId equals c.Id
                             join br in context.Brands
                             on p.BrandId equals br.Id
                             select new BasketDetailsDto
                             {
                                 Id = b.Id,
                                 UserId = u.Id,
                                 ProductId = p.Id,
                                 ProductBrandName = br.Name,
                                 ProductCategoryName = c.Name,
                                 ProductName = p.Name,
                                 ProductPrice = p.Price,
                                 ProductImagePath = p.DefaultImagePath,
                                 Count = b.Count,
                                 TotalPrice = b.Count * p.Price
                             };

                return filter == null ? result.ToList() :
                     result.Where(filter).ToList();
            }
        }
    }
}
