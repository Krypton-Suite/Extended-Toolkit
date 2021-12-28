#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license or other governing licenses that can be found in the LICENSE.md file or at
 * https://raw.githubusercontent.com/Krypton-Suite/Extended-Toolkit/master/LICENSE
 */
#endregion

namespace Krypton.Toolkit.Suite.Extended.Utilities.System.SAPIInterop
{
    internal class SapiGrammar : IDisposable
    {
        private ISpRecoGrammar2 _sapiGrammar2;

        private ISpRecoGrammar _sapiGrammar;

        private SapiProxy _sapiProxy;

        private bool _disposed;

        internal ISpRecoGrammar2 SpRecoGrammar2
        {
            get
            {
                if (_sapiGrammar2 == null)
                {
                    _sapiGrammar2 = (ISpRecoGrammar2)_sapiGrammar;
                }
                return _sapiGrammar2;
            }
        }

        internal SapiGrammar(ISpRecoGrammar sapiGrammar, SapiProxy thread)
        {
            _sapiGrammar = sapiGrammar;
            _sapiProxy = thread;
        }

        public void Dispose()
        {
            if (!_disposed)
            {
                Marshal.ReleaseComObject(_sapiGrammar);
                GC.SuppressFinalize(this);
                _disposed = true;
            }
        }

        internal void SetGrammarState(SPGRAMMARSTATE state)
        {
            _sapiProxy.Invoke2(delegate
            {
                _sapiGrammar.SetGrammarState(state);
            });
        }

        internal void SetWordSequenceData(string text, SPTEXTSELECTIONINFO info)
        {
            _sapiProxy.Invoke2(delegate
            {
                _sapiGrammar.SetWordSequenceData(text, (uint)text.Length, ref info);
            });
        }

        internal void LoadCmdFromMemory(IntPtr grammar, SPLOADOPTIONS options)
        {
            _sapiProxy.Invoke2(delegate
            {
                _sapiGrammar.LoadCmdFromMemory(grammar, options);
            });
        }

        internal void LoadDictation(string pszTopicName, SPLOADOPTIONS options)
        {
            _sapiProxy.Invoke2(delegate
            {
                _sapiGrammar.LoadDictation(pszTopicName, options);
            });
        }

        internal SAPIErrorCodes SetDictationState(SPRULESTATE state)
        {
            return (SAPIErrorCodes)_sapiProxy.Invoke(() => _sapiGrammar.SetDictationState(state));
        }

        internal SAPIErrorCodes SetRuleState(string name, SPRULESTATE state)
        {
            return (SAPIErrorCodes)_sapiProxy.Invoke(() => _sapiGrammar.SetRuleState(name, IntPtr.Zero, state));
        }

        internal void SetGrammarLoader(ISpGrammarResourceLoader resourceLoader)
        {
            SpRecoGrammar2.SetGrammarLoader(resourceLoader);
        }

        internal void LoadCmdFromMemory2(IntPtr grammar, SPLOADOPTIONS options, string sharingUri, string baseUri)
        {
            SpRecoGrammar2.LoadCmdFromMemory2(grammar, options, sharingUri, baseUri);
        }

        internal void SetRulePriority(string name, uint id, int priority)
        {
            SpRecoGrammar2.SetRulePriority(name, id, priority);
        }

        internal void SetRuleWeight(string name, uint id, float weight)
        {
            SpRecoGrammar2.SetRuleWeight(name, id, weight);
        }

        internal void SetDictationWeight(float weight)
        {
            SpRecoGrammar2.SetDictationWeight(weight);
        }
    }
}