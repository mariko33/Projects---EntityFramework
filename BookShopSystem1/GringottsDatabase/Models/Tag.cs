using GringottsDatabase.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GringottsDatabase.Models
{
   public class Tag
   {
       private ICollection<Album> albums;
        public Tag()
        {
            this.albums=new HashSet<Album>();
        }

        public int Id { get; set; }
        [Required, Tag]
        public string Name { get; set; }

        public virtual ICollection<Album>Albums
        {
            get { return this.albums; }
            set { this.albums = value; }
        }


    }
}
