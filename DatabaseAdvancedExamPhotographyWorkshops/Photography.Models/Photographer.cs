using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Photography.Models
{
    public class Photographer
    {
        public Photographer()
        {
            this.Lens=new HashSet<Len>();
            this.Accessories=new HashSet<Accessory>();
            this.TrainerWorkShops=new HashSet<WorkShop>();
            this.ParticipantsWorkShops=new HashSet<WorkShop>();
        }

        public int Id { get; set; }
        [Required]
        public string FirstName { get; set; }

        [Required,MinLength(2),MaxLength(50)]
        public string LastName { get; set; }

        [Phone]
        public string Phone { get; set; }

        
        public int PrimaryCameraId { get; set; }

        [Required]
        public virtual Camera PrimaryCamera { get; set; }

        [Required]
        public int SecondaryCameraId { get; set; }
        public virtual Camera SecondaryCamera { get; set; }
        public virtual ICollection<Len>Lens { get; set; }
        public virtual ICollection<Accessory>Accessories { get; set; }
        public virtual ICollection<WorkShop>TrainerWorkShops { get; set; }
        public virtual ICollection<WorkShop>ParticipantsWorkShops { get; set; }
    }
}