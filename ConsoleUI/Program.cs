using Business.Concrete;
using Core.Entities.Concrete;
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
            UserManager userManager = new UserManager(new EfUserDal());
            RentalManager rentalManager = new RentalManager(new EfRentalDal());
            //AddCar(carManager);

            //UpdateCar(carManager);


            //DeleteCar(carManager);

            //AddUser(userManager);
            var result = rentalManager.Add(new Rental()
            {
                CarId=3,
                CustomerId=1,
                RentDate=DateTime.Now
                
            });
            Console.WriteLine(result.Message);






            //foreach (var item in carManager.GetCarDetails().Data)
            //{
            //    Console.WriteLine(item.CarName + " " + item.BrandName + " " + item.ColorName + " " + item.DailyPrice);

            //}
            //Console.WriteLine(carManager.GetCarDetails().Message);

        }

        //private static void AddUser(UserManager userManager)
        //{
        //    var result = userManager.Add(new User()
        //    {
        //        FirstName = "Ceren",
        //        Lastname = "Saldıran",
        //        Email = "cerensaldirann@gmail.com",
        //        Password = "123456"
        //    });
        //    Console.WriteLine(result.Message);
        //}

        private static void DeleteCar(CarManager carManager)
        {
            var result= carManager.Delete(new Car()
            {
                Id = 1008
            });
            Console.WriteLine(result.Message);
        }

        private static void UpdateCar(CarManager carManager)
        {
            var result= carManager.Update(new Car()
            {
                Id = 1007,
                BrandId = 2,
                ColorId =5,
                DailyPrice = 450,
                Description = "Audi",
                ModelYear = "2012"
            });
            Console.WriteLine(result.Message);
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
