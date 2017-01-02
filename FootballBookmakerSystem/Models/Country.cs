using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
  public class Country
  {
      private ICollection<Continent> continents;
      private ICollection<Town> towns;
        public Country()
        {
            this.continents=new HashSet<Continent>();
            this.towns=new HashSet<Town>();
        }
        [StringLength(3)]
        public string Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Continent> Continents
        {
            get { return this.continents; }
            set { this.continents = value; }
        }
        public virtual ICollection<Town> Towns
        {
            get { return this.towns; }
            set { this.towns = value; }
        }

    }
}
