using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IOrderDetailService
    {
        IDataResult<List<OrderDetail>> GetAll();
        IDataResult<OrderDetail> GetById(int id);
        IDataResult<OrderDetail> GetByOrder(int orderId);
        IResult Add(OrderDetail orderDetail);
        IResult Delete(OrderDetail orderDetail);
        IResult Update(OrderDetail orderDetail);
    }
}
