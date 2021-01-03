#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license or other governing licenses that can be found in the LICENSE.md file or at
 * https://raw.githubusercontent.com/Krypton-Suite/Extended-Toolkit/master/LICENSE
 */
#endregion

namespace Krypton.Toolkit.Suite.Extended.Base
{
    public abstract class FontMetrics
    {
        public virtual int Height { get { return 0; } }

        public virtual int Ascent { get { return 0; } }

        public virtual int Descent { get { return 0; } }

        public virtual int InternalLeading { get { return 0; } }

        public virtual int ExternalLeading { get { return 0; } }

        public virtual int AverageCharacterWidth { get { return 0; } }

        public virtual int MaximumCharacterWidth { get { return 0; } }

        public virtual int Weight { get { return 0; } }

        public virtual int Overhang { get { return 0; } }

        public virtual int DigitizedAspectX { get { return 0; } }

        public virtual int DigitizedAspectY { get { return 0; } }
    }
}