﻿#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license or other governing licenses that can be found in the LICENSE.md file or at
 * https://raw.githubusercontent.com/Krypton-Suite/Extended-Toolkit/master/LICENSE
 */
#endregion

namespace Krypton.Toolkit.Suite.Extended.Error.Reporting
{
    /// <summary>
    /// describes a query to SysInfo (more precisely, the Windows 'WMI' ManagementObjectSearcher)
    /// </summary>
    internal class SysInfoQuery
    {
        private readonly bool _useNameAsDisplayField;
        private readonly string _queryText;
        private readonly string _name;

        public SysInfoQuery(string name, string query, bool useNameAsDisplayField)
        {
            _useNameAsDisplayField = useNameAsDisplayField;
            _name = name;
            _queryText = query;
        }

        public string QueryText => _queryText;

        public string DisplayField => _useNameAsDisplayField ? "Name" : "Caption";

        public string Name => _name;
    }
}
