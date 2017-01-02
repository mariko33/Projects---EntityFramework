using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
  public class Game
  {
      private ICollection<PlayerStatistic> playersStatistics;
      private ICollection<Bet> bets;
        public Game()
        {
         this.playersStatistics = new HashSet<PlayerStatistic>();
            this.bets=new HashSet<Bet>();   
        }

        public int Id { get; set; }
        public Team HomeTeam { get; set; }
        public Team AwayTeam { get; set; }
        public int HomeGoals { get; set; }
        public int AwayGoals { get; set; }
        public DateTime DateOfTimeOfGames { get; set; }
        public Bet HomeTeamWinBetRate { get; set; }
        public Bet AwayTeamBetRate { get; set; }
        public Round Round { get; set; }
        public Competition Competition { get; set; }

      public virtual ICollection<PlayerStatistic> PlayerStatistics
      {
          get { return this.playersStatistics; }
            set { this.playersStatistics = value; } 
          
      }
        public virtual ICollection<Bet>Bets
        {
            get { return this.bets; }
            set { this.bets = value; }
        }

    }
}
