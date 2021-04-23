using Business.Abstract;
using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class AddressManager : IAddressService
    {
        public IResult Add(Address address)
        {
            throw new NotImplementedException();
        }

        public IResult Delete(Address address)
        {
            throw new NotImplementedException();
        }

        public IDataResult<List<Address>> GetAll()
        {
            throw new NotImplementedException();
        }

        public IDataResult<Address> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public IResult Update(Address address)
        {
            throw new NotImplementedException();
        }
    }
}
