using Business.Abstract;
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

        public void Add(Car entity)
        {
            if (entity.Description.Length>=2 && entity.DailyPrice>0)
            {
                 _carDal.Add(entity);
            }
            else
            {
                Console.WriteLine("Araba özelliklerini yanlış girdiniz"); 
            }
        }

        public void Delete(Car entity)
        {
            _carDal.Delete(entity);
        }

        public List<Car> GetAll()
        {
            return _carDal.GetAll();
        }

        public List<CarDetailDto> GetCarDetails()
        {
            return _carDal.GetCarDetails();
        }

        public List<Car> GetCarsByBrandId()
        {
            return _carDal.GetAll();
        }

        public List<Car> GetCarsByColorId()
        {
            return _carDal.GetAll();
        }

        public void Update(Car entity)
        {
             _carDal.Update(entity);
                
        }
    }
}
