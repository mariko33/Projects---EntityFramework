using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealer.Models
{
  public class Part
  {
      private ICollection<Car> cars;

      public Part()
      {
          this.cars=new HashSet<Car>();
      }
        public int Id { get; set; }
        public string Name { get; set; }
        public double? Price { get; set; }
        public int Quantity { get; set; }

      public virtual ICollection<Car> Cars
      {
          get { return this.cars; }
            set { this.cars = value; }
          
      }

      public virtual Supplier Supplier { get; set; }
      public int SupplierId { get; set; }
    }
}
