using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using System;

namespace ConsoleUI
{
    public class Program
    {
        static void Main(string[] args)
        {
            CarManager carManager = new CarManager(new EfCarDal());
            //AddCar(carManager);

            //UpdateCar(carManager);


            //DeleteCar(carManager);





            foreach (var item in carManager.GetCarDetails())
            {
                Console.WriteLine(item.CarName + " " + item.BrandName + " " + item.ColorName + " " + item.DailyPrice);
            }

        }

        private static void DeleteCar(CarManager carManager)
        {
            carManager.Delete(new Car()
            {
                Id = 1004
            });
        }

        private static void UpdateCar(CarManager carManager)
        {
            carManager.Update(new Car()
            {
                Id = 1,
                BrandId = 2,
                ColorId = 1,
                DailyPrice = 450,
                Description = "Audi",
                ModelYear = "2010"
            });
        }

        private static void AddCar(CarManager carManager)
        {
            var result = carManager.Add(new Car()
            {
                BrandId = 5,
                ColorId = 3,
                DailyPrice = 600,
                Description = "Clio",
                ModelYear = "2018"

            });
            Console.WriteLine(result.Message);
        }
    }
}
