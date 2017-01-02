using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentSystemModels
{
  public class Homework
    {
        [Key]
        public int Id { get; set; }

        public string Content { get; set; }
        public ContentType ContentType { get; set; }
        public DateTime SubmissionDate { get; set; }
        public virtual Student Student { get; set; }
        public Course Course { get; set; }
    }
}
