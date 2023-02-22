using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfRentalDal : EfEntityRepositoryBase<Rental, dbCarContext>, IRentalDal
    {
        public List<RentalDetailDto> GetRentalDetails()
        {
            using (dbCarContext context = new dbCarContext())
            {
                var result = from r in context.Rentals
                             join cs in context.Customers on r.CustomerId equals cs.Id
                             join b in context.Brands on r.CarId equals b.Id
                             join u in context.Users on cs.UserId equals u.Id
                             select new RentalDetailDto
                             {
                                 BrandName = b.Name,
                                 CustomerName = u.FirstName + " " + u.LastName,
                                 RentDate = r.RentDate,
                                 ReturnDate = r.ReturnDate,
                                 Id = r.Id

                             };
                return result.ToList();
            }
        }
    }
}
