using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShopSystem.Models
{
    public class Book
    {

        private ICollection<Category> categories;
        private ICollection<Book> relatedBooks;
        public Book()
        {
            this.categories=new HashSet<Category>();
            this.relatedBooks=new HashSet<Book>();
        }

        public int Id { get; set; }
        [MaxLength(50),MinLength(1)]
        public string Title { get; set; }

        [MaxLength(1000)]
        public string Description { get; set; }

        public EditionType EditionType { get; set; }
        public decimal Price { get; set; }
        public int Copies { get; set; }
        public DateTime ReleaseDate { get; set; }
        public Author Author { get; set; }

        public virtual ICollection<Category> Categories
        {
            get { return this.categories; }
            set { this.categories = value; }
            
        }

        public AgeRestriction AgeRestriction { get; set; }

        public virtual ICollection<Book> RelatedBooks
        {
            get { return this.relatedBooks; }
            set { this.relatedBooks = value; }
            
        }
    }
}
