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
            User1Name = CommonInstance.getInstance().udata1.name;
            User1DateStr = Util.DateTimeToString(CommonInstance.getInstance().udata1.birth_time, CommonInstance.getInstance().udata1.timezone);
            Event1Name = CommonInstance.getInstance().edata1.name;
            Event1DateStr = Util.DateTimeToString(CommonInstance.getInstance().edata1.birth_time, CommonInstance.getInstance().edata1.timezone);
            User2Name = CommonInstance.getInstance().udata2.name;
            User2DateStr = Util.DateTimeToString(CommonInstance.getInstance().udata2.birth_time, CommonInstance.getInstance().udata2.timezone);
            Event2Name = CommonInstance.getInstance().edata2.name;
            Event2DateStr = Util.DateTimeToString(CommonInstance.getInstance().edata2.birth_time, CommonInstance.getInstance().edata2.timezone);
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

        private string _User2Name;
        public string User2Name
        {
            get
            {
                return _User2Name;
            }
            set
            {
                _User2Name = value;
                OnPropertyChanged("User2Name");
            }
        }

        private string _User2DateStr;
        public string User2DateStr
        {
            get
            {
                return _User2DateStr;
            }
            set
            {
                _User2DateStr = value;
                OnPropertyChanged("User2DateStr");
            }
        }

        private string _Event1Name;
        public string Event1Name
        {
            get
            {
                return _Event1Name;
            }
            set
            {
                _Event1Name = value;
                OnPropertyChanged("Event1Name");
            }
        }

        private string _Event1DateStr;
        public string Event1DateStr
        {
            get
            {
                return _Event1DateStr;
            }
            set
            {
                _Event1DateStr = value;
                OnPropertyChanged("Event1DateStr");
            }
        }

        private string _Event2Name;
        public string Event2Name
        {
            get
            {
                return _Event2Name;
            }
            set
            {
                _Event2Name = value;
                OnPropertyChanged("Event2Name");
            }
        }

        private string _Event2DateStr;
        public string Event2DateStr
        {
            get
            {
                return _Event2DateStr;
            }
            set
            {
                _Event2DateStr = value;
                OnPropertyChanged("Event2DateStr");
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
