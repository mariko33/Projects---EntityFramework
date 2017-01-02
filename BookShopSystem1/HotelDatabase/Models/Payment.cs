using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelDatabase.Models
{
   public class Payment
    {
        public Payment()
        {
            
        }

        [Key]
        public int Id { get; set; }

        public DateTime PaymentDate { get; set; }
        public Customer Customer { get; set; }
        public DateTime FirstDateOccupied { get; set; }
        public DateTime LastDateOccupied { get; set; }
        public int TotalDays { get; set; }
        public decimal AmountCharged { get; set; }
        public decimal TaxRate { get; set; }
        public decimal TaxAmount { get; set; }
        public decimal PaymantTotal { get; set; }
        public string Notes { get; set; }
    }
}
