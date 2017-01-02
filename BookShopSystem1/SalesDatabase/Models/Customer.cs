using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace SalesDatabase.Models
{
   public class Customer
   {
       private ICollection<Sale> salesOfCustomer;
        public Customer()
        {
            this.salesOfCustomer=new HashSet<Sale>();
        }

        [Key]
        public int Id { get; set; }

        public string Name { get; set; }
        public string Email { get; set; }
        public string CreditCardNumber { get; set; }

        public virtual ICollection<Sale>SalesOfCustomer
        {
            get { return this.salesOfCustomer; }
            set { this.salesOfCustomer = value; }
        }
        






    }
}
