#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license or other governing licenses that can be found in the LICENSE.md file or at
 * https://raw.githubusercontent.com/Krypton-Suite/Extended-Toolkit/master/LICENSE
 */
#endregion

using Krypton.Toolkit.Suite.Extended.Utilities.System.Internal;

namespace Krypton.Toolkit.Suite.Extended.Utilities.System.SAPIInterop
{
    internal class SapiRecoContext : IDisposable
    {
        private ISpRecoContext _recoContext;

        private SapiProxy _proxy;

        private bool _disposed;

        internal SapiRecoContext(ISpRecoContext recoContext, SapiProxy proxy)
        {
            _recoContext = recoContext;
            _proxy = proxy;
        }

        public void Dispose()
        {
            if (!_disposed)
            {
                _proxy.Invoke2(delegate
                {
                    Marshal.ReleaseComObject(_recoContext);
                });
                _disposed = true;
            }
            GC.SuppressFinalize(this);
        }

        internal void SetInterest(ulong eventInterest, ulong queuedInterest)
        {
            _proxy.Invoke2(delegate
            {
                _recoContext.SetInterest(eventInterest, queuedInterest);
            });
        }

        internal SapiGrammar CreateGrammar(ulong id)
        {
            ISpRecoGrammar sapiGrammar;
            return (SapiGrammar)_proxy.Invoke(delegate
            {
                _recoContext.CreateGrammar(id, out sapiGrammar);
                return new SapiGrammar(sapiGrammar, _proxy);
            });
        }

        internal void SetMaxAlternates(uint count)
        {
            _proxy.Invoke2(delegate
            {
                _recoContext.SetMaxAlternates(count);
            });
        }

        internal void SetAudioOptions(SPAUDIOOPTIONS options, IntPtr audioFormatId, IntPtr waveFormatEx)
        {
            _proxy.Invoke2(delegate
            {
                _recoContext.SetAudioOptions(options, audioFormatId, waveFormatEx);
            });
        }

        internal void Bookmark(SPBOOKMARKOPTIONS options, ulong position, IntPtr lparam)
        {
            _proxy.Invoke2(delegate
            {
                _recoContext.Bookmark(options, position, lparam);
            });
        }

        internal void Resume()
        {
            _proxy.Invoke2(delegate
            {
                _recoContext.Resume(0u);
            });
        }

        internal void SetContextState(SPCONTEXTSTATE state)
        {
            _proxy.Invoke2(delegate
            {
                _recoContext.SetContextState(state);
            });
        }

        internal EventNotify CreateEventNotify(AsyncSerializedWorker asyncWorker, bool supportsSapi53)
        {
            return (EventNotify)_proxy.Invoke(() => new EventNotify(_recoContext, asyncWorker, supportsSapi53));
        }

        internal void DisposeEventNotify(EventNotify eventNotify)
        {
            _proxy.Invoke2(delegate
            {
                eventNotify.Dispose();
            });
        }

        internal void SetGrammarOptions(SPGRAMMAROPTIONS options)
        {
            _proxy.Invoke2(delegate
            {
                ((ISpRecoContext2)_recoContext).SetGrammarOptions(options);
            });
        }
    }
}