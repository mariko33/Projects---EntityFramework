using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
   public class Player
   {
       private ICollection<Game> games;
        public Player()
        {
            this.games=new HashSet<Game>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string SquadNumber { get; set; }
        public Team Team { get; set; }
        public Position Position { get; set; }
        public bool IsCurrentlyInjured { get; set; }
        public virtual ICollection<Game> Games
        { get { return this.games; }
            set { this.games = value; } }
        public PlayerStatistic PlayerStatistic { get; set; }


    }
}
