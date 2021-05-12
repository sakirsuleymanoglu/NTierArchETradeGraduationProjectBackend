using Business.Abstract;
using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using DataAccess.Abstract;

namespace Business.Concrete
{
    public class OrderManager : IOrderService
    {
        private IOrderDal _orderDal;

        public OrderManager(IOrderDal orderDal)
        {
            _orderDal = orderDal;
        }
        public IResult Add(Order order)
        {
            _orderDal.Add(order);

            return new SuccessResult();
        }

        public IResult Delete(Order order)
        {
            _orderDal.Delete(order);

            return new SuccessResult();
        }

        public IDataResult<List<Order>> GetAll()
        {
            var result = _orderDal.GetAll();

            return new SuccessDataResult<List<Order>>(result);
        }

        public IDataResult<Order> GetById(int id)
        {
            var result = _orderDal.Get(o => o.Id == id);

            return new SuccessDataResult<Order>(result);
        }

        public IResult Update(Order order)
        {
            _orderDal.Update(order);

            return new SuccessResult();
        }
    }
}
