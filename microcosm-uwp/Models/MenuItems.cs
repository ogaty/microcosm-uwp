using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace microcosm.Models
{
    public class MenuItems
    {
        public string text { get; set; }
        public FontAwesome.UWP.FontAwesomeIcon icon { get; set; }
        public Type PageType { get; set; }
    }
}
