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