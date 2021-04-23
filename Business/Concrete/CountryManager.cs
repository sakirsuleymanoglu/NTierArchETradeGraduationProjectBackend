using Business.Abstract;
using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class CountryManager : ICountryService
    {
        public IResult Add(Country country)
        {
            throw new NotImplementedException();
        }

        public IResult Delete(Country country)
        {
            throw new NotImplementedException();
        }

        public IDataResult<List<Country>> GetAll()
        {
            throw new NotImplementedException();
        }

        public IDataResult<Country> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public IResult Update(Country country)
        {
            throw new NotImplementedException();
        }
    }
}
