using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalSystem.Models
{
   public class Patient
   {
       private ICollection<Visitation> visitations;
       private ICollection<Diagnose> diagnoses;
       private ICollection<Medicament> medicaments;
          
        public Patient()
        {
            this.visitations=new HashSet<Visitation>();
            this.diagnoses=new HashSet<Diagnose>();
            this.medicaments=new HashSet<Medicament>();
            this.Doctors=new HashSet<Doctor>();
            
        }
        [Key]
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public DateTime? DateOfBirth { get; set; }
       // public  byte[] Picture { get; set; }
       // public bool HasMedicalInsurance { get; set; }

        public virtual ICollection<Visitation> Visitations
        {
            get { return this.visitations; }
            set { this.visitations = value; }
        }
        public virtual ICollection<Diagnose> Diagnoses
        {
            get { return this.diagnoses; }
            set { this.diagnoses = value; }
        }
        public virtual ICollection<Medicament> Medicaments
        {
            get { return this.medicaments; }
            set { this.medicaments = value; }
        }

       public virtual ICollection<Doctor>Doctors { get; set; }
    }
}
