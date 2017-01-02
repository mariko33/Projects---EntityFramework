using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Models
{
    public class Team
    {
        private ICollection<Player> players;
        public Team()
        {
            this.players=new HashSet<Player>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Logo { get; set; }

        [StringLength(3)]
        public string Initials { get; set; }
        public Color PrimaryKitColor { get; set; }
        public Color SecondaryKitColor { get; set; }
        public string Town { get; set; }
        public string Budget { get; set; }
        public virtual ICollection<Player>Players
        {
            get { return this.players; }
            set { this.players = value; }
        }
    }
}
