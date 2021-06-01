#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license or other governing licenses that can be found in the LICENSE.md file or at
 * https://raw.githubusercontent.com/Krypton-Suite/Extended-Toolkit/master/LICENSE
 */
#endregion

namespace Krypton.Toolkit.Suite.Extended.Wizard
{
    internal static partial class NativeMethods
    {
        [StructLayout(LayoutKind.Sequential)]
        public struct SIZE
        {
            public int width;
            public int height;

            public SIZE(int w, int h)
            {
                width = w; height = h;
            }

            public Size ToSize() => this;

            public static implicit operator Size(SIZE s) => new Size(s.width, s.height);

            public static implicit operator SIZE(Size s) => new SIZE(s.Width, s.Height);
        }
    }
}