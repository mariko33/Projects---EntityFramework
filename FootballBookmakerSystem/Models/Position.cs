using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
   public class Position
   {
       private ICollection<Player> players;
        public Position()
        {
            this.players=new HashSet<Player>();
        }

        [StringLength(2),Key]
        public string Id { get; set; }

        public string PositionDescription { get; set; }
        public virtual ICollection<Player>Players
        {
            get { return this.players; }
            set { this.players = value; }
        }
    }
}
