#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license or other governing licenses that can be found in the LICENSE.md file or at
 * https://raw.githubusercontent.com/Krypton-Suite/Extended-Toolkit/master/LICENSE
 */
#endregion

using Krypton.Toolkit.Suite.Extended.Utilities.System.AudioFormat;
using Krypton.Toolkit.Suite.Extended.Utilities.System.Synthesis;
using Krypton.Toolkit.Suite.Extended.Utilities.SystemInternal.Speech;

namespace Krypton.Toolkit.Suite.Extended.Utilities.System.SAPIInterop
{
    internal class SpAudioStreamWrapper : SpStreamWrapper, ISpStreamFormat, IStream
    {
        private struct RIFFHDR
        {
            internal uint _id;

            internal int _len;

            internal uint _type;
        }

        private struct BLOCKHDR
        {
            internal uint _id;

            internal int _len;
        }

        private struct DATAHDR
        {
            internal uint _id;

            internal int _len;
        }

        private const uint RIFF_MARKER = 1179011410u;

        private const uint WAVE_MARKER = 1163280727u;

        private const uint FMT_MARKER = 544501094u;

        private const uint DATA_MARKER = 1635017060u;

        private byte[] _wfx;

        private Guid _formatType;

        internal SpAudioStreamWrapper(Stream stream, SpeechAudioFormatInfo audioFormat)
            : base(stream)
        {
            _formatType = SAPIGuids.SPDFID_WaveFormatEx;
            if (audioFormat != null)
            {
                WAVEFORMATEX wAVEFORMATEX = new WAVEFORMATEX
                {
                    wFormatTag = (short)audioFormat.EncodingFormat,
                    nChannels = (short)audioFormat.ChannelCount,
                    nSamplesPerSec = audioFormat.SamplesPerSecond,
                    nAvgBytesPerSec = audioFormat.AverageBytesPerSecond,
                    nBlockAlign = (short)audioFormat.BlockAlign,
                    wBitsPerSample = (short)audioFormat.BitsPerSample,
                    cbSize = (short)audioFormat.FormatSpecificData().Length
                };
                _wfx = wAVEFORMATEX.ToBytes();
                if (wAVEFORMATEX.cbSize == 0)
                {
                    byte[] array = new byte[_wfx.Length + wAVEFORMATEX.cbSize];
                    Array.Copy(_wfx, array, _wfx.Length);
                    Array.Copy(audioFormat.FormatSpecificData(), 0, array, _wfx.Length, wAVEFORMATEX.cbSize);
                    _wfx = array;
                }
            }
            else
            {
                try
                {
                    GetStreamOffsets(stream);
                }
                catch (IOException)
                {
                    throw new FormatException(SR.Get(SRID.SynthesizerInvalidWaveFile));
                }
            }
        }

        void ISpStreamFormat.GetFormat(out Guid guid, out IntPtr format)
        {
            guid = _formatType;
            format = Marshal.AllocCoTaskMem(_wfx.Length);
            Marshal.Copy(_wfx, 0, format, _wfx.Length);
        }

        internal void GetStreamOffsets(Stream stream)
        {
            BinaryReader binaryReader = new BinaryReader(stream);
            RIFFHDR rIFFHDR = default(RIFFHDR);
            rIFFHDR._id = binaryReader.ReadUInt32();
            rIFFHDR._len = binaryReader.ReadInt32();
            rIFFHDR._type = binaryReader.ReadUInt32();
            if (rIFFHDR._id != 1179011410 && rIFFHDR._type != 1163280727)
            {
                throw new FormatException();
            }
            BLOCKHDR bLOCKHDR = default(BLOCKHDR);
            bLOCKHDR._id = binaryReader.ReadUInt32();
            bLOCKHDR._len = binaryReader.ReadInt32();
            if (bLOCKHDR._id != 544501094)
            {
                throw new FormatException();
            }
            _wfx = binaryReader.ReadBytes(bLOCKHDR._len);
            if (bLOCKHDR._len == 16)
            {
                byte[] array = new byte[18];
                Array.Copy(_wfx, array, 16);
                _wfx = array;
            }
            DATAHDR dATAHDR;
            while (true)
            {
                dATAHDR = default(DATAHDR);
                if (stream.Position + 8 < stream.Length)
                {
                    dATAHDR._id = binaryReader.ReadUInt32();
                    dATAHDR._len = binaryReader.ReadInt32();
                    if (dATAHDR._id == 1635017060)
                    {
                        break;
                    }
                    stream.Seek(dATAHDR._len, SeekOrigin.Current);
                    continue;
                }
                return;
            }
            _endOfStreamPosition = stream.Position + dATAHDR._len;
        }
    }
}