using Windows.UI.Xaml.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace microcosm.Views
{
    public class MenuItem
    {
        public Symbol Icon { get; set; }
        public string Name { get; set; }
        public Type PageType { get; set; }

        public static List<MenuItem> GetMainItems()
        {
            var items = new List<MenuItem>();
            items.Add(new MenuItem() { Icon = Symbol.Accept, Name = "MenuItem1", PageType = typeof(Views.DatabasePage) });
            items.Add(new MenuItem() { Icon = Symbol.Send, Name = "MenuItem2", PageType = typeof(Views.DatabasePage) });
            items.Add(new MenuItem() { Icon = Symbol.Shop, Name = "MenuItem3", PageType = typeof(Views.DatabasePage) });
            return items;
        }

        public static List<MenuItem> GetOptionsItems()
        {
            var items = new List<MenuItem>();
            items.Add(new MenuItem() { Icon = Symbol.Setting, Name = "OptionItem1", PageType = typeof(Views.DatabasePage) });
            return items;
        }
    }
}
