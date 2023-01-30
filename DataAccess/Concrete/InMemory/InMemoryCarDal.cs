using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryCarDal 
    {
        List<Car> _cars;

        public InMemoryCarDal()
        {
            _cars = new List<Car>
            {
                new Car { Id=1, BrandId=1, ColorId=1, ModelYear="2010", DailyPrice=500, Description=" Kırmızı BMW"},
                new Car { Id=2, BrandId=1, ColorId=2, ModelYear="2012", DailyPrice=600, Description=" Beyaz BMW"},
                new Car { Id=3, BrandId=2, ColorId=1, ModelYear="2019", DailyPrice=800, Description=" Kırmızı Toyota"},
                new Car { Id=4, BrandId=3, ColorId=2, ModelYear="2020", DailyPrice=1000, Description=" Beyaz Mustang"},
                new Car { Id=5, BrandId=4, ColorId=3, ModelYear="2008", DailyPrice=400, Description=" Siyah Tata"}
            };
            
        }

        public void Add(Car car)
        {
            _cars.Add(car);
        }

        public void Delete(Car car)
        {
            Car DeleteCar = _cars.SingleOrDefault(p => p.Id == car.Id);
            _cars.Remove(DeleteCar);
        }

        public List<Car> GetAll()
        {
            return _cars;
        }

        public List<Car> GetById(int id)
        {
            return _cars.Where(p => p.Id == id).ToList();
        }

        public void Update(Car car)
        {
            Car CarUpdate = _cars.SingleOrDefault(p => p.Id == car.Id);
            CarUpdate.Id = car.Id;
            CarUpdate.BrandId = car.BrandId;
            CarUpdate.ColorId = car.ColorId;
            CarUpdate.DailyPrice = car.DailyPrice;
            CarUpdate.Description = car.Description;
            CarUpdate.ModelYear = car.ModelYear;
        }
    }
}
