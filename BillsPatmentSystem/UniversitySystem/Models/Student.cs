using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniversitySystem.Models
{
  public class Student:People
  {
      private ICollection<Course> courses;

      public Student()
      {
          this.courses=new HashSet<Course>();
      }
        public double AverageGrade { get; set; }
        public int Attendance { get; set; }

      public virtual ICollection<Course> Courses
      {
          get { return this.courses; }
            set { this.courses = value; }
          
      }
    }
}
