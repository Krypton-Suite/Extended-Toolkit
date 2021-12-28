#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license or other governing licenses that can be found in the LICENSE.md file or at
 * https://raw.githubusercontent.com/Krypton-Suite/Extended-Toolkit/master/LICENSE
 */
#endregion

using Krypton.Toolkit.Suite.Extended.Utilities.System.Internal;

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
            get
            {
                return _enabled;
            }
            set
            {
                SetEnabledFlag(value, true);
            }
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
