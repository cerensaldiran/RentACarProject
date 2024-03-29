﻿using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarDal : EfEntityRepositoryBase<Car, dbCarContext>, ICarDal
    {
        public List<CarDetailDto> GetCarDetails()
        {
            using (dbCarContext context=new dbCarContext())
            {
                var result = from c in context.Cars
                             join cl in context.Colors on c.ColorId equals cl.Id
                             join b in context.Brands on c.BrandId equals b.Id
                             
                             select new CarDetailDto
                             {
                                 Description = c.Description,
                                 BrandName = b.Name,
                                 ColorName = cl.Name,
                                 DailyPrice = c.DailyPrice,
                                 BrandId = b.Id,
                                 ColorId = cl.Id,
                                 ModelName = c.ModelName,
                                 CarId=c.Id,
                                 CarImage = (from i in context.CarImages
                                             where i.CarId==c.Id
                                             select i.ImagePath).FirstOrDefault()
                                 

                             };
                return result.ToList();
                            
            }
        }
    }
}
