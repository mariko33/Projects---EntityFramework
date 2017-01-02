using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShopSystem1.Models
{
   public class Category
    {
        public Category()
        {
            
        }
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
    }
}
