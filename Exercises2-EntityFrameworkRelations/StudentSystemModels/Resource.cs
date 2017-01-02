using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace StudentSystemModels
{
   public class Resource
   {
       private  ICollection<License> licenses;
        public Resource()
        {
            this.licenses=new HashSet<License>();
        }

        [Key]
        public int Id { get; set; }

        public string Name { get; set; }
        public TypeOfResource TypeOfResource { get; set; }
        public string Url { get; set; }
       public virtual ICollection<License> Licenses
        {
            get { return this.licenses; }
            set { this.licenses = value; }
        }
        

    }
}
