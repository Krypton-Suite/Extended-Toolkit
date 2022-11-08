#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license or other governing licenses that can be found in the LICENSE.md file or at
 * https://raw.githubusercontent.com/Krypton-Suite/Extended-Toolkit/master/LICENSE
 */
#endregion

#define TRACE
using Krypton.Toolkit.Suite.Extended.Utilities.System.AudioFormat;
using Krypton.Toolkit.Suite.Extended.Utilities.System.Internal;
using Krypton.Toolkit.Suite.Extended.Utilities.System.SAPIInterop;
using Krypton.Toolkit.Suite.Extended.Utilities.SystemInternal.Speech;

namespace Krypton.Toolkit.Suite.Extended.Utilities.System.Recognition
{
    [Serializable]
    [DebuggerDisplay("{DebuggerDisplayString ()}")]
    public sealed class RecognitionResult : RecognizedPhrase, ISerializable
    {
        [NonSerialized]
        private IRecognizerInternal _recognizer;

        [NonSerialized]
        private int _maxAlternates;

        [NonSerialized]
        private AlphabetConverter _alphabetConverter;

        private byte[] _sapiAudioBlob;

        private byte[] _sapiAlternatesBlob;

        private Collection<RecognizedPhrase> _alternates;

        private SPRESULTHEADER _header;

        private RecognizedAudio _audio;

        private DateTime _startTime = DateTime.Now;

        [NonSerialized]
        private ISpRecoResult2 _sapiRecoResult;

        private TimeSpan? _audioPosition;

        private TimeSpan? _audioDuration;

        public RecognizedAudio Audio
        {
            get
            {
                if (_audio == null && _header.ulRetainedOffset != 0)
                {
                    int num = _sapiAudioBlob.Length;
                    GCHandle gCHandle = GCHandle.Alloc(_sapiAudioBlob, GCHandleType.Pinned);
                    try
                    {
                        IntPtr intPtr = gCHandle.AddrOfPinnedObject();
                        SPWAVEFORMATEX sPWAVEFORMATEX = (SPWAVEFORMATEX)Marshal.PtrToStructure(intPtr, typeof(SPWAVEFORMATEX));
                        IntPtr source = new IntPtr((long)intPtr + sPWAVEFORMATEX.cbUsed);
                        byte[] array = new byte[num - sPWAVEFORMATEX.cbUsed];
                        Marshal.Copy(source, array, 0, num - (int)sPWAVEFORMATEX.cbUsed);
                        byte[] array2 = new byte[sPWAVEFORMATEX.cbSize];
                        if (sPWAVEFORMATEX.cbSize > 0)
                        {
                            IntPtr source2 = new IntPtr((long)intPtr + 38);
                            Marshal.Copy(source2, array2, 0, sPWAVEFORMATEX.cbSize);
                        }
                        SpeechAudioFormatInfo audioFormat = new SpeechAudioFormatInfo((EncodingFormat)sPWAVEFORMATEX.wFormatTag, (int)sPWAVEFORMATEX.nSamplesPerSec, (short)sPWAVEFORMATEX.wBitsPerSample, (short)sPWAVEFORMATEX.nChannels, (int)sPWAVEFORMATEX.nAvgBytesPerSec, (short)sPWAVEFORMATEX.nBlockAlign, array2);
                        DateTime startTime = (_header.times.dwTickCount != 0) ? DateTime.FromFileTime((long)(((ulong)_header.times.ftStreamTime.dwHighDateTime << 32) + _header.times.ftStreamTime.dwLowDateTime)) : (_startTime - AudioDuration);
                        _audio = new RecognizedAudio(array, audioFormat, startTime, AudioPosition, AudioDuration);
                    }
                    finally
                    {
                        gCHandle.Free();
                    }
                }
                return _audio;
            }
        }

        public ReadOnlyCollection<RecognizedPhrase> Alternates => new ReadOnlyCollection<RecognizedPhrase>(GetAlternates());

        internal IRecognizerInternal Recognizer
        {
            get
            {
                if (_recognizer == null)
                {
                    throw new NotSupportedException(SR.Get(SRID.CantGetPropertyFromSerializedInfo, "Recognizer"));
                }
                return _recognizer;
            }
        }

        internal TimeSpan AudioPosition
        {
            get
            {
                if (!_audioPosition.HasValue)
                {
                    _audioPosition = new TimeSpan((long)_header.times.ullStart);
                }
                return _audioPosition.Value;
            }
        }

        internal TimeSpan AudioDuration
        {
            get
            {
                if (!_audioDuration.HasValue)
                {
                    _audioDuration = new TimeSpan((long)_header.times.ullLength);
                }
                return _audioDuration.Value;
            }
        }

        internal RecognitionResult(IRecognizerInternal recognizer, ISpRecoResult recoResult, byte[] sapiResultBlob, int maxAlternates)
        {
            Initialize(recognizer, recoResult, sapiResultBlob, maxAlternates);
        }

        internal RecognitionResult()
        {
        }

        private RecognitionResult(SerializationInfo info, StreamingContext context)
        {
            Type type = GetType();
            MemberInfo[] serializableMembers = FormatterServices.GetSerializableMembers(type, context);
            bool flag = context.State == StreamingContextStates.CrossAppDomain;
            MemberInfo[] array = serializableMembers;
            foreach (MemberInfo memberInfo in array)
            {
                FieldInfo fieldInfo = (FieldInfo)memberInfo;
                if (!flag || (memberInfo.Name != "_recognizer" && memberInfo.Name != "_grammar" && memberInfo.Name != "_ruleList" && memberInfo.Name != "_audio" && memberInfo.Name != "_audio"))
                {
                    fieldInfo.SetValue(this, info.GetValue(fieldInfo.Name, fieldInfo.FieldType));
                }
            }
        }

        public RecognizedAudio GetAudioForWordRange(RecognizedWordUnit firstWord, RecognizedWordUnit lastWord)
        {
            Helpers.ThrowIfNull(firstWord, "firstWord");
            Helpers.ThrowIfNull(lastWord, "lastWord");
            return Audio.GetRange(firstWord._audioPosition, lastWord._audioPosition + lastWord._audioDuration - firstWord._audioPosition);
        }

        [SecurityPermission(SecurityAction.Demand, SerializationFormatter = true)]
        void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context)
        {
            Helpers.ThrowIfNull(info, "info");
            bool flag = context.State == StreamingContextStates.CrossAppDomain;
            if (!flag)
            {
                foreach (RecognizedPhrase alternate in Alternates)
                {
                    try
                    {
                        string smlContent = alternate.SmlContent;
                        RecognizedAudio audio = Audio;
                        if (alternate.Text == null || alternate.Homophones == null || alternate.Semantics == null || (smlContent == null && smlContent != null) || (audio == null && audio != null))
                        {
                            throw new SerializationException();
                        }
                    }
                    catch (NotSupportedException)
                    {
                    }
                }
            }
            Type type = GetType();
            MemberInfo[] serializableMembers = FormatterServices.GetSerializableMembers(type, context);
            MemberInfo[] array = serializableMembers;
            foreach (MemberInfo memberInfo in array)
            {
                if (!flag || (memberInfo.Name != "_recognizer" && memberInfo.Name != "_grammar" && memberInfo.Name != "_ruleList" && memberInfo.Name != "_audio" && memberInfo.Name != "_audio"))
                {
                    info.AddValue(memberInfo.Name, ((FieldInfo)memberInfo).GetValue(this));
                }
            }
        }

        internal bool SetTextFeedback(string text, bool isSuccessfulAction)
        {
            if (_sapiRecoResult == null)
            {
                throw new NotSupportedException(SR.Get(SRID.NotSupportedWithThisVersionOfSAPI));
            }
            try
            {
                _sapiRecoResult.SetTextFeedback(text, isSuccessfulAction);
            }
            catch (COMException ex)
            {
                if (ex.ErrorCode == -2147200893)
                {
                    throw new NotSupportedException(SR.Get(SRID.SapiErrorNotSupportedForInprocRecognizer));
                }
                return false;
            }
            return true;
        }

        internal string ConvertPronunciation(string pronunciation, int langId)
        {
            if (_alphabetConverter == null)
            {
                _alphabetConverter = new AlphabetConverter(langId);
            }
            else
            {
                _alphabetConverter.SetLanguageId(langId);
            }
            char[] array = _alphabetConverter.SapiToIpa(pronunciation.ToCharArray());
            if (array != null)
            {
                pronunciation = new string(array);
            }
            else
            {
                Trace.TraceError("Cannot convert the pronunciation to IPA alphabet.");
            }
            return pronunciation;
        }

        private void Initialize(IRecognizerInternal recognizer, ISpRecoResult recoResult, byte[] sapiResultBlob, int maxAlternates)
        {
            _recognizer = recognizer;
            _maxAlternates = maxAlternates;
            try
            {
                _sapiRecoResult = (recoResult as ISpRecoResult2);
            }
            catch (COMException)
            {
                _sapiRecoResult = null;
            }
            GCHandle gCHandle = GCHandle.Alloc(sapiResultBlob, GCHandleType.Pinned);
            try
            {
                IntPtr intPtr = gCHandle.AddrOfPinnedObject();
                int num = Marshal.ReadInt32(intPtr, 4);
                if (num == Marshal.SizeOf(typeof(SPRESULTHEADER_Sapi51)))
                {
                    SPRESULTHEADER_Sapi51 source = (SPRESULTHEADER_Sapi51)Marshal.PtrToStructure(intPtr, typeof(SPRESULTHEADER_Sapi51));
                    _header = new SPRESULTHEADER(source);
                    _isSapi53Header = false;
                }
                else
                {
                    _header = (SPRESULTHEADER)Marshal.PtrToStructure(intPtr, typeof(SPRESULTHEADER));
                    _isSapi53Header = true;
                }
                _header.Validate();
                IntPtr phraseBuffer = new IntPtr((long)intPtr + (int)_header.ulPhraseOffset);
                SPSERIALIZEDPHRASE phraseHeader = RecognizedPhrase.GetPhraseHeader(phraseBuffer, _header.ulPhraseDataSize, _isSapi53Header);
                bool hasIPAPronunciation = (_header.fAlphabet & 1) != 0;
                InitializeFromSerializedBuffer(this, phraseHeader, phraseBuffer, (int)_header.ulPhraseDataSize, _isSapi53Header, hasIPAPronunciation);
                if (recoResult != null)
                {
                    ExtractDictationAlternates(recoResult, maxAlternates);
                    recoResult.Discard(255u);
                }
            }
            finally
            {
                gCHandle.Free();
            }
            _sapiAudioBlob = new byte[_header.ulRetainedDataSize];
            Array.Copy(sapiResultBlob, (int)_header.ulRetainedOffset, _sapiAudioBlob, 0, (int)_header.ulRetainedDataSize);
            _sapiAlternatesBlob = new byte[_header.ulPhraseAltDataSize];
            Array.Copy(sapiResultBlob, (int)_header.ulPhraseAltOffset, _sapiAlternatesBlob, 0, (int)_header.ulPhraseAltDataSize);
        }

        private Collection<RecognizedPhrase> ExtractAlternates(int numberOfAlternates, bool isSapi53Header)
        {
            Collection<RecognizedPhrase> collection = new Collection<RecognizedPhrase>();
            if (numberOfAlternates > 0)
            {
                GCHandle gCHandle = GCHandle.Alloc(_sapiAlternatesBlob, GCHandleType.Pinned);
                try
                {
                    IntPtr value = gCHandle.AddrOfPinnedObject();
                    int num = Marshal.SizeOf(typeof(SPSERIALIZEDPHRASEALT));
                    int num2 = 0;
                    for (int i = 0; i < numberOfAlternates; i++)
                    {
                        IntPtr ptr = new IntPtr((long)value + num2);
                        SPSERIALIZEDPHRASEALT sPSERIALIZEDPHRASEALT = (SPSERIALIZEDPHRASEALT)Marshal.PtrToStructure(ptr, typeof(SPSERIALIZEDPHRASEALT));
                        num2 += num;
                        num2 = ((!isSapi53Header) ? (num2 + (int)sPSERIALIZEDPHRASEALT.cbAltExtra) : (num2 + (int)((sPSERIALIZEDPHRASEALT.cbAltExtra + 7) & -8)));
                        IntPtr phraseBuffer = new IntPtr((long)value + num2);
                        SPSERIALIZEDPHRASE phraseHeader = RecognizedPhrase.GetPhraseHeader(phraseBuffer, (uint)((int)_header.ulPhraseAltDataSize - num2), _isSapi53Header);
                        int ulSerializedSize = (int)phraseHeader.ulSerializedSize;
                        RecognizedPhrase recognizedPhrase = new RecognizedPhrase();
                        bool hasIPAPronunciation = (_header.fAlphabet & 2) != 0;
                        recognizedPhrase.InitializeFromSerializedBuffer(this, phraseHeader, phraseBuffer, ulSerializedSize, isSapi53Header, hasIPAPronunciation);
                        num2 = ((!isSapi53Header) ? (num2 + ulSerializedSize) : (num2 + ((ulSerializedSize + 7) & -8)));
                        collection.Add(recognizedPhrase);
                    }
                    return collection;
                }
                finally
                {
                    gCHandle.Free();
                }
            }
            return collection;
        }

        private void ExtractDictationAlternates(ISpRecoResult recoResult, int maxAlternates)
        {
            if (recoResult != null && base.Grammar is DictationGrammar)
            {
                _alternates = new Collection<RecognizedPhrase>();
                IntPtr[] array = new IntPtr[maxAlternates];
                try
                {
                    recoResult.GetAlternates(0, -1, maxAlternates, array, out maxAlternates);
                }
                catch (COMException)
                {
                    maxAlternates = 0;
                }
                for (uint num = 0u; num < maxAlternates; num++)
                {
                    ISpPhraseAlt spPhraseAlt = (ISpPhraseAlt)Marshal.GetObjectForIUnknown(array[num]);
                    try
                    {
                        IntPtr ppCoMemPhrase;
                        spPhraseAlt.GetSerializedPhrase(out ppCoMemPhrase);
                        try
                        {
                            RecognizedPhrase recognizedPhrase = new RecognizedPhrase();
                            SPSERIALIZEDPHRASE phraseHeader = RecognizedPhrase.GetPhraseHeader(ppCoMemPhrase, uint.MaxValue, _isSapi53Header);
                            bool hasIPAPronunciation = (_header.fAlphabet & 1) != 0;
                            recognizedPhrase.InitializeFromSerializedBuffer(this, phraseHeader, ppCoMemPhrase, (int)phraseHeader.ulSerializedSize, _isSapi53Header, hasIPAPronunciation);
                            _alternates.Add(recognizedPhrase);
                        }
                        finally
                        {
                            Marshal.FreeCoTaskMem(ppCoMemPhrase);
                        }
                    }
                    finally
                    {
                        Marshal.Release(array[num]);
                    }
                }
            }
        }

        private Collection<RecognizedPhrase> GetAlternates()
        {
            if (_alternates == null)
            {
                _alternates = ExtractAlternates((int)_header.ulNumPhraseAlts, _isSapi53Header);
                if (_alternates.Count == 0 && _maxAlternates > 0)
                {
                    RecognizedPhrase recognizedPhrase = new RecognizedPhrase();
                    GCHandle gCHandle = GCHandle.Alloc(_phraseBuffer, GCHandleType.Pinned);
                    try
                    {
                        recognizedPhrase.InitializeFromSerializedBuffer(this, _serializedPhrase, gCHandle.AddrOfPinnedObject(), _phraseBuffer.Length, _isSapi53Header, _hasIPAPronunciation);
                    }
                    finally
                    {
                        gCHandle.Free();
                    }
                    _alternates.Add(recognizedPhrase);
                }
            }
            return _alternates;
        }

        internal string DebuggerDisplayString()
        {
            StringBuilder stringBuilder = new StringBuilder("Recognized text: '");
            stringBuilder.Append(base.Text);
            stringBuilder.Append("'");
            if (base.Semantics.Value != null)
            {
                stringBuilder.Append(" - Semantic Value  = ");
                stringBuilder.Append(base.Semantics.Value.ToString());
            }
            if (base.Semantics.Count > 0)
            {
                stringBuilder.Append(" - Semantic children count = ");
                stringBuilder.Append(base.Semantics.Count.ToString(CultureInfo.InvariantCulture));
            }
            if (Alternates.Count > 1)
            {
                stringBuilder.Append(" - Alternate word count = ");
                stringBuilder.Append(Alternates.Count.ToString(CultureInfo.InvariantCulture));
            }
            return stringBuilder.ToString();
        }
    }
}
