﻿using Core.DataAccess;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Abstract
{
    public interface IProductDal : IEntityRepository<Product>
    {
        List<ProductDetailsDto> GetAllWithDetails(Expression<Func<ProductDetailsDto, bool>> filter=null);
        ProductDetailsDto GetWithDetails(Expression<Func<ProductDetailsDto, bool>> filter);
    }
}
