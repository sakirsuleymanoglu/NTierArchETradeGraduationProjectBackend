using Core.DataAccess;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Abstract
{
    public interface IBasketDal : IEntityRepository<Basket>
    {
        List<BasketDetailsDto> GetAllWithDetails(Expression<Func<BasketDetailsDto, bool>> filter=null);
    }
}
