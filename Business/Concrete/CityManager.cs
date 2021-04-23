using Business.Abstract;
using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class CityManager : ICityService
    {
        public IResult Add(City city)
        {
            throw new NotImplementedException();
        }

        public IResult Delete(City city)
        {
            throw new NotImplementedException();
        }

        public IDataResult<List<City>> GetAll()
        {
            throw new NotImplementedException();
        }

        public IDataResult<City> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public IResult Update(City city)
        {
            throw new NotImplementedException();
        }
    }
}
