using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class CreditCardManager : ICreditCardService
    {
        private ICreditCardDal _creditcardDal;

        public CreditCardManager(ICreditCardDal creditcardDal)
        {
            _creditcardDal = creditcardDal;
        }

        public IResult Add(CreditCard entity)
        {
            _creditcardDal.Add(entity);
            return new SuccessResult(Messages.CardAdded);
        }

        public IResult Delete(int id, int userId)
        {
            var creditCard = _creditcardDal.Get(c => c.Id==userId);
            if (creditCard.UserId != userId)
            {
                return new ErrorResult(Messages.AuthorizationDenied);
            }
            _creditcardDal.Delete(creditCard);
            return new SuccessResult(Messages.CardDeleted);
        }

        public IDataResult<CreditCard> Get(int userId)
        {
            return new SuccessDataResult<CreditCard>(_creditcardDal.Get(c => c.UserId == userId));
        }

        public IDataResult<List<CreditCard>> GetAll(int userId)
        {
            return new SuccessDataResult<List<CreditCard>>(_creditcardDal.GetAll(c=>c.UserId==userId));
        }


    }
}
