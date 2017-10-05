using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capstone.Models
{
  public class Campground
    {
        public int Campground_ID { get; set; }
        public int Park_ID { get; set; }
        public string Name { get; set; }
        public DateTime Open_From_MM { get; set; }
        public DateTime Open_To_MM { get; set; }
        public decimal Daily_Fee { get; set; } // convert money to decimal maybeeeeeee?
        
    }
}
