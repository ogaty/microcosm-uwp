using microcosm.Models;
using microcosm.User;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace microcosm.ViewModels
{
    public class UserDbViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public ObservableCollection<UserEventData> userData { get; set; }

        public UserDbViewModel(UserEventData edata)
        {
            userData = new ObservableCollection<UserEventData>();
            userData.Add(edata);
        }

        public UserDbViewModel(UserData data)
        {
            userData = new ObservableCollection<UserEventData>();
            userData.Add(new UserEventData(data));

            foreach (UserEvent ev in data.userevent)
            {
                userData.Add(new UserEventData(ev));
            }
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
