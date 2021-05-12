using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IOrderStatusService
    {
        IDataResult<List<OrderStatus>> GetAll();
        IDataResult<OrderStatus> GetById(int id);
        IResult Add(OrderStatus orderStatus);
        IResult Delete(OrderStatus orderStatus);
        IResult Update(OrderStatus orderStatus);
    }
}
