using Business.Abstract;
using Business.Constants;
using Core.Aspect.Autofac.Validation;
using Core.Utilities.Business;
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
    public class RentalManager:IRentalService
    {
        IRentalDal _rentalDal;
        public RentalManager(IRentalDal rentalDal)
        {
            _rentalDal = rentalDal;
        }

      //  [ValidationAspect(typeof(RentalValidator))]
        public IResult Add(Rental entity)
        {
            //var rentCar = _rentalDal.Get(c=>c.CarId==entity.CarId && c.ReturnDate==null);
            //if (rentCar==null)
            //{
            //    _rentalDal.Add(entity);
            //    return new SuccessResult(Messages.RentalAdded);
            //}
            //else
            //{
            //    return new ErrorResult(Messages.RentalFailed);
            //}
            var result = BusinessRules.Run(
            CheckIfCarIsAlreadyRentedInSelectedDate(entity),
            CheckIfReturnDateIsBeforeRentDate(entity.ReturnDate, entity.RentDate),
            CheckIfThisCarHasBeenReturned(entity)

            );
            if (result != null)
            {
                return result;
            }
            return new SuccessResult("Ödeme Sayfasına Yönlendiriliyorsunuz.");


        }

        public IResult Delete(Rental entity)
        {
            _rentalDal.Delete(entity);
            return new ErrorResult(Messages.RentalDeleted);
        }

        public IDataResult<List<Rental>> GetAll()
        {
            return new SuccessDataResult<List<Rental>>(_rentalDal.GetAll(), Messages.RentalListed);
        }

        public IDataResult<List<RentalDetailDto>> GetRentalDetails()
        {
            return new SuccessDataResult<List<RentalDetailDto>>(_rentalDal.GetRentalDetails(), Messages.CarsListed);
        }

        //public IResult RulesForAdding(Rental entity)
        //{
        //    var result = BusinessRules.Run(
        //        CheckIfCarIsAlreadyRentedInSelectedDate(entity),
        //        CheckIfReturnDateIsBeforeRentDate(entity.ReturnDate, entity.RentDate)
        //        );
        //    if (result != null)
        //    {
        //        return result;
        //    }
        //    return new SuccessResult("Ödeme Sayfasına Yönlendiriliyorsunuz.");

        //}

        public IResult Update(Rental entity)
        {
            _rentalDal.Update(entity);
            return new SuccessResult(Messages.RentalUpdated);
        }
  
        private IResult CheckIfCarIsAlreadyRentedInSelectedDate(Rental entity)
        {
            var result = _rentalDal.Get(r =>
             r.CarId == entity.CarId
             && (r.RentDate.Date == entity.RentDate.Date
             || (r.RentDate.Date < entity.RentDate.Date
             && (r.ReturnDate == null
             || ((DateTime)r.ReturnDate).Date > entity.RentDate.Date)))
            );
            if (result != null)
            {
                return new ErrorResult(Messages.CarIsAlreadyRentedInSelectedDate);
            }
            return new SuccessResult();
        }
        private IResult CheckIfThisCarHasBeenReturned(Rental entity)
        {
            var result = _rentalDal.Get(r => r.CarId == entity.CarId && r.ReturnDate == null);

            if (result != null)
            {
                if (entity.ReturnDate == null || entity.ReturnDate > result.RentDate)
                {
                    return new ErrorResult(Messages.CarIsAlreadyRentedInSelectedDate);
                }
            }
            return new SuccessResult();




        }
        private IResult CheckIfReturnDateIsBeforeRentDate(DateTime? returnDate, DateTime rentDate)
        {
            if (returnDate != null)
                if (returnDate < rentDate)
                {
                    return new ErrorResult(Messages.CarDateError);
                }
            return new SuccessResult();
        }

    }
}
