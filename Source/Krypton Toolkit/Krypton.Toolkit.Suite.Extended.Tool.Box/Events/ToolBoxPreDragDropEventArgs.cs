#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license or other governing licenses that can be found in the LICENSE.md file or at
 * https://raw.githubusercontent.com/Krypton-Suite/Extended-Toolkit/master/LICENSE
 */
#endregion

using System;
using System.Windows.Forms;

namespace Krypton.Toolkit.Suite.Extended.Tool.Box
{
    public class ToolBoxPreDragDropEventArgs : EventArgs
    {
        #region Private Attributes
        private DataObject _dataObject;
        private object _object;
        #endregion //Private Attributes

        #region Properties

        public DataObject DataObject
        {
            get { return _dataObject; }
        }

        public object DragObject
        {
            get { return _object; }
        }

        #endregion //Properties
        #region Construction
        public ToolBoxPreDragDropEventArgs(DataObject d, object o)
        {
            _dataObject = d;
            _object = o;
        }
        #endregion //Construction
    }
}