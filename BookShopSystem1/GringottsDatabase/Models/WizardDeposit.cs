using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GringottsDatabase.Models
{
   public class WizardDeposit
    {
        public WizardDeposit()
        {

        }

        [Key]
        public double Id { get; set; }

        [MaxLength(50)]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(60)]
        public string LastName { get; set; }

        [MaxLength(1000)]
        public string Notes { get; set; }

        
        [Required]
        public int Age { get; set; }

        [Required]
        [MaxLength(100)]
        public string MagicWandCreator { get; set; }

        public double? MagicWandSize { get; set; }

        [MaxLength(20)]
        public string DepositGroup { get; set; }

        public DateTime? DepositStartDate { get; set; }

        public Decimal? DepositAmount { get; set; }

        public double? DepositInterest { get; set; }

        public double? DepositCharge { get; set; }

        public DateTime? DepositExperationDate { get; set; }

        public Boolean? IsDepositExpired { get; set; }


    }
}
