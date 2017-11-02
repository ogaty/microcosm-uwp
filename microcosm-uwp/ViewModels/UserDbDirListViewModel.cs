using microcosm.Models;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace microcosm.ViewModels
{
    public class UserDbDirListViewModel : INotifyCollectionChanged
    {
        public event NotifyCollectionChangedEventHandler CollectionChanged;

        public TreeViewItem dirTree { get; set; }
        public List<TreeViewItem2> DirTree2 { get; set; }

        protected void OnCollectionChanged(NotifyCollectionChangedAction action, TreeViewItem2 b, int index)
        {

            NotifyCollectionChangedEventHandler

                        handler = CollectionChanged;

            if (handler != null)

                handler(this,

                        new NotifyCollectionChangedEventArgs(action,

                                                         b, index));

        }
    }
}
