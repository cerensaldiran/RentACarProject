using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarDal : ICarDal
    {
        public void Add(Car entity)
        {
            using (dbCarContext context = new dbCarContext())
            {
                var addedEntity = context.Entry(entity);
                addedEntity.State = EntityState.Added;
                context.SaveChanges();
            }
        }

        public void Delete(Car entity)
        {
            using (dbCarContext context = new dbCarContext())
            {
                var deletedEntity = context.Entry(entity);
                deletedEntity.State = EntityState.Deleted;
                context.SaveChanges();
            }
        }

        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            using (dbCarContext context=new dbCarContext())
            {
                return filter == null
                    ? context.Set<Car>().ToList()
                    : context.Set<Car>().Where(filter).ToList();
            }
        }

        public Car GetById(Expression<Func<Car, bool>> filter)
        {
            using (dbCarContext context=new dbCarContext())
            {
                return context.Set<Car>().FirstOrDefault(filter);
            }
        }

        public List<Car> GetCarsByBrandId(Expression<Func<Car, bool>> filter = null)
        {
            using (dbCarContext context=new dbCarContext())
            {
                return context.Set<Car>().Where(filter).ToList();
            }
        }

        public List<Car> GetCarsByColorId(Expression<Func<Car, bool>> filter = null)
        {
            using (dbCarContext context = new dbCarContext())
            {
                return context.Set<Car>().Where(filter).ToList();
            }
        }

        public void Update(Car entity)
        {
            using (dbCarContext context = new dbCarContext())
            {
                var updatedEntity = context.Entry(entity);
                updatedEntity.State = EntityState.Modified;
                context.SaveChanges();
            }
        }
    }
}
