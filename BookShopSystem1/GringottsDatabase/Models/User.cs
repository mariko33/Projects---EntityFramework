using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace GringottsDatabase.Models
{
    public class User
    {
        private string email;
        private string firstName;
        private string lastName;
        private ICollection<User> friends;
        private ICollection<Album> albums;
         
        public User()
        {
            
            this.friends=new HashSet<User>();
            this.albums=new HashSet<Album>();

        }
        [Key]
        public int Id { get; set; }

        [Required,MinLength(4),MaxLength(30)] 
        public string Username { get; set; }

        public string FirstName
        {
            get { return this.firstName; }
            set { this.firstName = value; } }

        public string LastName
        {
            get { return this.lastName; }
            set { this.lastName = value; }
        }

        [Required, MinLength(6), MaxLength(50)]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[$@$!%*?&])[A-Za-z\d$@$!%*?&]{6,50}")]
        public string Password { get; set; }

        public string Email
        {
            get { return this.email; }
            set
            {
                //string pattern =
                //    "/^(([^<>()\\[\\]\\.,;:\\s@\\\"]+(\\.[^<>()\\[\\]\\.,;:\\s@\\\"]+)*)|(\\\".+\\\"))@(([^<>()[\\]\\.,;:\\s@\\\"]+\\.)+[^<>()[\\]\\.,;:\\s@\\\"]{2,})$/i";
                //    Regex regex=new Regex(pattern);
                //if (!regex.IsMatch(value))
                //{
                //    throw new ArgumentException("Email was invalid!");
                //}
                this.email = value;

            }
        }
        [MaxLength(1024*1024)]
        public byte[] ProfilePicture { get; set; }

        public DateTime RegisteredOn { get; set; }

        public DateTime LastTimeLoggedIn { get; set; }
        [Range(1,150)]
        public int BirthYears { get; set; }
        public bool IsDeleted { get; set; }

        public Town BornTown { get; set; }
        public Town CurrentlyLivingTown { get; set; }

        [NotMapped]
        public string FullName
        {
            get { return (this.firstName + " " + this.lastName); }
            
        }

        public virtual ICollection<User> Friends
        {
            get { return this.friends; }
            set { this.friends = value; }
        }

        public virtual ICollection<Album> Albums
        {
            get { return this.albums; }
            set { this.albums = value; }
        }



    }
}

