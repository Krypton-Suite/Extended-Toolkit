#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license or other governing licenses that can be found in the LICENSE.md file or at
 * https://raw.githubusercontent.com/Krypton-Suite/Extended-Toolkit/master/LICENSE
 */
#endregion

using System;

namespace Krypton.Toolkit.Suite.Extended.Tool.Box
{
    public class ToolBoxRenameFinishedEventArgs : EventArgs
    {
        #region Private Attributes
        private string _newCaption;
        private bool _cancel;
        private bool _continueRenaming;
        private bool _escapeKeyPressed;
        #endregion //Private Attributes

        #region Properties
        public string NewCaption
        {
            get { return _newCaption; }
        }

        public bool Cancel
        {
            get { return _cancel; }
            set { _cancel = value; }
        }

        public bool ContinueRenaming
        {
            get { return _continueRenaming; }
            set { _continueRenaming = value; }
        }

        public bool EscapeKeyPressed
        {
            get { return _escapeKeyPressed; }
        }

        #endregion //Properties

        #region Construction
        public ToolBoxRenameFinishedEventArgs(string newCaption, bool escapeKeyPressed)
        {
            _newCaption = newCaption;
            _escapeKeyPressed = escapeKeyPressed;
        }
        #endregion //Construction
    }
}