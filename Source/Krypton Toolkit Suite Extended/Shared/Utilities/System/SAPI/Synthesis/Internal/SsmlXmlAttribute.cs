#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license or other governing licenses that can be found in the LICENSE.md file or at
 * https://raw.githubusercontent.com/Krypton-Suite/Extended-Toolkit/master/LICENSE
 */
#endregion

namespace Krypton.Toolkit.Suite.Extended.Utilities.System.Synthesis
{
    internal class SsmlXmlAttribute
    {
        internal string _prefix;

        internal string _name;

        internal string _value;

        internal string _ns;

        internal SsmlXmlAttribute(string prefix, string name, string value, string ns)
        {
            _prefix = prefix;
            _name = name;
            _value = value;
            _ns = ns;
        }
    }
}