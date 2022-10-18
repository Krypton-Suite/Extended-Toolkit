#region MIT License
/*
 * MIT License
 *
 * Copyright (c) 2017 - 2023 Krypton Suite
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

using System.Collections;

namespace Krypton.Toolkit.Suite.Extended.Tool.Box
{
    [Serializable]
    public class ToolBoxTabCollection : CollectionBase
    {
        #region Constructor
        public ToolBoxTabCollection()
        {
        }
        #endregion //Constructor

        #region Properties
        public ToolBoxTab this[int index]
        {
            get => (ToolBoxTab)base.List[index];
            set => base.List[index] = value;
        }
        #endregion //Properties

        #region Public Methods
        public int Add(ToolBoxTab tab)
        {
            return base.InnerList.Add(tab);
        }

        public void Insert(int index, ToolBoxTab tab)
        {
            base.InnerList.Insert(index, tab);
        }

        public void Remove(ToolBoxTab tab)
        {
            base.InnerList.Remove(tab);
        }

        public int IndexOf(ToolBoxTab tab)
        {
            return base.InnerList.IndexOf(tab);
        }

        public bool Contains(ToolBoxTab tab)
        {
            return base.InnerList.Contains(tab);
        }

        #endregion //Public Methods
    }
}