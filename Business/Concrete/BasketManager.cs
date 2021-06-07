using Business.Abstract;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class BasketManager : IBasketService
    {
        IBasketDal _basketDal;

        public BasketManager(IBasketDal basketDal)
        {
            _basketDal = basketDal;
        }

        public IResult Add(Basket basket)
        {
            var result = BusinessRules.Run(CheckIfExistsProductAndUser(basket.ProductId, basket.UserId));

            if (result != null)
            {
                _basketDal.Add(basket);
            }

            basket = _basketDal.Get(b => b.ProductId == basket.ProductId && b.UserId == basket.UserId);

            basket.Count++;

            _basketDal.Update(basket);

            return new SuccessResult();
        }

        public IResult Delete(Basket basket)
        {
            var result = BusinessRules.Run(CheckIfExistsProductAndUser(basket.ProductId, basket.UserId));

            if (result != null)
            {
                return result;
            }

            basket = _basketDal.Get(b => b.ProductId == basket.ProductId && b.UserId == basket.UserId);

            if (basket.Count == 1)
            {
                _basketDal.Delete(basket);
            }
            else
            {
                basket.Count--;
                _basketDal.Update(basket);
            }

            return new SuccessResult();
        }

        public IResult DeleteBasket(int basketId)
        {
            var basket = _basketDal.Get(b => b.Id == basketId);

            _basketDal.Delete(basket);

            return new SuccessResult();
        }

        public IDataResult<List<BasketDetailsDto>> GetAllWithDetailsByUser(int userId)
        {
            var result = _basketDal.GetAllWithDetails(b => b.UserId == userId);

            return new SuccessDataResult<List<BasketDetailsDto>>(result);
        }

        public IDataResult<decimal> GetTotalPrice(int userId)
        {
            var result = _basketDal.GetAllWithDetails(b=>b.UserId == userId);

            decimal totalPrice = 0;

            foreach (var b in result)
            {
                totalPrice += b.TotalPrice;
            }

            return new SuccessDataResult<decimal>(totalPrice);
        }

        private IResult CheckIfExistsProductAndUser(int productId, int userId)
        {
            var result = _basketDal.Get(b => b.ProductId == productId && b.UserId == userId);

            if (result == null)
            {
                return new ErrorResult();
            }

            return new SuccessResult();
        }
    }
}
