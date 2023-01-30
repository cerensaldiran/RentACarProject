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


            carManager.Add(new Car()
            {
                BrandId = 3,
                ColorId = 1,
                DailyPrice = 450,
                Description = "BMW",
                ModelYear = "2018"

            });

            //carManager.Update(new Car()
            //{
            //    Id=1,
            //    BrandId=2,
            //    ColorId=1,
            //    DailyPrice=450,
            //    Description="Audi",
            //    ModelYear="2010"
            //});


            //carManager.Delete(new Car()
            //{
            //    Id = 1004
            //});

            foreach (var item in carManager.GetAll())
            {
                Console.WriteLine(item.Description);
            }

        }
    }
}
