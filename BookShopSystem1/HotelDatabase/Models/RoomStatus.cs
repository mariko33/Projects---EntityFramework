using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelDatabase.Models
{
   public class RoomStatus
    {
        public RoomStatus()
        {
            
        }
        [Key]
        public int Id { get; set; }

        public Status Status { get; set; }
        public string Notes { get; set; }
    }
}
