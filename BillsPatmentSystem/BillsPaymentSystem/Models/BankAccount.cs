using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BillsPaymentSystem.Models
{
  public class BankAccount:BillingDetail
    {
        public string BankName { get; set; }
        public string SwiftCode { get; set; }
    }
}
