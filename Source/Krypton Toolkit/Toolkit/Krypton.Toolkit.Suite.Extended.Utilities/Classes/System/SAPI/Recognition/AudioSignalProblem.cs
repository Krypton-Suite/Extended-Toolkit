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
    public enum AudioSignalProblem
    {
        /// <summary />
        None,
        /// <summary />
        TooNoisy,
        /// <summary />
        NoSignal,
        /// <summary />
        TooLoud,
        /// <summary />
        TooSoft,
        /// <summary />
        TooFast,
        /// <summary />
        TooSlow
    }
}