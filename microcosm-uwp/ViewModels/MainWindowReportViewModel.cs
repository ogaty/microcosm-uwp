using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace microcosm.ViewModels
{
    class MainWindowReportViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public string houseDown { get; set; }
        public string houseRight { get; set; }
        public string houseUp { get; set; }
        public string houseLeft { get; set; }

        public string signFire { get; set; }
        public string signEarth { get; set; }
        public string signAir { get; set; }
        public string signWater { get; set; }

        public string signCardinal { get; set; }
        public string signFixed { get; set; }
        public string signMutable { get; set; }

        public string houseAngular { get; set; }
        public string houseCadent { get; set; }
        public string houseSuccedent { get; set; }

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
