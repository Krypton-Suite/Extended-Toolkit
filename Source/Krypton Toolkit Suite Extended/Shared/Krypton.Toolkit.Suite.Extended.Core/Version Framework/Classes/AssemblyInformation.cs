#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license or other governing licenses that can be found in the LICENSE.md file or at
 * https://raw.githubusercontent.com/Krypton-Suite/Extended-Toolkit/master/LICENSE
 */
#endregion

namespace Krypton.Toolkit.Suite.Extended.Core
{
    public class AssemblyInformation
    {
        #region Variables
        private string _name, _version, _fullName;
        #endregion

        #region Properties
        public string Name { get { return _name; } set { _name = value; } }

        public string Version { get { return _version; } set { _version = value; } }

        public string FullName { get { return _fullName; } set { _fullName = value; } }
        #endregion
    }
}