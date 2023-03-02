using Business.Abstract;
using Business.BusinessAspect.Autofac;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspect.Autofac.Caching;
using Core.Aspect.Autofac.Performance;
using Core.Aspect.Autofac.Transaction;
using Core.Aspect.Autofac.Validation;
using Core.CrossCuttingConcerns.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        ICarDal _carDal;

        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;
        }

        [SecuredOperation("entity.add, admin")]
        [ValidationAspect(typeof(CarValidator))]
        [CacheRemoveAspect("IProductService.Get")]
        public IResult Add(Car entity)
        {

                _carDal.Add(entity);
                return new SuccessResult(Messages.CarAdded);
     
        }

        public IResult Delete(Car entity)
        {

            _carDal.Delete(entity);
            return new SuccessResult(Messages.CarDeleted);
        }

        [CacheAspect]
        public IDataResult<List<Car>> GetAll()
        {
            if (DateTime.Now.Hour==17)
            {
                return new ErrorDataResult<List<Car>>(Messages.CarNameInvalid);
            }
            else
            {
                return new SuccessDataResult<List<Car>>(_carDal.GetAll(), Messages.CarsListed);
            }
        }

        public IDataResult<List<CarDetailDto>> GetCarDetails()
        {
            return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarDetails(),Messages.CarsListed);
        }

        public IDataResult<List<CarDetailDto>> GetCarsByBrandId(int id)
        {
            return new SuccessDataResult<List<CarDetailDto>> (_carDal.GetCarDetails().Where(p=>p.BrandId==id).ToList());
        }

        public IDataResult<List<CarDetailDto>> GetCarsByColorId(int id)
        {
            return new SuccessDataResult<List< CarDetailDto >>( _carDal.GetCarDetails().Where(c=>c.ColorId==id).ToList());
        }

        [ValidationAspect(typeof(CarValidator))]
        [CacheRemoveAspect("IProductService.Get")]
        public IResult Update(Car entity)
        {
             _carDal.Update(entity);
            return new SuccessResult(Messages.CarUpdated);
        }

        [CacheAspect]
        //[PerformanceAspect(5)]
        public IDataResult<List<CarDetailDto>> GetById(int id)
        {
            return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarDetails().Where(c => c.CarId == id).ToList());
        }

        [TransactionScopeAspect]
        public IResult AddTransactionalTest(Car entity)
        {
            Add(entity);
            if (entity.DailyPrice<500)
            {
                throw new Exception("");
            }
            Add(entity);
            return null;
        }
    }
}
