﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capstone.Models
{
   public class Park
    {
        public int Park_id { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public DateTime Establish_date { get; set; } //unsure if int or other thing that We dont know how to use
        public int Area { get; set; }
        public int Visitors { get; set; }
        public string Description { get; set; }
        
    }
}
