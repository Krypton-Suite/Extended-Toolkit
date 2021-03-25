﻿#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license or other governing licenses that can be found in the LICENSE.md file or at
 * https://raw.githubusercontent.com/Krypton-Suite/Extended-Toolkit/master/LICENSE
 */

// Original license

/**
* THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY
* KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE
* IMPLIED WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR
* PURPOSE.
*
* License: GNU Lesser General Public License (LGPLv3)
*
* Email: pavel_torgashov@ukr.net.
*
* Copyright (C) Pavel Torgashov, 2011-2016.
*/
#endregion

using System;

namespace Krypton.Toolkit.Suite.Extended.Fast.Coloured.Text.Box
{
    /// <summary>
    /// Line index and char index
    /// </summary>
    public struct Place : IEquatable<Place>
    {
        public int iChar;
        public int iLine;

        public Place(int iChar, int iLine)
        {
            this.iChar = iChar;
            this.iLine = iLine;
        }

        public void Offset(int dx, int dy)
        {
            iChar += dx;
            iLine += dy;
        }

        public bool Equals(Place other)
        {
            return iChar == other.iChar && iLine == other.iLine;
        }

        public override bool Equals(object obj)
        {
            return (obj is Place) && Equals((Place)obj);
        }

        public override int GetHashCode()
        {
            return iChar.GetHashCode() ^ iLine.GetHashCode();
        }

        public static bool operator !=(Place p1, Place p2)
        {
            return !p1.Equals(p2);
        }

        public static bool operator ==(Place p1, Place p2)
        {
            return p1.Equals(p2);
        }

        public static bool operator <(Place p1, Place p2)
        {
            if (p1.iLine < p2.iLine) return true;
            if (p1.iLine > p2.iLine) return false;
            if (p1.iChar < p2.iChar) return true;
            return false;
        }

        public static bool operator <=(Place p1, Place p2)
        {
            if (p1.Equals(p2)) return true;
            if (p1.iLine < p2.iLine) return true;
            if (p1.iLine > p2.iLine) return false;
            if (p1.iChar < p2.iChar) return true;
            return false;
        }

        public static bool operator >(Place p1, Place p2)
        {
            if (p1.iLine > p2.iLine) return true;
            if (p1.iLine < p2.iLine) return false;
            if (p1.iChar > p2.iChar) return true;
            return false;
        }

        public static bool operator >=(Place p1, Place p2)
        {
            if (p1.Equals(p2)) return true;
            if (p1.iLine > p2.iLine) return true;
            if (p1.iLine < p2.iLine) return false;
            if (p1.iChar > p2.iChar) return true;
            return false;
        }

        public static Place operator +(Place p1, Place p2)
        {
            return new Place(p1.iChar + p2.iChar, p1.iLine + p2.iLine);
        }

        public static Place Empty
        {
            get { return new Place(); }
        }

        public override string ToString()
        {
            return "(" + iChar + "," + iLine + ")";
        }
    }
}