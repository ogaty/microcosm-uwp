using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using microcosm.Common;
using microcosm.User;

namespace microcosm.ViewModels
{
    public class MainWindowUserDataViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public MainWindowUserDataViewModel()
        {
            User1Name = "現在時刻";
            User1DateStr = Util.DateTimeToString(DateTime.Now, "JST");
        }

        private string _User1Name;
        public string User1Name
        {
            get
            {
                return _User1Name;
            }
            set
            {
                _User1Name = value;
                OnPropertyChanged("User1Name");
            }
        }

        private string _User1DateStr;
        public string User1DateStr
        {
            get
            {
                return _User1DateStr;
            }
            set
            {
                _User1DateStr = value;
                OnPropertyChanged("User1DateStr");
            }
        }

        public void SetUserData(UserData user)
        {

        }

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
