using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelDatabase.Models
{
  public class Customer
    {
        public Customer()
        {
            
        }
        [Key]
        public int AccountNumber { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string EmergencyName { get; set; }
        public string EmergencyNumber { get; set; }
        public string Notes { get; set; }

    }
}
