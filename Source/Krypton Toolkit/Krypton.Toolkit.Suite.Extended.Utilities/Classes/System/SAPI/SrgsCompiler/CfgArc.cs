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

namespace Krypton.Toolkit.Suite.Extended.Utilities.System.SrgsCompiler;

internal struct CfgArc
{
    private uint _flag1;

    private uint _flag2;

    internal bool RuleRef
    {
        get => (_flag1 & 1) != 0;
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
        get => (_flag1 & 2) != 0;
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
        get => (_flag1 & 4) != 0;
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
        get => (_flag1 & 8) != 0;
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
        get => (_flag1 & 0x10) != 0;
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
        get => (_flag1 >> 5) & 0x3FFFFF;
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
        get => (_flag2 >> 8) & 0x3FFFFF;
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