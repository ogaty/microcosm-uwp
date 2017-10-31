using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace microcosm.Models
{
    public class Calcuration
    {
        public List<PlanetData> planetData;
        public double[] cusps;
        public Calcuration(List<PlanetData> p, double[] c)
        {
            planetData = p;
            cusps = c;
        }
    }
}
