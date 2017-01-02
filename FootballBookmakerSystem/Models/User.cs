using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
   public class User
   {
       private ICollection<Bet> bet;
        public User()
        {
            this.bet=new HashSet<Bet>();
            
        }

        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string FullName { get; set; }
        public decimal Balance { get; set; }
        public virtual ICollection<Bet>Bets
        {
            get { return this.bet; }
            set { this.bet = value; }
        }

    }
}
