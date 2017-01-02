using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Round
    {
        private ICollection<Game> games;
        public Round()
        {
            this.games=new HashSet<Game>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Game>Games
        {
            get { return this.games; }
            set { this.games = value; }
        }
    }
}
