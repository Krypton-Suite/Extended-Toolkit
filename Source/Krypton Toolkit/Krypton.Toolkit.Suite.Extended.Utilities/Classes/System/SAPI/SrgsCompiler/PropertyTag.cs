#region MIT License
/*
 *
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

namespace Krypton.Toolkit.Suite.Extended.Utilities.System.SrgsCompiler
{
    internal sealed class PropertyTag : ParseElement, IPropertyTag, IElement
    {
        private CfgGrammar.CfgProperty _propInfo = new();

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