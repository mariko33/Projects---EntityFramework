using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesDatabase.Models
{
   public class Product
   {
       private ICollection<Sale> salesOfProduct;
        public Product()
        {
            this.salesOfProduct=new HashSet<Sale>();
        }
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }
        public double Quantity { get; set; }
        public decimal Price { get; set; }
        public virtual ICollection<Sale> SalesOfProduct
        {
            get { return this.salesOfProduct; }
            set { this.salesOfProduct = value; }
        }

    }
}
