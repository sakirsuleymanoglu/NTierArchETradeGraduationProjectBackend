using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IOrderService
    {
        IDataResult<List<Order>> GetAll();
        IDataResult<List<Order>> GetAllByUser(int userId);
        IDataResult<List<Order>> GetAllByAddress(int addressId);
        IDataResult<List<Order>> GetAllByOrderStatus(int orderStatusId);
        IDataResult<Order> GetById(int id);
        IResult Add(Order order);
        IResult Delete(Order order);
        IResult Update(Order order);
    }
}
