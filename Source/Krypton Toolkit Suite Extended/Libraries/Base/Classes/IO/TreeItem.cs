using System.Collections.Generic;
using System.Threading;

namespace Krypton.Toolkit.Suite.Extended.Base
{
    public class TreeItem
    {
        #region Properties
        /// <summary>Gets or sets the item data.</summary>
        /// <value>The item data.</value>
        public string ItemData { get; set; }

        /// <summary>Gets the parent item.</summary>
        /// <value>The parent item.</value>
        public TreeItem ParentItem { get; private set; }

        /// <summary>Gets the childs.</summary>
        /// <value>The childs.</value>
        public List<TreeItem> Childs { get; }

        /// <summary>Gets the count.</summary>
        /// <value>The count.</value>
        public static int Count => _count;
        #endregion

        #region Static
        private static int _count = 0;
        #endregion

        #region Constructor
        /// <summary>Initializes a new instance of the <see cref="TreeItem" /> class.</summary>
        /// <param name="data">The data.</param>
        /// <param name="parent">The parent.</param>
        public TreeItem(string data, TreeItem parent = null)
        {
            Interlocked.Increment(ref _count);

            ParentItem = parent;

            ItemData = data;

            Childs = new List<TreeItem>();
        }
        #endregion

        #region Methods
        /// <summary>Adds the child.</summary>
        /// <param name="child">The child.</param>
        public void AddChild(TreeItem child) => Childs.Add(child);
        #endregion
    }
}