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
    public class CountryManager : ICountryService
    {
        ICountryDal _countryDal;

        public CountryManager(ICountryDal countryDal)
        {
            _countryDal = countryDal;
        }
        public IResult Add(Country country)
        {
            var result = BusinessRules.Run(CheckIfAlreadyExistsCountryName(country.Name));

            if (result != null)
            {
                return result;
            }

            _countryDal.Add(country);

            return new SuccessResult();
        }

        public IResult Delete(Country country)
        {
            var result = BusinessRules.Run(CheckIfExistsCountry(country.Id));

            if (result != null)
            {
                return result;
            }

            _countryDal.Delete(country);

            return new SuccessResult();
        }

        public IDataResult<List<Country>> GetAll()
        {
            var result = _countryDal.GetAll();

            return new SuccessDataResult<List<Country>>(result);
        }

        public IDataResult<Country> GetById(int id)
        {
            var result = BusinessRules.Run(CheckIfExistsCountry(id));

            if (result != null)
            {
                return new ErrorDataResult<Country>(result.Message);
            }

            var country = _countryDal.Get(c => c.Id == id);

            return new SuccessDataResult<Country>(country);
        }

        public IResult Update(Country country)
        {
            var result = BusinessRules.Run(CheckIfExistsCountry(country.Id), CheckIfAlreadyExistsCountryName(country.Name));

            if (result != null)
            {
                return result;
            }

            _countryDal.Update(country);

            return new SuccessResult();
        }

        private IResult CheckIfExistsCountry(int countryId)
        {
            var result = _countryDal.Get(c => c.Id == countryId);

            if (result == null)
            {
                return new ErrorResult();
            }

            return new SuccessResult();
        }

        private IResult CheckIfAlreadyExistsCountryName(string countryName)
        {
            var result = _countryDal.Get(c => c.Name == countryName);

            if (result != null)
            {
                return new ErrorResult();
            }

            return new SuccessResult();
        }
    }
}
