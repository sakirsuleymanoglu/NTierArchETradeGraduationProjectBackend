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
    public class OrderDetailManager : IOrderDetailService
    {
        IOrderDetailDal _orderDetailDal;
        IOrderService _orderService;

        public OrderDetailManager(IOrderDetailDal orderDetailDal, IOrderService orderService)
        {
            _orderDetailDal = orderDetailDal;

            _orderService = orderService;
        }

        public IResult Add(OrderDetail orderDetail)
        {
            _orderDetailDal.Add(orderDetail);

            return new SuccessResult();
        }

        public IResult Delete(OrderDetail orderDetail)
        {
            var result = BusinessRules.Run(CheckIfExistsOrderDetail(orderDetail.Id));

            if (result != null)
            {
                return result;
            }

            _orderDetailDal.Delete(orderDetail);

            return new SuccessResult();
        }

        public IDataResult<List<OrderDetail>> GetAll()
        {
            var result = _orderDetailDal.GetAll();

            return new SuccessDataResult<List<OrderDetail>>(result);
        }

        public IDataResult<OrderDetail> GetById(int id)
        {
            var result = BusinessRules.Run(CheckIfExistsOrderDetail(id));

            if (result != null)
            {
                return new ErrorDataResult<OrderDetail>(result.Message);
            }

            var orderDetail = _orderDetailDal.Get(oDetail => oDetail.Id == id);

            return new SuccessDataResult<OrderDetail>(orderDetail);
        }

        public IDataResult<OrderDetail> GetByOrder(int orderId)
        {
            var result = BusinessRules.Run(CheckIfExistsOrder(orderId));

            if (result != null)
            {
                return new ErrorDataResult<OrderDetail>(result.Message);
            }

            var orderDetail = _orderDetailDal.Get(oDetail => oDetail.OrderId == orderId);

            return new SuccessDataResult<OrderDetail>(orderDetail);
        }

        public IResult Update(OrderDetail orderDetail)
        {
            var result = BusinessRules.Run(CheckIfExistsOrderDetail(orderDetail.Id));

            if (result != null)
            {
                return result;
            }

            _orderDetailDal.Update(orderDetail);

            return new SuccessResult();
        }

        private IResult CheckIfExistsOrderDetail(int orderDetailId)
        {
            var result = _orderDetailDal.Get(oDetail => oDetail.Id == orderDetailId);

            if (result == null)
            {
                return new ErrorResult();
            }

            return new SuccessResult();
        }

        private IResult CheckIfExistsOrder(int orderId)
        {
            var result = _orderService.GetById(orderId);

            if (result == null)
            {
                return new ErrorResult();
            }

            return new SuccessResult();
        }
    }
}
