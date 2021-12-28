#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license or other governing licenses that can be found in the LICENSE.md file or at
 * https://raw.githubusercontent.com/Krypton-Suite/Extended-Toolkit/master/LICENSE
 */
#endregion

using Krypton.Toolkit.Suite.Extended.Utilities.System.Internal;
using Krypton.Toolkit.Suite.Extended.Utilities.SystemInternal.Speech;

namespace Krypton.Toolkit.Suite.Extended.Utilities.System.Synthesis
{
    [DebuggerDisplay("{_text}")]
    public class Prompt
    {
        internal string _text;

        internal Uri _audio;

        internal SynthesisMediaType _media;

        internal bool _syncSpeak;

        internal Exception _exception;

        private bool _completed;

        private object _synthesizer;

        private static ResourceLoader _resourceLoader = new ResourceLoader();

        public bool IsCompleted
        {
            get
            {
                return _completed;
            }
            internal set
            {
                _completed = value;
            }
        }

        internal object Synthesizer
        {
            set
            {
                if (value != null && (_synthesizer != null || _completed))
                {
                    throw new ArgumentException(SR.Get(SRID.SynthesizerPromptInUse), "value");
                }
                _synthesizer = value;
            }
        }

        public Prompt(string textToSpeak)
            : this(textToSpeak, SynthesisTextFormat.Text)
        {
        }

        public Prompt(PromptBuilder promptBuilder)
        {
            Helpers.ThrowIfNull(promptBuilder, "promptBuilder");
            _text = promptBuilder.ToXml();
            _media = SynthesisMediaType.Ssml;
        }

        public Prompt(string textToSpeak, SynthesisTextFormat media)
        {
            Helpers.ThrowIfNull(textToSpeak, "textToSpeak");
            if ((uint)(_media = (SynthesisMediaType)media) <= 1u)
            {
                _text = textToSpeak;
                return;
            }
            throw new ArgumentException(SR.Get(SRID.SynthesizerUnknownMediaType), "media");
        }

        internal Prompt(Uri promptFile, SynthesisMediaType media)
        {
            Helpers.ThrowIfNull(promptFile, "promptFile");
            switch (_media = media)
            {
                case SynthesisMediaType.Text:
                case SynthesisMediaType.Ssml:
                    {
                        string mimeType;
                        Uri baseUri;
                        string localPath;
                        using (Stream stream = _resourceLoader.LoadFile(promptFile, out mimeType, out baseUri, out localPath))
                        {
                            try
                            {
                                using (TextReader textReader = new StreamReader(stream))
                                {
                                    _text = textReader.ReadToEnd();
                                }
                            }
                            finally
                            {
                                _resourceLoader.UnloadFile(localPath);
                            }
                        }
                        break;
                    }
                case SynthesisMediaType.WaveAudio:
                    _text = promptFile.ToString();
                    _audio = promptFile;
                    break;
                default:
                    throw new ArgumentException(SR.Get(SRID.SynthesizerUnknownMediaType), "media");
            }
        }
    }
}
