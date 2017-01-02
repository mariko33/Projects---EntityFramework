using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalSystem.Models
{
   public class Doctor
   {
       private ICollection<Visitation> visitations;
        public Doctor()
        {
            this.visitations=new HashSet<Visitation>();
            this.Patients=new HashSet<Patient>();
            
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Speciality { get; set; }
        public virtual ICollection<Visitation>Visitations { get; set; }
        public virtual ICollection<Patient> Patients { get; set; }
        
    }
}
