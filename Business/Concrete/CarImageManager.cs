using Business.Abstract;
using Business.Constants;
using Core.Utilities.Business;
using Core.Utilities.Helper.FileHelper;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class CarImageManager : ICarImageService
    {
        ICarImageDal _carImageDal;
        IFileHelper _fileHelper;

        public CarImageManager(ICarImageDal carImageDal, IFileHelper fileHelper)
        {
            _carImageDal = carImageDal;
            _fileHelper = fileHelper;
        }

        public IResult Add(IFormFile file, CarImage carImage)
        {
            IResult result = BusinessRules.Run(CheckIfCarImageLimit(carImage.CarId));
            if (result!=null)
            {
                return result;
            }
            carImage.ImagePath = _fileHelper.Upload(file, PathConstants.ImagesPath);
            carImage.Date = DateTime.Now;
            _carImageDal.Add(carImage);
            return new SuccessResult("Resim başarıyla eklendi");

        }

        public IResult Delete(CarImage carImage)
        {
            throw new NotImplementedException();
        }

 

        public IDataResult<List<CarImage>> GetAll()
        {
            throw new NotImplementedException();
        }

        public IDataResult<List<CarImage>> GetByCarId(int carImage)
        {
            throw new NotImplementedException();
        }

        public IResult Update(IFormFile file, CarImage carImage)
        {
            throw new NotImplementedException();
        }

        private IResult CheckIfCarImageLimit(int id)
        {
            var result = _carImageDal.GetAll(p=>p.CarId==id).Count;
            if (result>5)
            {
                return new ErrorResult();
            }
            return new SuccessResult();
        }

        IDataResult<CarImage> ICarImageService.GetByImageId(int carImage)
        {
            throw new NotImplementedException();
        }
    }
}
