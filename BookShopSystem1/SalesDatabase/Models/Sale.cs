using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesDatabase.Models
{
   public class Sale
    {
        public Sale()
        {
            
        }
        [Key]
        public int Id { get; set; }

        public Product Product { get; set; }

        public Customer Customer { get; set; }

        public StoreLocation StoreLocation { get; set; }
        public DateTime Date { get; set; }

        


    }
}
