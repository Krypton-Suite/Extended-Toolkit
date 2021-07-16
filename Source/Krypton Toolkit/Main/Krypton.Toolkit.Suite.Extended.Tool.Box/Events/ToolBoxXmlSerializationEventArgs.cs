#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license or other governing licenses that can be found in the LICENSE.md file or at
 * https://raw.githubusercontent.com/Krypton-Suite/Extended-Toolkit/master/LICENSE
 */
#endregion

using System;
using System.Xml;

namespace Krypton.Toolkit.Suite.Extended.Tool.Box
{
    public class ToolBoxXmlSerializationEventArgs : EventArgs
    {
        #region Private Attributes
        private bool _isLoading;
        private object _object;
        private XmlNode _xmlNode;
        #endregion //Private Attributes

        #region Properties
        public bool IsLoading
        {
            get { return _isLoading; }
        }

        public bool IsSaving
        {
            get { return !_isLoading; }
        }

        public XmlNode Node
        {
            get { return _xmlNode; }
        }

        public object Object
        {
            get { return _object; }
            set { _object = value; }
        }

        #endregion //Properties

        #region Construction
        public ToolBoxXmlSerializationEventArgs(object o, XmlNode node, bool isLoading)
        {
            _object = o;
            _xmlNode = node;
            _isLoading = isLoading;
        }
        #endregion //Construction

    }
}