using Business.Abstract;
using Business.Constants;
using Core.Entities.Concrete;
using Core.Utilities.Results;
using Core.Utilities.Security.Hashing;
using DataAccess.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class UserManager:IUserService
    {
        IUserDal _userDal;
        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
        }

        public IResult Add(User entity)
        {
            _userDal.Add(entity);
            return new SuccessResult(Messages.UserAdded);
        }

        public IResult Delete(User entity)
        {
            _userDal.Delete(entity);
            return new ErrorResult(Messages.UserDeleted);
        }

        public IDataResult<List<User>> GetAll()
        {
            return new SuccessDataResult<List<User>>( _userDal.GetAll(), Messages.UsersListed);
        }

        public IDataResult<User> GetById(int id)
        {
            var result = _userDal.Get(p => p.Id == id);
            if (result==null)
            {
                return new ErrorDataResult<User>(Messages.UserNotFound);
            }
            return new SuccessDataResult<User>(result, Messages.UsersListed);
        }

        public IDataResult<User> GetByMail(string email)
        {
            var result = _userDal.Get(p => p.Email == email);
            if (result == null)
            {
                return new ErrorDataResult<User>(Messages.UserNotFound);
            }
            return new SuccessDataResult<User>(result, Messages.MailListed);
        }

        public List<OperationClaim> GetClaims(User entity)
        {
            return _userDal.GetClaims(entity);
        }

        public IResult Update(User entity)
        {
            _userDal.Update(entity);
            return new SuccessResult(Messages.UserUpdated);
        }

        public IResult UpdatePassword(User entity, string password)
        {
            byte[] passwordHash, passwordSalt;
            HashingHelper.CreatePasswordHash(password, out passwordHash, out passwordSalt);
            var user = new User
            {
                Id = entity.Id,
                Email = entity.Email,
                FirstName = entity.FirstName,
                LastName= entity.LastName,
                PasswordHash = entity.PasswordHash,
                PasswordSalt = entity.PasswordSalt,
                Status = true
            };
            _userDal.Update(user);
            return new SuccessResult(Messages.UserAdded);
        }
    }
}
