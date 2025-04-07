#region MIT License
/*
 * MIT License
 *
 * Copyright (c) 2017 - 2024 Krypton Suite
 *
 * Permission is hereby granted, free of charge, to any person obtaining a copy
 * of this software and associated documentation files (the "Software"), to deal
 * in the Software without restriction, including without limitation the rights
 * to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
 * copies of the Software, and to permit persons to whom the Software is
 * furnished to do so, subject to the following conditions:
 *
 * The above copyright notice and this permission notice shall be included in all
 * copies or substantial portions of the Software.
 *
 * THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
 * IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
 * FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
 * AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
 * LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
 * OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
 * SOFTWARE.
 *
 */
#endregion

namespace Krypton.Toolkit.Suite.Extended.Navi.Suite
{
    /// <summary>
    /// This class contains additional info about an add or remove operation
    /// For more information see <see cref="T:ChildControlCollection"/>
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
            get => m_item;
            set => m_item = value;
        }

        #endregion
    }

    public delegate void CollectionEventHandler(object? sender, ExtCollectionEventArgs e);
}