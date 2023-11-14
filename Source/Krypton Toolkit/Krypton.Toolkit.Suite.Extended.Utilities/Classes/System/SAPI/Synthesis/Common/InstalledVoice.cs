#region MIT License
/*
 *
 * MIT License
 *
 * Copyright (c) 2017 - 2023 Krypton Suite
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

namespace Krypton.Toolkit.Suite.Extended.Utilities.System.Synthesis
{
    [DebuggerDisplay("{VoiceInfo.Name} [{Enabled ? \"Enabled\" : \"Disabled\"}]")]
    public class InstalledVoice
    {
        private VoiceInfo _voice;

        private bool _enabled;

        private VoiceSynthesis _voiceSynthesizer;

        public VoiceInfo VoiceInfo => _voice;

        public bool Enabled
        {
            get => _enabled;
            set => SetEnabledFlag(value, true);
        }

        internal InstalledVoice(VoiceSynthesis voiceSynthesizer, VoiceInfo voice)
        {
            _voiceSynthesizer = voiceSynthesizer;
            _voice = voice;
            _enabled = true;
        }

        public override bool Equals(object obj)
        {
            InstalledVoice installedVoice = obj as InstalledVoice;
            if (installedVoice == null)
            {
                return false;
            }
            if (VoiceInfo.Name == installedVoice.VoiceInfo.Name && VoiceInfo.Age == installedVoice.VoiceInfo.Age && VoiceInfo.Gender == installedVoice.VoiceInfo.Gender)
            {
                return VoiceInfo.Culture.Equals(installedVoice.VoiceInfo.Culture);
            }
            return false;
        }

        /// <filterpriority>2</filterpriority>
        public override int GetHashCode()
        {
            return VoiceInfo.Name.GetHashCode();
        }

        internal static InstalledVoice Find(List<InstalledVoice> list, VoiceInfo voiceId)
        {
            foreach (InstalledVoice item in list)
            {
                if (item.Enabled && item.VoiceInfo.Equals(voiceId))
                {
                    return item;
                }
            }
            return null;
        }

        internal static InstalledVoice FirstEnabled(List<InstalledVoice> list, CultureInfo culture)
        {
            InstalledVoice installedVoice = null;
            foreach (InstalledVoice item in list)
            {
                if (item.Enabled)
                {
                    if (Helpers.CompareInvariantCulture(item.VoiceInfo.Culture, culture))
                    {
                        return item;
                    }
                    if (installedVoice == null)
                    {
                        installedVoice = item;
                    }
                }
            }
            return installedVoice;
        }

        internal void SetEnabledFlag(bool value, bool switchContext)
        {
            try
            {
                if (_enabled != value)
                {
                    _enabled = value;
                    if (!_enabled)
                    {
                        if (_voice.Equals(_voiceSynthesizer.CurrentVoice(switchContext).VoiceInfo))
                        {
                            _voiceSynthesizer.Voice = null;
                        }
                    }
                    else
                    {
                        _voiceSynthesizer.Voice = null;
                    }
                }
            }
            catch (InvalidOperationException)
            {
                _voiceSynthesizer.Voice = null;
            }
        }
    }
}
