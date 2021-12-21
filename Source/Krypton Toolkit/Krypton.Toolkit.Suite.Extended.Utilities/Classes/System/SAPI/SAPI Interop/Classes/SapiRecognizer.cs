#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license or other governing licenses that can be found in the LICENSE.md file or at
 * https://raw.githubusercontent.com/Krypton-Suite/Extended-Toolkit/master/LICENSE
 */
#endregion

using Krypton.Toolkit.Suite.Extended.Utilities.System.ObjectTokens;
using Krypton.Toolkit.Suite.Extended.Utilities.System.Recognition;
using Krypton.Toolkit.Suite.Extended.Utilities.SystemInternal.Speech;

namespace Krypton.Toolkit.Suite.Extended.Utilities.System.SAPIInterop
{
    internal class SapiRecognizer : IDisposable
    {
        internal enum RecognizerType
        {
            InProc,
            Shared
        }

        private SapiProxy _proxy;

        private bool _disposed;

        private bool _isSap53;

        internal bool IsSapi53 => _isSap53;

        internal SapiRecognizer(RecognizerType type)
        {
            ISpRecognizer spRecognizer;
            try
            {
                spRecognizer = ((type != 0) ? ((ISpRecognizer)new SpSharedRecognizer()) : ((ISpRecognizer)new SpInprocRecognizer()));
                _isSap53 = (spRecognizer is ISpRecognizer2);
            }
            catch (COMException e)
            {
                throw RecognizerBase.ExceptionFromSapiCreateRecognizerError(e);
            }
            if (!IsSapi53 && Thread.CurrentThread.GetApartmentState() == ApartmentState.STA)
            {
                Marshal.ReleaseComObject(spRecognizer);
                _proxy = new SapiProxy.MTAThread(type);
            }
            else
            {
                _proxy = new SapiProxy.PassThrough(spRecognizer);
            }
        }

        public void Dispose()
        {
            if (!_disposed)
            {
                _proxy.Dispose();
                _disposed = true;
            }
            GC.SuppressFinalize(this);
        }

        internal void SetPropertyNum(string name, int value)
        {
            _proxy.Invoke2(delegate
            {
                SetProperty(_proxy.Recognizer, name, value);
            });
        }

        internal int GetPropertyNum(string name)
        {
            return (int)_proxy.Invoke(() => GetProperty(_proxy.Recognizer, name, true));
        }

        internal void SetPropertyString(string name, string value)
        {
            _proxy.Invoke2(delegate
            {
                SetProperty(_proxy.Recognizer, name, value);
            });
        }

        internal string GetPropertyString(string name)
        {
            return (string)_proxy.Invoke(() => GetProperty(_proxy.Recognizer, name, false));
        }

        internal void SetRecognizer(ISpObjectToken recognizer)
        {
            try
            {
                _proxy.Invoke2(delegate
                {
                    _proxy.Recognizer.SetRecognizer(recognizer);
                });
            }
            catch (InvalidCastException)
            {
                throw new PlatformNotSupportedException(SR.Get(SRID.NotSupportedWithThisVersionOfSAPI));
            }
        }

        internal RecognizerInfo GetRecognizerInfo()
        {
            ISpObjectToken sapiObjectToken;
            return (RecognizerInfo)_proxy.Invoke(delegate
            {
                _proxy.Recognizer.GetRecognizer(out sapiObjectToken);
                try
                {
                    IntPtr ppszCoMemTokenId;
                    sapiObjectToken.GetId(out ppszCoMemTokenId);
                    string sTokenId = Marshal.PtrToStringUni(ppszCoMemTokenId);
                    RecognizerInfo recognizerInfo = RecognizerInfo.Create(ObjectToken.Open(null, sTokenId, false));
                    if (recognizerInfo == null)
                    {
                        throw new InvalidOperationException(SR.Get(SRID.RecognizerNotFound));
                    }
                    Marshal.FreeCoTaskMem(ppszCoMemTokenId);
                    return recognizerInfo;
                }
                finally
                {
                    Marshal.ReleaseComObject(sapiObjectToken);
                }
            });
        }

        internal void SetInput(object input, bool allowFormatChanges)
        {
            _proxy.Invoke2(delegate
            {
                _proxy.Recognizer.SetInput(input, allowFormatChanges);
            });
        }

        internal SapiRecoContext CreateRecoContext()
        {
            ISpRecoContext context;
            return (SapiRecoContext)_proxy.Invoke(delegate
            {
                _proxy.Recognizer.CreateRecoContext(out context);
                return new SapiRecoContext(context, _proxy);
            });
        }

        internal SPRECOSTATE GetRecoState()
        {
            SPRECOSTATE state;
            return (SPRECOSTATE)_proxy.Invoke(delegate
            {
                _proxy.Recognizer.GetRecoState(out state);
                return state;
            });
        }

        internal void SetRecoState(SPRECOSTATE state)
        {
            _proxy.Invoke2(delegate
            {
                _proxy.Recognizer.SetRecoState(state);
            });
        }

        internal SPRECOGNIZERSTATUS GetStatus()
        {
            SPRECOGNIZERSTATUS status;
            return (SPRECOGNIZERSTATUS)_proxy.Invoke(delegate
            {
                _proxy.Recognizer.GetStatus(out status);
                return status;
            });
        }

        internal IntPtr GetFormat(SPSTREAMFORMATTYPE WaveFormatType)
        {
            return (IntPtr)_proxy.Invoke(delegate
            {
                Guid pFormatId;
                IntPtr ppCoMemWFEX;
                _proxy.Recognizer.GetFormat(WaveFormatType, out pFormatId, out ppCoMemWFEX);
                return ppCoMemWFEX;
            });
        }

        internal SAPIErrorCodes EmulateRecognition(string phrase)
        {
            object displayAttributes = " ";
            return (SAPIErrorCodes)_proxy.Invoke(() => _proxy.SapiSpeechRecognizer.EmulateRecognition(phrase, ref displayAttributes, 0));
        }

        internal SAPIErrorCodes EmulateRecognition(ISpPhrase iSpPhrase, uint dwCompareFlags)
        {
            return (SAPIErrorCodes)_proxy.Invoke(() => _proxy.Recognizer2.EmulateRecognitionEx(iSpPhrase, dwCompareFlags));
        }

        private static void SetProperty(ISpRecognizer sapiRecognizer, string name, object value)
        {
            SAPIErrorCodes sAPIErrorCodes = (SAPIErrorCodes)((!(value is int)) ? sapiRecognizer.SetPropertyString(name, (string)value) : sapiRecognizer.SetPropertyNum(name, (int)value));
            if (sAPIErrorCodes == SAPIErrorCodes.S_FALSE)
            {
                throw new KeyNotFoundException(SR.Get(SRID.RecognizerSettingNotSupported));
            }
            if (sAPIErrorCodes < SAPIErrorCodes.S_OK)
            {
                throw RecognizerBase.ExceptionFromSapiCreateRecognizerError(new COMException(SR.Get(SRID.RecognizerSettingUpdateError), (int)sAPIErrorCodes));
            }
        }

        private static object GetProperty(ISpRecognizer sapiRecognizer, string name, bool integer)
        {
            object obj = null;
            SAPIErrorCodes sAPIErrorCodes;
            if (integer)
            {
                int plValue;
                sAPIErrorCodes = (SAPIErrorCodes)sapiRecognizer.GetPropertyNum(name, out plValue);
                obj = plValue;
            }
            else
            {
                string ppCoMemValue;
                sAPIErrorCodes = (SAPIErrorCodes)sapiRecognizer.GetPropertyString(name, out ppCoMemValue);
                obj = ppCoMemValue;
            }
            if (sAPIErrorCodes == SAPIErrorCodes.S_FALSE)
            {
                throw new KeyNotFoundException(SR.Get(SRID.RecognizerSettingNotSupported));
            }
            if (sAPIErrorCodes < SAPIErrorCodes.S_OK)
            {
                throw RecognizerBase.ExceptionFromSapiCreateRecognizerError(new COMException(SR.Get(SRID.RecognizerSettingUpdateError), (int)sAPIErrorCodes));
            }
            return obj;
        }
    }
}