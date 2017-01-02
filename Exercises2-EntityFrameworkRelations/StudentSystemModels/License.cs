using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentSystemModels
{
   public class License
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual Resource Resource  { get; set; }
    }
}
