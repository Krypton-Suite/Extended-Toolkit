using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Krypton.Toolkit.Extended.Core
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