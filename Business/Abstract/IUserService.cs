using Core.Entities.Concrete;
using Core.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IUserService
    {
        List<OperationClaim> GetClaims(User entity);

        IResult Add(User entity);
        IResult Update(User entity);
        IResult UpdatePassword(User entity, string password);
        IResult Delete(User entity);
        IDataResult<List<User>> GetAll();
        IDataResult<User> GetByMail(string email);
        IDataResult<User> GetById(int id);


    }
}
