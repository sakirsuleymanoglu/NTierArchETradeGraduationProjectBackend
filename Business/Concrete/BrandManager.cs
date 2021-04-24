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
    public class BrandManager : IBrandService
    {
        IBrandDal _brandDal;

        public BrandManager(IBrandDal brandDal)
        {
            _brandDal = brandDal;
        }
        public IResult Add(Brand brand)
        {
            var result = BusinessRules.Run(CheckIfAlreadyExistsBrandName(brand.Name));

            if (result != null)
            {
                return result;
            }

            _brandDal.Add(brand);

            return new SuccessResult();
        }

        public IResult Delete(Brand brand)
        {
            var result = BusinessRules.Run(CheckIfExistsBrand(brand.Id));

            if (result != null)
            {
                return result;
            }

            _brandDal.Delete(brand);

            return new SuccessResult();
        }

        public IDataResult<List<Brand>> GetAll()
        {
            var result = _brandDal.GetAll();

            return new SuccessDataResult<List<Brand>>(result);
        }

        public IDataResult<Brand> GetById(int id)
        {
            var result = BusinessRules.Run(CheckIfExistsBrand(id));

            if (result != null)
            {
                return new ErrorDataResult<Brand>(result.Message);
            }

            var brand = _brandDal.Get(b => b.Id == id);

            return new SuccessDataResult<Brand>(brand);
        }

        public IResult Update(Brand brand)
        {
            var result = BusinessRules.Run(CheckIfExistsBrand(brand.Id), CheckIfAlreadyExistsBrandName(brand.Name));

            if (result != null)
            {
                return result;
            }

            _brandDal.Update(brand);

            return new SuccessResult();
        }

        private IResult CheckIfExistsBrand(int brandId)
        {
            var result = _brandDal.Get(b => b.Id == brandId);

            if (result == null)
            {
                return new ErrorResult();
            }

            return new SuccessResult();
        }

        private IResult CheckIfAlreadyExistsBrandName(string brandName)
        {
            var result = _brandDal.Get(b => b.Name == brandName);

            if (result != null)
            {
                return new ErrorResult();
            }

            return new SuccessResult();
        }
    }
}
