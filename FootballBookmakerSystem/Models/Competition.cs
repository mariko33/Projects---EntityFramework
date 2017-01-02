using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Competition
    {
        private ICollection<Game> games;
           
        public Competition()
        {
            this.games=new HashSet<Game>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public Type Type { get; set; }
        public virtual ICollection<Game>Games
        {
            get { return this.games; }
            set { this.games = value; }
        }
    }
}
