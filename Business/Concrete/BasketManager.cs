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
    public class BasketManager : IBasketService
    {
        readonly IBasketDal _basketDal;

        public BasketManager(IBasketDal basketDal)
        {
            _basketDal = basketDal;
        }

        public IResult Add(Basket basket)
        {
            _basketDal.Add(basket);

            return new SuccessResult();
        }

        public IResult Delete(Basket basket)
        {
            var result = BusinessRules.Run(CheckIfExistsBasket(basket.Id));

            if (result != null)
            {
                return result;
            }

            _basketDal.Delete(basket);

            return new SuccessResult();
        }

        public IDataResult<List<Basket>> GetAll()
        {
            var result = _basketDal.GetAll(b => b.Active == true);

            return new SuccessDataResult<List<Basket>>(result);
        }

        private IResult CheckIfExistsBasket(int basketId)
        {
            var result = _basketDal.Get(b => b.Id == basketId);

            if (result == null)
            {
                return new ErrorResult();
            }

            return new SuccessResult();
        }
    }
}
