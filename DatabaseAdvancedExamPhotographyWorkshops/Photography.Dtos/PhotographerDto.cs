
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Photography.Models.Attributes;

namespace Photography.Dtos
{
  public class PhotographerDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        [Phone]
        public string Phone { get; set; }
        public int[]Lenses { get; set; }
    }
}
