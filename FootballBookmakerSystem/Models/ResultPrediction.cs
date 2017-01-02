using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class ResultPrediction
    {
        public ResultPrediction()
        {
            
        }
        //[Key]
        //public int BetId { get; set; }
        public int Id { get; set; }
        public Prediction Prediction { get; set; }
        //public User User { get; set; }
    }
}
