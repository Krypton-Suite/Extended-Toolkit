using System.Collections.Generic;
using System.Threading;

namespace Krypton.Toolkit.Suite.Extended.Base
{
    public class TreeItem
    {
        #region Properties
        public string ItemData { get; set; }

        public TreeItem ParentItem { get; private set; }

        public List<TreeItem> Childs { get; }

        public static int Count => _count;
        #endregion

        #region Static
        private static int _count = 0;
        #endregion

        #region Constructor
        public TreeItem(string data, TreeItem parent = null)
        {
            Interlocked.Increment(ref _count);

            ParentItem = parent;

            ItemData = data;

            Childs = new List<TreeItem>();
        }
        #endregion

        #region Methods
        public void AddChild(TreeItem child) => Childs.Add(child);
        #endregion
    }
}