using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BillsPaymentSystem.Models
{
   public class User
   {
       private ICollection<BillingDetail> billingDetails;
        public User()
        {
            billingDetails=new HashSet<BillingDetail>();
        }

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

       public virtual ICollection<BillingDetail> BillingDetails
       {
            get { return this.billingDetails; }
            set { this.billingDetails = value; }
           
       }
    }
}
