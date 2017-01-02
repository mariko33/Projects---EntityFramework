using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SalesDatabase.Models;

namespace SalesDatabase
{
    class Program
    {
        static void Main()
        {
            SalesContext context=new SalesContext();
            Customer customer = new Customer()
            {
                Name = "Misho",
                CreditCardNumber = "123505054",
                Email = "mmm@msms.bg",

            };

            context.Customers.Add(customer);
            context.SaveChanges();
        }
    }
}
