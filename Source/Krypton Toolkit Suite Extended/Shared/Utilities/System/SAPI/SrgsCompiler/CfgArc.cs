#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license or other governing licenses that can be found in the LICENSE.md file or at
 * https://raw.githubusercontent.com/Krypton-Suite/Extended-Toolkit/master/LICENSE
 */
#endregion

using Krypton.Toolkit.Suite.Extended.Utilities.System.SrgsParser;
using Krypton.Toolkit.Suite.Extended.Utilities.SystemInternal.Speech;

namespace Krypton.Toolkit.Suite.Extended.Utilities.System.SrgsCompiler
{
    internal struct CfgArc
    {
        private uint _flag1;

        private uint _flag2;

        internal bool RuleRef
        {
            get
            {
                return (_flag1 & 1) != 0;
            }
            set
            {
                if (value)
                {
                    _flag1 |= 1u;
                }
                else
                {
                    _flag1 &= 4294967294u;
                }
            }
        }

        internal bool LastArc
        {
            get
            {
                return (_flag1 & 2) != 0;
            }
            set
            {
                if (value)
                {
                    _flag1 |= 2u;
                }
                else
                {
                    _flag1 &= 4294967293u;
                }
            }
        }

        internal bool HasSemanticTag
        {
            get
            {
                return (_flag1 & 4) != 0;
            }
            set
            {
                if (value)
                {
                    _flag1 |= 4u;
                }
                else
                {
                    _flag1 &= 4294967291u;
                }
            }
        }

        internal bool LowConfRequired
        {
            get
            {
                return (_flag1 & 8) != 0;
            }
            set
            {
                if (value)
                {
                    _flag1 |= 8u;
                }
                else
                {
                    _flag1 &= 4294967287u;
                }
            }
        }

        internal bool HighConfRequired
        {
            get
            {
                return (_flag1 & 0x10) != 0;
            }
            set
            {
                if (value)
                {
                    _flag1 |= 16u;
                }
                else
                {
                    _flag1 &= 4294967279u;
                }
            }
        }

        internal uint TransitionIndex
        {
            get
            {
                return (_flag1 >> 5) & 0x3FFFFF;
            }
            set
            {
                if (value > 4194303)
                {
                    XmlParser.ThrowSrgsException(SRID.TooManyArcs);
                }
                _flag1 &= 4160749599u;
                _flag1 |= value << 5;
            }
        }

        internal uint MatchMode
        {
            set
            {
                _flag1 &= 3355443199u;
                _flag1 |= value << 27;
            }
        }

        internal uint NextStartArcIndex
        {
            get
            {
                return (_flag2 >> 8) & 0x3FFFFF;
            }
            set
            {
                if (value > 4194303)
                {
                    XmlParser.ThrowSrgsException(SRID.TooManyArcs);
                }
                _flag2 &= 3221225727u;
                _flag2 |= value << 8;
            }
        }

        internal CfgArc(CfgArc arc)
        {
            _flag1 = arc._flag1;
            _flag2 = arc._flag2;
        }
    }
}