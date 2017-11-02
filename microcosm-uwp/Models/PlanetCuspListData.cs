using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace microcosm.Models
{
    /// <summary>
    /// 左下カスプリスト(天体)
    /// </summary>
    public class PlanetCuspListData : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public string name { get; set; }
        public string degree1 { get; set; }

        protected void OnPropertyChanged(string propertyname)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyname));
            }

        }

    }
}
