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
    public class CityManager : ICityService
    {
        ICityDal _cityDal;
        ICountryService _countryService;

        public CityManager(ICityDal cityDal, ICountryService countryService)
        {
            _cityDal = cityDal;

            _countryService = countryService;
        }

        public IResult Add(City city)
        {
            var result = BusinessRules.Run(CheckIfAlreadyExistsCityName(city.Name));

            if (result != null)
            {
                return result;
            }

            _cityDal.Add(city);

            return new SuccessResult();
        }

        public IResult Delete(City city)
        {
            var result = BusinessRules.Run(CheckIfExistsCity(city.Id));

            if (result != null)
            {
                return result;
            }

            _cityDal.Delete(city);

            return new SuccessResult();
        }

        public IDataResult<List<City>> GetAll()
        {
            var result = _cityDal.GetAll();

            return new SuccessDataResult<List<City>>(result);
        }

        public IDataResult<City> GetById(int id)
        {
            var result = BusinessRules.Run(CheckIfExistsCity(id));

            if (result != null)
            {
                return new ErrorDataResult<City>(result.Message);
            }

            var city = _cityDal.Get(c => c.Id == id);

            return new SuccessDataResult<City>(city);
        }

        public IResult Update(City city)
        {
            var result = BusinessRules.Run(CheckIfExistsCity(city.Id), CheckIfAlreadyExistsCityName(city.Name));

            if (result != null)
            {
                return result;
            }

            _cityDal.Update(city);

            return new SuccessResult();
        }

        private IResult CheckIfExistsCity(int cityId)
        {
            var result = _cityDal.Get(c => c.Id == cityId);

            if (result == null)
            {
                return new ErrorResult();
            }

            return new SuccessResult();
        }

        private IResult CheckIfAlreadyExistsCityName(string cityName)
        {
            var result = _cityDal.Get(c => c.Name == cityName);

            if (result != null)
            {
                return new ErrorResult();
            }

            return new SuccessResult();
        }

        public IDataResult<List<City>> GetAllByCountry(int countryId)
        {
            var result = BusinessRules.Run(CheckIfExistsCountry(countryId));

            if (result != null)
            {
                return new ErrorDataResult<List<City>>(result.Message);
            }

            var cityListByCountry = _cityDal.GetAll(c => c.CountryId == countryId);

            return new SuccessDataResult<List<City>>(cityListByCountry);
        }

        private IResult CheckIfExistsCountry(int countryId)
        {
            var result = _countryService.GetById(countryId);

            if (result == null)
            {
                return new ErrorResult();
            }

            return new SuccessResult();
        }
    }
}
