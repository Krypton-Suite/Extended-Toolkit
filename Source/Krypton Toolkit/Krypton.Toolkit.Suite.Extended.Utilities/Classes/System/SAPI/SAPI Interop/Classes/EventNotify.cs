#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license or other governing licenses that can be found in the LICENSE.md file or at
 * https://raw.githubusercontent.com/Krypton-Suite/Extended-Toolkit/master/LICENSE
 */
#endregion

using Krypton.Toolkit.Suite.Extended.Utilities.System.AudioFormat;
using Krypton.Toolkit.Suite.Extended.Utilities.System.Internal;

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
            set
            {
                _audioFormat = value;
            }
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
                        List<SpeechEvent> list = new List<SpeechEvent>();
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