using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace BookShopSystem1.Models
{
    public class Book
    {
        private ICollection<Category> categories;
        public Book()
        {
            this.categories=new HashSet<Category>();
            
        }
        [Key]
        public int Id { get; set; }

        [MinLength(1)]
        [MaxLength(50)]
        [Required]
        public string Title { get; set; }

        [MaxLength(1000)]
        public string Description { get; set; }

        
        public EditionType EditionType { get; set; }


        [Required]
        public decimal Price { get; set; }

        [Required]
        public int Copies { get; set; }


        public DateTime? ReleaseDate { get; set; }
        
        public Author Author { get; set; }

        public ICollection<Category> Categories
        {
            get { return this.categories; }
            set { this.categories = value; }
        }

        public AgeRestriction AgeRestriction { get; set; }
    }
}
