#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license or other governing licenses that can be found in the LICENSE.md file or at
 * https://raw.githubusercontent.com/Krypton-Suite/Extended-Toolkit/master/LICENSE
 */
#endregion

using Krypton.Toolkit.Suite.Extended.Utilities.System.AudioFormat;
using Krypton.Toolkit.Suite.Extended.Utilities.System.Internal;
using Krypton.Toolkit.Suite.Extended.Utilities.SystemInternal.Speech;

namespace Krypton.Toolkit.Suite.Extended.Utilities.System.Recognition
{
    /// <filterpriority>2</filterpriority>
    [Serializable]
    public class RecognizedAudio
    {
        private DateTime _startTime;

        private TimeSpan _audioPosition;

        private TimeSpan _audioDuration;

        private SpeechAudioFormatInfo _audioFormat;

        private byte[] _rawAudioData;

        public SpeechAudioFormatInfo Format => _audioFormat;

        public DateTime StartTime => _startTime;

        public TimeSpan AudioPosition => _audioPosition;

        public TimeSpan Duration => _audioDuration;

        internal RecognizedAudio(byte[] rawAudioData, SpeechAudioFormatInfo audioFormat, DateTime startTime, TimeSpan audioPosition, TimeSpan audioDuration)
        {
            _audioFormat = audioFormat;
            _startTime = startTime;
            _audioPosition = audioPosition;
            _audioDuration = audioDuration;
            _rawAudioData = rawAudioData;
        }

        public void WriteToWaveStream(Stream outputStream)
        {
            Helpers.ThrowIfNull(outputStream, "outputStream");
            using (StreamMarshaler sm = new StreamMarshaler(outputStream))
            {
                WriteWaveHeader(sm);
            }
            outputStream.Write(_rawAudioData, 0, _rawAudioData.Length);
            outputStream.Flush();
        }

        public void WriteToAudioStream(Stream outputStream)
        {
            Helpers.ThrowIfNull(outputStream, "outputStream");
            outputStream.Write(_rawAudioData, 0, _rawAudioData.Length);
            outputStream.Flush();
        }

        public RecognizedAudio GetRange(TimeSpan audioPosition, TimeSpan duration)
        {
            if (audioPosition.Ticks < 0)
            {
                throw new ArgumentOutOfRangeException("audioPosition", SR.Get(SRID.NegativeTimesNotSupported));
            }
            if (duration.Ticks < 0)
            {
                throw new ArgumentOutOfRangeException("duration", SR.Get(SRID.NegativeTimesNotSupported));
            }
            if (audioPosition > _audioDuration)
            {
                throw new ArgumentOutOfRangeException("audioPosition");
            }
            if (duration > audioPosition + _audioDuration)
            {
                throw new ArgumentOutOfRangeException("duration");
            }
            int num = (int)(_audioFormat.BitsPerSample * _audioFormat.SamplesPerSecond * audioPosition.Ticks / 80000000);
            int num2 = (int)(_audioFormat.BitsPerSample * _audioFormat.SamplesPerSecond * duration.Ticks / 80000000);
            if (num + num2 > _rawAudioData.Length)
            {
                num2 = _rawAudioData.Length - num;
            }
            byte[] array = new byte[num2];
            Array.Copy(_rawAudioData, num, array, 0, num2);
            return new RecognizedAudio(array, _audioFormat, _startTime + audioPosition, audioPosition, duration);
        }

        private void WriteWaveHeader(StreamMarshaler sm)
        {
            char[] array = new char[4]
            {
                'R',
                'I',
                'F',
                'F'
            };
            byte[] array2 = _audioFormat.FormatSpecificData();
            sm.WriteArray(array, array.Length);
            sm.WriteStream((uint)(_rawAudioData.Length + 38 + array2.Length));
            char[] array3 = new char[4]
            {
                'W',
                'A',
                'V',
                'E'
            };
            sm.WriteArray(array3, array3.Length);
            char[] array4 = new char[4]
            {
                'f',
                'm',
                't',
                ' '
            };
            sm.WriteArray(array4, array4.Length);
            sm.WriteStream(18 + array2.Length);
            sm.WriteStream((ushort)_audioFormat.EncodingFormat);
            sm.WriteStream((ushort)_audioFormat.ChannelCount);
            sm.WriteStream(_audioFormat.SamplesPerSecond);
            sm.WriteStream(_audioFormat.AverageBytesPerSecond);
            sm.WriteStream((ushort)_audioFormat.BlockAlign);
            sm.WriteStream((ushort)_audioFormat.BitsPerSample);
            sm.WriteStream((ushort)array2.Length);
            if (array2.Length != 0)
            {
                sm.WriteStream(array2);
            }
            char[] array5 = new char[4]
            {
                'd',
                'a',
                't',
                'a'
            };
            sm.WriteArray(array5, array5.Length);
            sm.WriteStream(_rawAudioData.Length);
        }
    }
}
