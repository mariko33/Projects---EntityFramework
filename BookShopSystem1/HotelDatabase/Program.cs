using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HotelDatabase.Models;

namespace HotelDatabase
{
    class Program
    {
        static void Main()
        {
            HotelContext context=new HotelContext();
            Employee misho = new Employee()
            {
                FirstName = "Misho",
                LastName = "Mishev",
                Title = "Nanana",
                Notes = "Namam belejki"
            };

            context.Employees.Add(misho);
            context.SaveChanges();



        }
    }
}
