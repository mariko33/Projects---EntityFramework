using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductsShop.Models
{
   public class Category
   {
       private ICollection<Product> products;

       public Category()
       {
           this.products=new HashSet<Product>();
       }

        [Required]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }


       public virtual ICollection<Product> Products
       {
           get { return this.products; }
            set { this.products = value; } 
           
       }
    }
}
