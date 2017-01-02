using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GringottsDatabase.Models
{
   public class Album
   {
       private ICollection<Picture> pictures;
       private ICollection<Tag> tags;
       private ICollection<User> users;
        public Album()
        {
            this.pictures = new HashSet<Picture>();
            this.tags=new HashSet<Tag>();
            this.users=new HashSet<User>();
        }
        
        public int Id { get; set; }
        public string Name { get; set; }
        public string BackgroundColor { get; set; }
        public bool IsPublic { get; set; }
        public virtual ICollection<Picture> Pictures
        {
            get { return this.pictures; }
            set { this.pictures = value; }
        }
        public virtual ICollection<User>Users
        {
            get { return this.users; }
            set { this.users = value; }
        }
       public virtual ICollection<Tag>Tags
        {
            get { return this.tags; }
            set { this.tags = value; }
        }
    }
}
