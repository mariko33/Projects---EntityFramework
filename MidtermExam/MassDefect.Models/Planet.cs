using System;
using System.CodeDom;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MassDefect.Models
{
   public class Planet
   {
       private ICollection<Person> people;
       private ICollection<Anomaly> originAnomalies;
       private ICollection<Anomaly> teleportAnomalies;

       public Planet()
       {
            this.people=new HashSet<Person>();
            this.originAnomalies=new HashSet<Anomaly>();
            this.teleportAnomalies=new HashSet<Anomaly>();
       }
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
        public int SolarSystemId { get; set; }
        public virtual SolarSystem SolarSystem { get; set; }
        public int SunId { get; set; }
        public virtual Star Sun { get; set; }
        public virtual ICollection<Person>People { get { return this.people; } set { this.people = value; } }

       [InverseProperty("OriginPlanet")]
       public virtual ICollection<Anomaly> OriginAnomalies
       {
           get { return this.originAnomalies; }
            set { this.originAnomalies = value; } 
           
       }

       [InverseProperty("TeleportPlanet")]
       public virtual ICollection<Anomaly> TeleportAnomalies
       {
           get { return this.teleportAnomalies; }
            set { this.teleportAnomalies = value; } 
           
       }

       
    }
}
