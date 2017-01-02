using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace StudentSystemModels
{
   public class Course
   {
       private ICollection<Resource> resources;
       private ICollection<Homework> homeworks;
       private ICollection<Student> students;
        public Course()
        {
            this.resources = new HashSet<Resource>();
            this.homeworks=new HashSet<Homework>();
            this.students=new HashSet<Student>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public string Description { get; set; }

        [Required]
        public DateTime StartDate { get; set; }

        [Required]
        public DateTime EndDate { get; set; }

        [Required]
        public decimal Price { get; set; }

        public virtual ICollection<Resource>Resources
        {
            get { return this.resources; }
            set { this.resources = value; }
        }

       public ICollection<Homework> Homeworks
        {
            get { return this.homeworks; }

            set { this.homeworks = value; }
        }
       public ICollection<Student> Students
        {
            get { return this.students; }
            set { this.students = value; }
        }
    }
}
