#region MIT License
/*
 *
 * MIT License
 *
 * Copyright (c) 2017 - 2024 Krypton Suite
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

namespace Krypton.Toolkit.Suite.Extended.Utilities.System.Synthesis;

[DebuggerDisplay("{_text}")]
public class Prompt
{
    internal string _text;

    internal Uri _audio;

    internal SynthesisMediaType _media;

    internal bool _syncSpeak;

    internal Exception _exception;

    private bool _completed;

    private object? _synthesizer;

    private static ResourceLoader _resourceLoader = new();

    public bool IsCompleted
    {
        get => _completed;
        internal set => _completed = value;
    }

    internal object Synthesizer
    {
        set
        {
            if (value != null && (_synthesizer != null || _completed))
            {
                throw new ArgumentException(SR.Get(SRID.SynthesizerPromptInUse), nameof(value));
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
        throw new ArgumentException(SR.Get(SRID.SynthesizerUnknownMediaType), nameof(media));
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