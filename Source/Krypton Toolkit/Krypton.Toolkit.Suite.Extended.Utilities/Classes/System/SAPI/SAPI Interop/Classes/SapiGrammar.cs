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

namespace Krypton.Toolkit.Suite.Extended.Utilities.System.SAPIInterop;

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