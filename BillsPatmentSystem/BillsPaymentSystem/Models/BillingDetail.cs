using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BillsPaymentSystem.Models
{
    public class BillingDetail
    {
        public int Id { get; set; }
        public int Number { get; set; }
        public User Owner { get; set; }
    }
}
