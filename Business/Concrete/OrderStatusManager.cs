using Business.Abstract;
using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class OrderStatusManager : IOrderStatusService
    {
        public IResult Add(OrderStatus orderStatus)
        {
            throw new NotImplementedException();
        }

        public IResult Delete(OrderStatus orderStatus)
        {
            throw new NotImplementedException();
        }

        public IDataResult<List<OrderStatus>> GetAll()
        {
            throw new NotImplementedException();
        }

        public IDataResult<OrderStatus> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public IResult Update(OrderStatus orderStatus)
        {
            throw new NotImplementedException();
        }
    }
}
