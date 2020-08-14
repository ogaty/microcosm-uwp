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

        public ObservableCollection<UserEventData> userCollection { get; set; }

        public UserDbViewModel(UserEventData edata)
        {
            userCollection = new ObservableCollection<UserEventData>();
            userCollection.Add(edata);
        }

        public UserDbViewModel(UserData data)
        {
            int index = 0;
            userCollection = new ObservableCollection<UserEventData>();
            userCollection.Add(new UserEventData(data, index));

            foreach (UserEvent ev in data.userevent)
            {
                userCollection.Add(new UserEventData(ev, ++index));
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
