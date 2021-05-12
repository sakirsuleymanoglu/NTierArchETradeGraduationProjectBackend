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
    public class OrderManager : IOrderService
    {
        private IOrderDal _orderDal;
        private IUserService _userService;
        private IAddressService _addressService;
        private IOrderStatusService _orderStatusService;

        public OrderManager(IOrderDal orderDal, IUserService userService, IAddressService addressService, IOrderStatusService orderStatusService)
        {
            _orderDal = orderDal;

            _userService = userService;

            _addressService = addressService;

            _orderStatusService = orderStatusService;
        }

        public IResult Add(Order order)
        {
            _orderDal.Add(order);

            return new SuccessResult();
        }

        public IResult Delete(Order order)
        {
            var result = BusinessRules.Run(CheckIfExistsOrder(order.Id));

            if (result != null)
            {
                return result;
            }

            _orderDal.Delete(order);

            return new SuccessResult();
        }

        public IDataResult<List<Order>> GetAll()
        {
            var result = _orderDal.GetAll();

            return new SuccessDataResult<List<Order>>(result);
        }

        public IDataResult<List<Order>> GetAllByUser(int userId)
        {
            var result = BusinessRules.Run(CheckIfExistsUser(userId));

            if (result != null)
            {
                return new ErrorDataResult<List<Order>>(result.Message);
            }

            var orderListByUser = _orderDal.GetAll(o => o.UserId == userId);

            return new SuccessDataResult<List<Order>>(orderListByUser);
        }

        public IDataResult<List<Order>> GetAllByAddress(int addressId)
        {
            var result = BusinessRules.Run(CheckIfExistsAddress(addressId));

            if (result != null)
            {
                return new ErrorDataResult<List<Order>>(result.Message);
            }

            var orderListByAddress = _orderDal.GetAll(o => o.AddressId == addressId);

            return new SuccessDataResult<List<Order>>(orderListByAddress);
        }

        public IDataResult<List<Order>> GetAllByOrderStatus(int orderStatusId)
        {
            var result = BusinessRules.Run(CheckIfExistsOrderStatus(orderStatusId));

            if (result != null)
            {
                return new ErrorDataResult<List<Order>>(result.Message);
            }

            var orderListByOrderStatus = _orderDal.GetAll(o => o.OrderStatusId == orderStatusId);

            return new SuccessDataResult<List<Order>>(orderListByOrderStatus);
        }

        public IDataResult<Order> GetById(int id)
        {
            var result = BusinessRules.Run(CheckIfExistsOrder(id));

            if (result != null)
            {
                return new ErrorDataResult<Order>(result.Message);
            }

            var order = _orderDal.Get(o => o.Id == id);

            return new SuccessDataResult<Order>(order);
        }

        public IResult Update(Order order)
        {
            var result = BusinessRules.Run(CheckIfExistsOrder(order.Id));

            if (result != null)
            {
                return result;
            }

            _orderDal.Update(order);

            return new SuccessResult();
        }

        private IResult CheckIfExistsOrder(int orderId)
        {
            var result = _orderDal.Get(o => o.Id == orderId);

            if (result == null)
            {
                return new ErrorResult();
            }

            return new SuccessResult();
        }

        private IResult CheckIfExistsUser(int userId)
        {
            var result = _userService.GetById(userId);

            if (result == null)
            {
                return new ErrorResult();
            }

            return new SuccessResult();
        }

        private IResult CheckIfExistsAddress(int addressId)
        {
            var result = _addressService.GetById(addressId);

            if (result == null)
            {
                return new ErrorResult();
            }

            return new SuccessResult();
        }

        private IResult CheckIfExistsOrderStatus(int orderStatus)
        {
            var result = _orderStatusService.GetById(orderStatus);

            if (result == null)
            {
                return new ErrorResult();
            }

            return new SuccessResult();
        }
    }
}
