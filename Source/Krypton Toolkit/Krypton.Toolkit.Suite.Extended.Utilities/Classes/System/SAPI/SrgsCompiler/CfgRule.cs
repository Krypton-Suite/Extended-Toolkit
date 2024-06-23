#region MIT License
/*
 *
 * MIT License
 *
 * Copyright (c) 2017 - 2024 Krypton Suite
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
    internal struct CfgRule
    {
        internal uint _flag;

        internal int _nameOffset;

        internal int _id;

        internal bool TopLevel
        {
            get => (_flag & 1) != 0;
            set
            {
                if (value)
                {
                    _flag |= 1u;
                }
                else
                {
                    _flag &= 4294967294u;
                }
            }
        }

        internal bool DefaultActive
        {
            set
            {
                if (value)
                {
                    _flag |= 2u;
                }
                else
                {
                    _flag &= 4294967293u;
                }
            }
        }

        internal bool PropRule
        {
            set
            {
                if (value)
                {
                    _flag |= 4u;
                }
                else
                {
                    _flag &= 4294967291u;
                }
            }
        }

        internal bool Import
        {
            get => (_flag & 8) != 0;
            set
            {
                if (value)
                {
                    _flag |= 8u;
                }
                else
                {
                    _flag &= 4294967287u;
                }
            }
        }

        internal bool Export
        {
            get => (_flag & 0x10) != 0;
            set
            {
                if (value)
                {
                    _flag |= 16u;
                }
                else
                {
                    _flag &= 4294967279u;
                }
            }
        }

        internal bool HasResources => (_flag & 0x20) != 0;

        internal bool Dynamic
        {
            get => (_flag & 0x40) != 0;
            set
            {
                if (value)
                {
                    _flag |= 64u;
                }
                else
                {
                    _flag &= 4294967231u;
                }
            }
        }

        internal bool HasDynamicRef
        {
            get => (_flag & 0x80) != 0;
            set
            {
                if (value)
                {
                    _flag |= 128u;
                }
                else
                {
                    _flag &= 4294967167u;
                }
            }
        }

        internal uint FirstArcIndex
        {
            get => (_flag >> 8) & 0x3FFFFF;
            set
            {
                if (value > 4194303)
                {
                    XmlParser.ThrowSrgsException(SRID.TooManyArcs);
                }
                _flag &= 3221225727u;
                _flag |= value << 8;
            }
        }

        internal bool DirtyRule
        {
            set
            {
                if (value)
                {
                    _flag |= 2147483648u;
                }
                else
                {
                    _flag &= 2147483647u;
                }
            }
        }

        internal CfgRule(int id, int nameOffset, uint flag)
        {
            _flag = flag;
            _nameOffset = nameOffset;
            _id = id;
        }

        internal CfgRule(int id, int nameOffset, SPCFGRULEATTRIBUTES attributes)
        {
            _flag = 0u;
            _nameOffset = nameOffset;
            _id = id;
            TopLevel = (attributes & SPCFGRULEATTRIBUTES.SPRAF_TopLevel) != 0;
            DefaultActive = (attributes & SPCFGRULEATTRIBUTES.SPRAF_Active) != 0;
            PropRule = (attributes & SPCFGRULEATTRIBUTES.SPRAF_Interpreter) != 0;
            Export = (attributes & SPCFGRULEATTRIBUTES.SPRAF_Export) != 0;
            Dynamic = (attributes & SPCFGRULEATTRIBUTES.SPRAF_Dynamic) != 0;
            Import = (attributes & SPCFGRULEATTRIBUTES.SPRAF_Import) != 0;
        }
    }
}