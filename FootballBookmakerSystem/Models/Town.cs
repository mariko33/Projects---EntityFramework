using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
   public class Town
   {
       private ICollection<Team> teams;
        public Town()
        {
            this.teams=new HashSet<Team>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public Country Country { get; set; }

       public virtual ICollection<Team> Teams
       {
            get { return this.teams; }
            set { this.teams = value; }
       }
    }
}
