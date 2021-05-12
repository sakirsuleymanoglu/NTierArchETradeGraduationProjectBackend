using Business.Abstract;
using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using Core.Utilities.Business;
using DataAccess.Abstract;

namespace Business.Concrete
{
    public class OrderStatusManager : IOrderStatusService
    {
        private IOrderStatusDal _orderStatusDal;

        public OrderStatusManager(IOrderStatusDal orderStatusDal)
        {
            _orderStatusDal = orderStatusDal;
        }
        public IResult Add(OrderStatus orderStatus)
        {
            _orderStatusDal.Add(orderStatus);

            return new SuccessResult();
        }

        public IResult Delete(OrderStatus orderStatus)
        {
            var result = BusinessRules.Run(CheckIfExistsOrderStatus(orderStatus.Id));

            if (result != null)
            {
                return result;
            }

            _orderStatusDal.Delete(orderStatus);

            return new SuccessResult();
        }

        public IDataResult<List<OrderStatus>> GetAll()
        {
            var result = _orderStatusDal.GetAll();

            return new SuccessDataResult<List<OrderStatus>>(result);
        }

        public IDataResult<OrderStatus> GetById(int id)
        {
            var result = BusinessRules.Run(CheckIfExistsOrderStatus(id));

            if (result != null)
            {
                return new ErrorDataResult<OrderStatus>(result.Message);
            }

            var orderStatus = _orderStatusDal.Get(oStatus => oStatus.Id == id);

            return new SuccessDataResult<OrderStatus>(orderStatus);
        }

        public IResult Update(OrderStatus orderStatus)
        {
            var result = BusinessRules.Run(CheckIfExistsOrderStatus(orderStatus.Id));

            if (result != null)
            {
                return result;
            }

            _orderStatusDal.Update(orderStatus);

            return new SuccessResult();
        }

        private IResult CheckIfExistsOrderStatus(int orderStatus)
        {
            var result = _orderStatusDal.Get(oStatus => oStatus.Id == orderStatus);

            if (result == null)
            {
                return new ErrorResult();
            }

            return new SuccessResult();
        }
    }
}
