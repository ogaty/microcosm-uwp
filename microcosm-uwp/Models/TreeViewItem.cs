﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace microcosm.Models
{
    /// <summary>
    /// ユーザーDBディレクトリのバインド用
    /// </summary>
    public class TreeViewItem
    {
        public object Tag;
        public string Header;
        public List<object> Items;

        public TreeViewItem()
        {
        }
    }
}
