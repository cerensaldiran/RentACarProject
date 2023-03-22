using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface ICreditCardService
    {
        IResult Add(CreditCard entity);
        IResult Delete(int id, int userId);
        IDataResult<CreditCard> Get(int userId);
        IDataResult<List<CreditCard>> GetAll(int userId);
        
    }
}
