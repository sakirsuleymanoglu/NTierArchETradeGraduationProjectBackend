﻿using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface ICityService
    {
        IDataResult<List<City>> GetAll();
        IDataResult<List<City>> GetAllByCountry(int countryId);
        IDataResult<City> GetById(int id);
        IResult Add(City city);
        IResult Delete(City city);
        IResult Update(City city);
    }
}
