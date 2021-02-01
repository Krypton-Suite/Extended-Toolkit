#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license or other governing licenses that can be found in the LICENSE.md file or at
 * https://raw.githubusercontent.com/Krypton-Suite/Extended-Toolkit/master/LICENSE
 */
#endregion

using System.Runtime.InteropServices;

namespace Krypton.Toolkit.Suite.Extended.Wizard
{
    internal static partial class NativeMethods
    {
        [StructLayout(LayoutKind.Sequential)]
        public struct RECT
        {
            public int Left, Top, Right, Bottom;

            public RECT(int left, int top, int right, int bottom)
            {
                Left = left;
                Top = top;
                Right = right;
                Bottom = bottom;
            }

            public RECT(System.Drawing.Rectangle r)
                : this(r.Left, r.Top, r.Right, r.Bottom)
            {
            }

            public int X
            {
                get { return Left; }
                set { Right -= (Left - value); Left = value; }
            }

            public int Y
            {
                get { return Top; }
                set { Bottom -= (Top - value); Top = value; }
            }

            public int Height
            {
                get { return Bottom - Top; }
                set { Bottom = value + Top; }
            }

            public int Width
            {
                get { return Right - Left; }
                set { Right = value + Left; }
            }

            public System.Drawing.Point Location
            {
                get { return new System.Drawing.Point(Left, Top); }
                set { X = value.X; Y = value.Y; }
            }

            public System.Drawing.Size Size
            {
                get { return new System.Drawing.Size(Width, Height); }
                set { Width = value.Width; Height = value.Height; }
            }

            public static implicit operator System.Drawing.Rectangle(RECT r) => new System.Drawing.Rectangle(r.Left, r.Top, r.Width, r.Height);

            public static implicit operator RECT(System.Drawing.Rectangle r) => new RECT(r);

            public static bool operator ==(RECT r1, RECT r2) => r1.Equals(r2);

            public static bool operator !=(RECT r1, RECT r2) => !r1.Equals(r2);

            public bool Equals(RECT r) => r.Left == Left && r.Top == Top && r.Right == Right && r.Bottom == Bottom;

            public override bool Equals(object obj)
            {
                if (obj is RECT)
                    return Equals((RECT)obj);
                else if (obj is System.Drawing.Rectangle)
                    return Equals(new RECT((System.Drawing.Rectangle)obj));
                return false;
            }

            public override int GetHashCode() => ((System.Drawing.Rectangle)this).GetHashCode();

            public override string ToString() => $"{{Left={Left},Top={Top},Right={Right},Bottom={Bottom}}}";
        }

        [StructLayout(LayoutKind.Sequential)]
        public class PRECT
        {
            public int Left, Top, Right, Bottom;

            public PRECT(int left, int top, int right, int bottom)
            {
                Left = left;
                Top = top;
                Right = right;
                Bottom = bottom;
            }

            public PRECT(System.Drawing.Rectangle r)
                : this(r.Left, r.Top, r.Right, r.Bottom)
            {
            }

            public int X
            {
                get { return Left; }
                set { Right -= (Left - value); Left = value; }
            }

            public int Y
            {
                get { return Top; }
                set { Bottom -= (Top - value); Top = value; }
            }

            public int Height
            {
                get { return Bottom - Top; }
                set { Bottom = value + Top; }
            }

            public int Width
            {
                get { return Right - Left; }
                set { Right = value + Left; }
            }

            public System.Drawing.Point Location
            {
                get { return new System.Drawing.Point(Left, Top); }
                set { X = value.X; Y = value.Y; }
            }

            public System.Drawing.Size Size
            {
                get { return new System.Drawing.Size(Width, Height); }
                set { Width = value.Width; Height = value.Height; }
            }

            public static implicit operator System.Drawing.Rectangle(PRECT r) => new System.Drawing.Rectangle(r.Left, r.Top, r.Width, r.Height);

            public static implicit operator PRECT(System.Drawing.Rectangle? r) => r.HasValue ? new PRECT(r.Value) : null;

            public static implicit operator PRECT(System.Drawing.Rectangle r) => new PRECT(r);

            public static bool operator ==(PRECT r1, PRECT r2) => r1.Equals(r2);

            public static bool operator !=(PRECT r1, PRECT r2) => !r1.Equals(r2);

            public bool Equals(PRECT r) => r.Left == Left && r.Top == Top && r.Right == Right && r.Bottom == Bottom;

            public override bool Equals(object obj)
            {
                if (obj is PRECT)
                    return Equals((PRECT)obj);
                else if (obj is System.Drawing.Rectangle)
                    return Equals(new PRECT((System.Drawing.Rectangle)obj));
                return false;
            }

            public override int GetHashCode() => ((System.Drawing.Rectangle)this).GetHashCode();

            public override string ToString() => $"{{Left={Left},Top={Top},Right={Right},Bottom={Bottom}}}";
        }
    }
}