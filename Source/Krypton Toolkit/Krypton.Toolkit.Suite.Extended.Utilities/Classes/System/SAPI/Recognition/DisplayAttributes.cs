#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license or other governing licenses that can be found in the LICENSE.md file or at
 * https://raw.githubusercontent.com/Krypton-Suite/Extended-Toolkit/master/LICENSE
 */
#endregion

namespace Krypton.Toolkit.Suite.Extended.Utilities.System.Recognition
{
    /// <filterpriority>2</filterpriority>
    [Flags]
    public enum DisplayAttributes
    {
        /// <summary />
        None = 0x0,
        /// <summary />
        ZeroTrailingSpaces = 0x2,
        /// <summary />
        OneTrailingSpace = 0x4,
        /// <summary />
        TwoTrailingSpaces = 0x8,
        /// <summary />
        ConsumeLeadingSpaces = 0x10
    }
}
