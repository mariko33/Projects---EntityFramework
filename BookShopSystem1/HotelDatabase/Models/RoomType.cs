using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelDatabase.Models
{
  public class RoomType
    {
        public RoomType()
        {
            
        }
        [Key]
        public int Id { get; set; }
        public string Type { get; set; }

        public string Notes { get; set; }
    }
}
