using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
   public class BetGame
    {

        [Key]
        [Column(Order = 0)]
        public Game Game { get; set; }

        [Key]
        [Column(Order = 1)]
        public Bet Bet { get; set; }

        public ResultPrediction ResultPrediction { get; set; }
    }
}
