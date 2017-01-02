using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesDatabase.Models
{
   public class StoreLocation
   {
       private  ICollection<Sale> salesInStore;
        public StoreLocation()
        {
            this.salesInStore=new HashSet<Sale>();
        }
        [Key]
        public int Id { get; set; }

        public string LocationName { get; set; }

       public virtual ICollection<Sale> SalesInStore
       {
            get { return this.salesInStore; }
            set { this.salesInStore = value; }
       }


    }
}
