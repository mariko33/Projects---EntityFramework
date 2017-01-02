using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BillsPaymentSystem.Models
{
   public class CreditCard :BillingDetail
    {
        public string CardType { get; set; }
        public int ExpirationMount { get; set; }
        public int ExpirationYear { get; set; }
    }
}
