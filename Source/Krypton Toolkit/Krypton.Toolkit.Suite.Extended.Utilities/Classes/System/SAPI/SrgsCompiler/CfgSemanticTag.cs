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

namespace Krypton.Toolkit.Suite.Extended.Utilities.System.SrgsCompiler
{
    [StructLayout(LayoutKind.Explicit)]
    internal struct CfgSemanticTag
    {
        [FieldOffset(0)]
        private uint _flag1;

        [FieldOffset(4)]
        private uint _flag2;

        [FieldOffset(8)]
        private uint _flag3;

        [FieldOffset(12)]
        internal int _nameOffset;

        [FieldOffset(16)]
        internal uint _propId;

        [FieldOffset(20)]
        internal int _valueOffset;

        [FieldOffset(24)]
        internal int _varInt;

        [FieldOffset(24)]
        internal double _varDouble;

        internal uint StartArcIndex
        {
            get
            {
                return _flag1 & 0x3FFFFF;
            }
            set
            {
                if (value > 4194303)
                {
                    XmlParser.ThrowSrgsException(SRID.TooManyArcs);
                }
                _flag1 &= 4290772992u;
                _flag1 |= value;
            }
        }

        internal bool StartParallelEpsilonArc
        {
            get
            {
                return (_flag1 & 0x400000) != 0;
            }
            set
            {
                if (value)
                {
                    _flag1 |= 4194304u;
                }
                else
                {
                    _flag1 &= 4290772991u;
                }
            }
        }

        internal uint EndArcIndex
        {
            get
            {
                return _flag2 & 0x3FFFFF;
            }
            set
            {
                if (value > 4194303)
                {
                    XmlParser.ThrowSrgsException(SRID.TooManyArcs);
                }
                _flag2 &= 4290772992u;
                _flag2 |= value;
            }
        }

        internal bool EndParallelEpsilonArc
        {
            get
            {
                return (_flag2 & 0x400000) != 0;
            }
            set
            {
                if (value)
                {
                    _flag2 |= 4194304u;
                }
                else
                {
                    _flag2 &= 4290772991u;
                }
            }
        }

        internal VarEnum PropVariantType
        {
            get
            {
                return (VarEnum)(_flag3 & 0xFF);
            }
            set
            {
                if ((uint)value > 255u)
                {
                    XmlParser.ThrowSrgsException(SRID.TooManyArcs);
                }
                _flag3 &= 4294967040u;
                _flag3 |= (uint)value;
            }
        }

        internal uint ArcIndex
        {
            get
            {
                return (_flag3 >> 8) & 0x3FFFFF;
            }
            set
            {
                if (value > 4194303)
                {
                    XmlParser.ThrowSrgsException(SRID.TooManyArcs);
                }
                _flag3 &= 3221225727u;
                _flag3 |= value << 8;
            }
        }

        internal CfgSemanticTag(CfgSemanticTag cfgTag)
        {
            _flag1 = cfgTag._flag1;
            _flag2 = cfgTag._flag2;
            _flag3 = cfgTag._flag3;
            _propId = cfgTag._propId;
            _nameOffset = cfgTag._nameOffset;
            _varInt = 0;
            _valueOffset = cfgTag._valueOffset;
            _varDouble = cfgTag._varDouble;
            StartArcIndex = 4194303u;
        }

        internal CfgSemanticTag(StringBlob symbols, CfgGrammar.CfgProperty property)
        {
            _flag1 = (_flag2 = (_flag3 = 0u));
            _valueOffset = 0;
            _varInt = 0;
            _varDouble = 0.0;
            _propId = property._ulId;
            int idWord;
            if (property._pszName != null)
            {
                _nameOffset = symbols.Add(property._pszName, out idWord);
            }
            else
            {
                _nameOffset = 0;
            }
            switch (property._comType)
            {
                case VarEnum.VT_EMPTY:
                case VarEnum.VT_BSTR:
                    if (property._comValue != null)
                    {
                        _valueOffset = symbols.Add((string)property._comValue, out idWord);
                    }
                    else
                    {
                        _valueOffset = 0;
                    }
                    break;
                case VarEnum.VT_I4:
                    _varInt = (int)property._comValue;
                    break;
                case VarEnum.VT_BOOL:
                    _varInt = (((bool)property._comValue) ? 65535 : 0);
                    break;
                case VarEnum.VT_R8:
                    _varDouble = (double)property._comValue;
                    break;
            }
            PropVariantType = property._comType;
            ArcIndex = 0u;
        }
    }
}