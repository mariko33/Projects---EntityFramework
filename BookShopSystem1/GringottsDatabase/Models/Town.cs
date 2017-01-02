﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GringottsDatabase.Models
{
   public class Town
    {
        public Town()
        {
            
        }
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public string Country { get; set; }
    }
}
