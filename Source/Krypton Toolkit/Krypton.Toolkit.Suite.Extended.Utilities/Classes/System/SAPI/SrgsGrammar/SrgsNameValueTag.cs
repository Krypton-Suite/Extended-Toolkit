#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license or other governing licenses that can be found in the LICENSE.md file or at
 * https://raw.githubusercontent.com/Krypton-Suite/Extended-Toolkit/master/LICENSE
 */
#endregion

using Krypton.Toolkit.Suite.Extended.Utilities.System.Internal;
using Krypton.Toolkit.Suite.Extended.Utilities.System.SrgsParser;
using Krypton.Toolkit.Suite.Extended.Utilities.SystemInternal.Speech;

namespace Krypton.Toolkit.Suite.Extended.Utilities.System.SrgsGrammar
{
    [Serializable]
    [DebuggerDisplay("{DebuggerDisplayString ()}")]
    public class SrgsNameValueTag : SrgsElement, IPropertyTag, IElement
    {
        private string _name;

        private object _value;

        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                _name = GetTrimmedName(value, "value");
            }
        }

        public object Value
        {
            get
            {
                return _value;
            }
            set
            {
                Helpers.ThrowIfNull(value, "value");
                if (value is string || value is bool || value is int || value is double)
                {
                    _value = value;
                    return;
                }
                throw new ArgumentException(SR.Get(SRID.InvalidValueType), "value");
            }
        }

        public SrgsNameValueTag()
        {
        }

        public SrgsNameValueTag(object value)
        {
            Helpers.ThrowIfNull(value, "value");
            Value = value;
        }

        public SrgsNameValueTag(string name, object value)
            : this(value)
        {
            _name = GetTrimmedName(name, "name");
        }

        internal override void WriteSrgs(XmlWriter writer)
        {
            bool flag = Value != null;
            bool flag2 = !string.IsNullOrEmpty(_name);
            writer.WriteStartElement("tag");
            StringBuilder stringBuilder = new StringBuilder();
            if (flag2)
            {
                stringBuilder.Append(_name);
                stringBuilder.Append("=");
            }
            if (flag)
            {
                if (Value is string)
                {
                    stringBuilder.AppendFormat(CultureInfo.InvariantCulture, "\"{0}\"", new object[1]
                    {
                        Value.ToString()
                    });
                }
                else
                {
                    stringBuilder.Append(Value.ToString());
                }
            }
            writer.WriteString(stringBuilder.ToString());
            writer.WriteEndElement();
        }

        internal override void Validate(SrgsGrammar grammar)
        {
            switch (grammar.TagFormat)
            {
                case SrgsTagFormat.KeyValuePairs:
                    break;
                case SrgsTagFormat.Default:
                    grammar.TagFormat |= SrgsTagFormat.KeyValuePairs;
                    break;
                default:
                    XmlParser.ThrowSrgsException(SRID.SapiPropertiesAndSemantics);
                    break;
            }
        }

        void IPropertyTag.NameValue(IElement parent, string name, object value)
        {
            _name = name;
            _value = value;
        }

        internal override string DebuggerDisplayString()
        {
            StringBuilder stringBuilder = new StringBuilder("SrgsNameValue ");
            if (_name != null)
            {
                stringBuilder.Append(_name);
                stringBuilder.Append(" (");
            }
            if (_value != null)
            {
                if (_value is string)
                {
                    stringBuilder.AppendFormat(CultureInfo.InvariantCulture, "\"{0}\"", new object[1]
                    {
                        _value.ToString()
                    });
                }
                else
                {
                    stringBuilder.Append(_value.ToString());
                }
            }
            else
            {
                stringBuilder.Append("null");
            }
            if (_name != null)
            {
                stringBuilder.Append(")");
            }
            return stringBuilder.ToString();
        }

        private static string GetTrimmedName(string name, string parameterName)
        {
            Helpers.ThrowIfEmptyOrNull(name, parameterName);
            name = name.Trim(Helpers._achTrimChars);
            Helpers.ThrowIfEmptyOrNull(name, parameterName);
            return name;
        }
    }
}
