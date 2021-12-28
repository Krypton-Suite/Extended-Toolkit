#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license or other governing licenses that can be found in the LICENSE.md file or at
 * https://raw.githubusercontent.com/Krypton-Suite/Extended-Toolkit/master/LICENSE
 */
#endregion

namespace Krypton.Toolkit.Suite.Extended.Utilities.System.Synthesis
{
    /// <filterpriority>2</filterpriority>
    [Serializable]
    public class PromptStyle
    {
        private PromptRate _rate;

        private PromptVolume _volume;

        private PromptEmphasis _emphasis;

        public PromptRate Rate
        {
            get
            {
                return _rate;
            }
            set
            {
                _rate = value;
            }
        }

        public PromptVolume Volume
        {
            get
            {
                return _volume;
            }
            set
            {
                _volume = value;
            }
        }

        public PromptEmphasis Emphasis
        {
            get
            {
                return _emphasis;
            }
            set
            {
                _emphasis = value;
            }
        }

        public PromptStyle()
        {
        }

        public PromptStyle(PromptRate rate)
        {
            Rate = rate;
        }

        public PromptStyle(PromptVolume volume)
        {
            Volume = volume;
        }

        public PromptStyle(PromptEmphasis emphasis)
        {
            Emphasis = emphasis;
        }
    }
}
