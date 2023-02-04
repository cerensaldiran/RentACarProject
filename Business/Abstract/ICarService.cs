using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface ICarService
    {
        List<Car> GetAll();
        List<Car> GetCarsByBrandId();
        List<Car> GetCarsByColorId();
        IResult Add(Car entity);
        void Update(Car entity);
        void Delete(Car entity);
        List<CarDetailDto> GetCarDetails();
    }
}
