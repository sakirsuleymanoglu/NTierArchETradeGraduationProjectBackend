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
    public class AddressManager : IAddressService
    {
        IAddressDal _addressDal;

        public AddressManager(IAddressDal addressDal)
        {
            _addressDal = addressDal;
        }
        public IResult Add(Address address)
        {
            _addressDal.Add(address);

            return new SuccessResult();
        }

        public IResult Delete(Address address)
        {
            var result = BusinessRules.Run(CheckIfExistsAddress(address.Id));

            if (result != null)
            {
                return result;
            }

            _addressDal.Delete(address);

            return new SuccessResult();
        }

        public IDataResult<List<Address>> GetAll()
        {
            var result = _addressDal.GetAll(a => a.Active == true);

            return new SuccessDataResult<List<Address>>(result);
        }

        public IDataResult<Address> GetById(int id)
        {
            var result = BusinessRules.Run(CheckIfExistsAddress(id));

            if (result != null)
            {
                return new ErrorDataResult<Address>(result.Message);
            }

            var address = _addressDal.Get(a => a.Id == id);

            return new SuccessDataResult<Address>(address);
        }

        public IResult Update(Address address)
        {
            var result = BusinessRules.Run(CheckIfExistsAddress(address.Id));

            if (result != null)
            {
                return result;
            }

            _addressDal.Update(address);

            return new SuccessResult();
        }

        public IResult CheckIfExistsAddress(int addressId)
        {
            var result = _addressDal.Get(a => a.Id == addressId);

            if (result == null)
            {
                return new ErrorResult();
            }

            return new SuccessResult();
        }
    }
}
