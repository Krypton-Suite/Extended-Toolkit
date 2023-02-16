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

namespace Krypton.Toolkit.Suite.Extended.Utilities.System.SAPIInterop
{
    internal class EventNotify
    {
        private IAsyncDispatch _dispatcher;

        private WeakReference _sapiEventSourceReference;

        private bool _additionalSapiFeatures;

        private SpeechAudioFormatInfo _audioFormat;

        private ISpNotifySink _notifySink;

        internal SpeechAudioFormatInfo AudioFormat
        {
            set => _audioFormat = value;
        }

        internal EventNotify(ISpEventSource sapiEventSource, IAsyncDispatch dispatcher, bool additionalSapiFeatures)
        {
            _sapiEventSourceReference = new WeakReference(sapiEventSource);
            _dispatcher = dispatcher;
            _additionalSapiFeatures = additionalSapiFeatures;
            _notifySink = new SpNotifySink(this);
            sapiEventSource.SetNotifySink(_notifySink);
        }

        internal void Dispose()
        {
            lock (this)
            {
                if (_sapiEventSourceReference != null)
                {
                    ISpEventSource spEventSource = (ISpEventSource)_sapiEventSourceReference.Target;
                    if (spEventSource != null)
                    {
                        spEventSource.SetNotifySink(null);
                        _notifySink = null;
                    }
                }
                _sapiEventSourceReference = null;
            }
        }

        internal void SendNotification(object ignored)
        {
            lock (this)
            {
                if (_sapiEventSourceReference != null)
                {
                    ISpEventSource spEventSource = (ISpEventSource)_sapiEventSourceReference.Target;
                    if (spEventSource != null)
                    {
                        List<SpeechEvent> list = new();
                        SpeechEvent item;
                        while ((item = SpeechEvent.TryCreateSpeechEvent(spEventSource, _additionalSapiFeatures, _audioFormat)) != null)
                        {
                            list.Add(item);
                        }
                        _dispatcher.Post(list.ToArray());
                    }
                }
            }
        }
    }
}