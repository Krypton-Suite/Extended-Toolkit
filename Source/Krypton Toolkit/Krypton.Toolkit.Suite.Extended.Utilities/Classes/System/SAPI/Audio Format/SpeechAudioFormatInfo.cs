#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license or other governing licenses that can be found in the LICENSE.md file or at
 * https://raw.githubusercontent.com/Krypton-Suite/Extended-Toolkit/master/LICENSE
 */
#endregion

using Krypton.Toolkit.Suite.Extended.Utilities.System.Synthesis;
using Krypton.Toolkit.Suite.Extended.Utilities.SystemInternal.Speech;

namespace Krypton.Toolkit.Suite.Extended.Utilities.System.AudioFormat
{
    [Serializable]
	public class SpeechAudioFormatInfo
	{
		private int _averageBytesPerSecond;

		private short _bitsPerSample;

		private short _blockAlign;

		private EncodingFormat _encodingFormat;

		private short _channelCount;

		private int _samplesPerSecond;

		private byte[] _formatSpecificData;

		/// <filterpriority>1</filterpriority>
		[EditorBrowsable(EditorBrowsableState.Advanced)]
		public int AverageBytesPerSecond => _averageBytesPerSecond;

		/// <filterpriority>1</filterpriority>
		[EditorBrowsable(EditorBrowsableState.Advanced)]
		public int BitsPerSample => _bitsPerSample;

		/// <filterpriority>1</filterpriority>
		[EditorBrowsable(EditorBrowsableState.Advanced)]
		public int BlockAlign => _blockAlign;

		public EncodingFormat EncodingFormat => _encodingFormat;

		public int ChannelCount => _channelCount;

		public int SamplesPerSecond => _samplesPerSecond;

		internal byte[] WaveFormat
		{
			get
			{
				WAVEFORMATEX wAVEFORMATEX = default(WAVEFORMATEX);
				wAVEFORMATEX.wFormatTag = (short)EncodingFormat;
				wAVEFORMATEX.nChannels = (short)ChannelCount;
				wAVEFORMATEX.nSamplesPerSec = SamplesPerSecond;
				wAVEFORMATEX.nAvgBytesPerSec = AverageBytesPerSecond;
				wAVEFORMATEX.nBlockAlign = (short)BlockAlign;
				wAVEFORMATEX.wBitsPerSample = (short)BitsPerSample;
				wAVEFORMATEX.cbSize = (short)FormatSpecificData().Length;
				byte[] array = wAVEFORMATEX.ToBytes();
				if (wAVEFORMATEX.cbSize > 0)
				{
					byte[] array2 = new byte[array.Length + wAVEFORMATEX.cbSize];
					Array.Copy(array, array2, array.Length);
					Array.Copy(FormatSpecificData(), 0, array2, array.Length, wAVEFORMATEX.cbSize);
					array = array2;
				}
				return array;
			}
		}

		private SpeechAudioFormatInfo(EncodingFormat encodingFormat, int samplesPerSecond, short bitsPerSample, short channelCount, byte[] formatSpecificData)
		{
			if (encodingFormat == (EncodingFormat)0)
			{
				throw new ArgumentException(SR.Get(SRID.CannotUseCustomFormat), "encodingFormat");
			}
			if (samplesPerSecond <= 0)
			{
				throw new ArgumentOutOfRangeException("samplesPerSecond", SR.Get(SRID.MustBeGreaterThanZero));
			}
			if (bitsPerSample <= 0)
			{
				throw new ArgumentOutOfRangeException("bitsPerSample", SR.Get(SRID.MustBeGreaterThanZero));
			}
			if (channelCount <= 0)
			{
				throw new ArgumentOutOfRangeException("channelCount", SR.Get(SRID.MustBeGreaterThanZero));
			}
			_encodingFormat = encodingFormat;
			_samplesPerSecond = samplesPerSecond;
			_bitsPerSample = bitsPerSample;
			_channelCount = channelCount;
			if (formatSpecificData == null)
			{
				_formatSpecificData = new byte[0];
			}
			else
			{
				_formatSpecificData = (byte[])formatSpecificData.Clone();
			}
			if ((uint)(encodingFormat - 6) <= 1u)
			{
				if (bitsPerSample != 8)
				{
					throw new ArgumentOutOfRangeException("bitsPerSample");
				}
				if (formatSpecificData != null && formatSpecificData.Length != 0)
				{
					throw new ArgumentOutOfRangeException("formatSpecificData");
				}
			}
		}

		/// <filterpriority>1</filterpriority>
		[EditorBrowsable(EditorBrowsableState.Advanced)]
		public SpeechAudioFormatInfo(EncodingFormat encodingFormat, int samplesPerSecond, int bitsPerSample, int channelCount, int averageBytesPerSecond, int blockAlign, byte[] formatSpecificData)
			: this(encodingFormat, samplesPerSecond, (short)bitsPerSample, (short)channelCount, formatSpecificData)
		{
			if (averageBytesPerSecond <= 0)
			{
				throw new ArgumentOutOfRangeException("averageBytesPerSecond", SR.Get(SRID.MustBeGreaterThanZero));
			}
			if (blockAlign <= 0)
			{
				throw new ArgumentOutOfRangeException("blockAlign", SR.Get(SRID.MustBeGreaterThanZero));
			}
			_averageBytesPerSecond = averageBytesPerSecond;
			_blockAlign = (short)blockAlign;
		}

		public SpeechAudioFormatInfo(int samplesPerSecond, AudioBitsPerSample bitsPerSample, AudioChannel channel)
			: this(EncodingFormat.Pcm, samplesPerSecond, (short)bitsPerSample, (short)channel, null)
		{
			_blockAlign = (short)(_channelCount * (_bitsPerSample / 8));
			_averageBytesPerSecond = _samplesPerSecond * _blockAlign;
		}

		/// <filterpriority>2</filterpriority>
		public byte[] FormatSpecificData()
		{
			return (byte[])_formatSpecificData.Clone();
		}

		public override bool Equals(object obj)
		{
			SpeechAudioFormatInfo speechAudioFormatInfo = obj as SpeechAudioFormatInfo;
			if (speechAudioFormatInfo == null)
			{
				return false;
			}
			if (!_averageBytesPerSecond.Equals(speechAudioFormatInfo._averageBytesPerSecond) || !_bitsPerSample.Equals(speechAudioFormatInfo._bitsPerSample) || !_blockAlign.Equals(speechAudioFormatInfo._blockAlign) || !_encodingFormat.Equals(speechAudioFormatInfo._encodingFormat) || !_channelCount.Equals(speechAudioFormatInfo._channelCount) || !_samplesPerSecond.Equals(speechAudioFormatInfo._samplesPerSecond))
			{
				return false;
			}
			if (_formatSpecificData.Length != speechAudioFormatInfo._formatSpecificData.Length)
			{
				return false;
			}
			for (int i = 0; i < _formatSpecificData.Length; i++)
			{
				if (_formatSpecificData[i] != speechAudioFormatInfo._formatSpecificData[i])
				{
					return false;
				}
			}
			return true;
		}

		/// <filterpriority>2</filterpriority>
		public override int GetHashCode()
		{
			return _averageBytesPerSecond.GetHashCode();
		}
	}
}
