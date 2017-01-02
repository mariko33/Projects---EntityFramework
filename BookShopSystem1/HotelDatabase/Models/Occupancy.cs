using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelDatabase.Models
{
    public class Occupancy
    {
        public Occupancy()
        {
            
        }

        public int Id { get; set; }
        public DateTime DateOccupied { get; set; }
        public Customer Customer { get; set; }
        public Room Room { get; set; }
        public decimal RateApplied { get; set; }
        public decimal PhoneCharge { get; set; }
        public string Notes { get; set; }
    }
}
