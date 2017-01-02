using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Bet
    {
        private ICollection<Game> games;
        public Bet()
        {
            this.games=new HashSet<Game>();
        }

        public int Id { get; set; }
        public decimal BetMoney { get; set; }
        public DateTime DateAndTimeOfBet { get; set; }
        public User User { get; set; }
        public virtual ICollection<Game>Games
        {
            get { return this.games; }
            set { this.games = value; }
        }
        public ResultPrediction ResultPrediction { get; set; }
    }
}
