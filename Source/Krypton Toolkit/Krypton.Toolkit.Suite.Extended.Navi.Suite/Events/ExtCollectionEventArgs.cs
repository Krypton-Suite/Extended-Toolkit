#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license or other governing licenses that can be found in the LICENSE.md file or at
 * https://raw.githubusercontent.com/Krypton-Suite/Extended-Toolkit/master/LICENSE
 */
#endregion

namespace Krypton.Toolkit.Suite.Extended.Navi.Suite
{
    /// <summary>
    /// This class contains additional info about an add or remove operation
    /// For more information see <see cref="ChildControlCollection"/>
    /// </summary>
    public class ExtCollectionEventArgs : EventArgs
    {
        #region Fields

        private Object m_item;

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the CollectionEventArgs class
        /// </summary>
        public ExtCollectionEventArgs()
        {
        }

        /// <summary>
        /// Initializes a new instance of the CollectionEventArgs class
        /// </summary>
        /// <param name="item">Item which changed the collection</param>
        public ExtCollectionEventArgs(object item)
        {
            m_item = item;
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets the item which changed the collection
        /// </summary>
        public Object Item
        {
            get { return m_item; }
            set { m_item = value; }
        }

        #endregion
    }

    public delegate void CollectionEventHandler(object sender, ExtCollectionEventArgs e);
}