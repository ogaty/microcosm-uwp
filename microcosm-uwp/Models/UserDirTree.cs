using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace microcosm.Models
{
    public class UserDirTree
    {
        public TreeViewItem CreateDirectoryNode(DirectoryInfo directoryInfo)
        {
            if (!Directory.Exists(directoryInfo.FullName))
            {
                Directory.CreateDirectory(directoryInfo.FullName);
            }

            var directoryNode = new TreeViewItem { Header = directoryInfo.Name };

            foreach (var directory in directoryInfo.GetDirectories())
            {
                // ディレクトリ
                TreeViewItem item = CreateDirectoryNode(directory);
                item.Tag = new DbItem
                {
                    fileName = directory.FullName,
                    isDir = true
                };
                directoryNode.Items.Add(item);
            }
            if (directoryNode.Items.Count == 0)
            {
                Console.WriteLine("No Dirs");
            }

            foreach (var file in directoryInfo.GetFiles())
            {
                // ファイル
                string trimName = System.IO.Path.GetFileNameWithoutExtension(file.Name);
                TreeViewItem item = new TreeViewItem { Header = trimName };
                item.Tag = new DbItem
                {
                    fileName = file.FullName,
                    isDir = false
                };
                directoryNode.Items.Add(item);
            }

            return directoryNode;
        }

    }
}
