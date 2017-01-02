using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Reflection.Emit;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace MassDefect.Models
{
   public class Planet
    {
        public Planet()
        {
            this.Persons=new HashSet<Person>();
            this.OriginAnomalies=new HashSet<Anomaly>();
            this.TeleportAnomalies=new HashSet<Anomaly>();
        }
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
        public virtual Star Sun { get; set; }
        public int  SunId { get; set; }
        public virtual SolarSystem SolarSystem { get; set; }
        public int SoarSystemId { get; set; }
        public virtual ICollection<Person>Persons { get; set; }

        [InverseProperty("OriginPlanet")]
        public virtual ICollection<Anomaly>OriginAnomalies { get; set; }

        [InverseProperty("TeleportPlanet")]
        public virtual ICollection<Anomaly>TeleportAnomalies { get; set; }
    }
}
