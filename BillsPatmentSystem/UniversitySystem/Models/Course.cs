﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniversitySystem.Models
{
   public class Course
   {
       private ICollection<Student> students;

       public Course()
       {
           this.students=new HashSet<Student>();
       }
        public int Id { get; set; }
        public string NameDescription { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int Credits { get; set; }

       public virtual ICollection<Student> Students
       {
            get { return this.students; }
            set { this.students = value; }
           
       }
    }
}
