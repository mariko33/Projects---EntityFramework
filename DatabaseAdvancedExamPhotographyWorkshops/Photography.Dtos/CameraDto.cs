using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Photography.Dtos
{
   public class CameraDto
    {
        public string Type { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public int MinISO { get; set; }
        public bool IsFullFrameOrNot { get; set; }
        public int MaxISO { get; set; }
    }
}
