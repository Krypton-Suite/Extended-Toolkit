#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license or other governing licenses that can be found in the LICENSE.md file or at
 * https://raw.githubusercontent.com/Krypton-Suite/Extended-Toolkit/master/LICENSE
 */
#endregion

using Krypton.Toolkit.Suite.Extended.Utilities.System.SrgsParser;

namespace Krypton.Toolkit.Suite.Extended.Utilities.System.SrgsCompiler
{
    internal sealed class PropertyTag : ParseElement, IPropertyTag, IElement
    {
        private CfgGrammar.CfgProperty _propInfo = new CfgGrammar.CfgProperty();

        internal PropertyTag(ParseElement parent, Backend backend)
            : base(parent._rule)
        {
        }

        void IPropertyTag.NameValue(IElement parent, string name, object value)
        {
            string text = value as string;
            if (!string.IsNullOrEmpty(name) || (value != null && (text == null || !string.IsNullOrEmpty(text.Trim()))))
            {
                if (!string.IsNullOrEmpty(name))
                {
                    _propInfo._pszName = name;
                }
                else
                {
                    _propInfo._pszName = "=";
                }
                _propInfo._comValue = value;
                if (value == null)
                {
                    _propInfo._comType = VarEnum.VT_EMPTY;
                }
                else if (text != null)
                {
                    _propInfo._comType = VarEnum.VT_EMPTY;
                }
                else if (value is int)
                {
                    _propInfo._comType = VarEnum.VT_I4;
                }
                else if (value is double)
                {
                    _propInfo._comType = VarEnum.VT_R8;
                }
                else if (value is bool)
                {
                    _propInfo._comType = VarEnum.VT_BOOL;
                }
            }
        }

        void IElement.PostParse(IElement parentElement)
        {
            ParseElementCollection parseElementCollection = (ParseElementCollection)parentElement;
            _propInfo._ulId = (uint)parseElementCollection._rule._iSerialize2;
            parseElementCollection.AddSementicPropertyTag(_propInfo);
        }
    }
}