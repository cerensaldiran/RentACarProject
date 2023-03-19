using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class CreditCard :IEntity
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string CardNumber { get; set; }
        public string Cvv { get; set; }
        public string ExpirationMonth{ get; set; }
        public string ExpirationYear{ get; set; }
        public string Name { get; set; }
    }
}
