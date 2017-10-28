using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace microcosm.Models
{
    public class PlanetData
    {
        public int no { get; set; }
        public double absolute_position { get; set; }
        public double degree {
            get { return absolute_position % 30; }
        }
        public int sign
        {
            get { return (int)(Math.Floor(absolute_position / 30)); }
        }
    }
}
