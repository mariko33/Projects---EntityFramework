using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalSystem.Models
{
   public class Visitation
    {
        public Visitation()
        {
            
        }
        [Key]
        public int Id { get; set; }

        public DateTime Date { get; set; }
        public string Comments { get; set; }

        public Doctor  Doctor { get; set; }
        
    }
}
