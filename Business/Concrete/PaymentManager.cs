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
    public class PaymentManager:IPaymentService
    {
        private IPaymentDal _paymentDal;

        public PaymentManager(IPaymentDal paymentDal)
        {
            _paymentDal = paymentDal;
        }

        public IResult Pay(Payment entity)
        {
        
                var result = _paymentDal.Get(p =>
                p.Name == entity.Name
                && p.CardNumber == entity.CardNumber
                && p.Cvv == entity.Cvv
                && p.ExpirationMonth == entity.ExpirationMonth
                && p.ExpirationYear == entity.ExpirationYear
                );
                if (result != null)
                {
                    return new SuccessResult(Messages.SuccessfullPay);
                }
                return new ErrorResult(Messages.CardInformationIsIncorrect);
            
        }
    }
}
