using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IBasketService
    {
        IResult Add(Basket basket);
        IResult Delete(Basket basket);
        IDataResult<List<BasketDetailsDto>> GetAllWithDetailsByUser(int userId);
        IDataResult<decimal> GetTotalPrice();
        IResult DeleteBasket(int basketId);
    }
}
