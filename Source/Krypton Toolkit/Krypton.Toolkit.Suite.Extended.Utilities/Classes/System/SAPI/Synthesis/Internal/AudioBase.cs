#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license or other governing licenses that can be found in the LICENSE.md file or at
 * https://raw.githubusercontent.com/Krypton-Suite/Extended-Toolkit/master/LICENSE
 */
#endregion

using Krypton.Toolkit.Suite.Extended.Utilities.System.Internal;
using Krypton.Toolkit.Suite.Extended.Utilities.SystemInternal.Speech;

namespace Krypton.Toolkit.Suite.Extended.Utilities.System.Synthesis
{
    internal abstract class AudioBase
    {
        private struct RIFFHDR
        {
            internal uint _id;

            internal int _len;

            internal uint _type;

            internal RIFFHDR(int length)
            {
                _id = 1179011410u;
                _type = 1163280727u;
                _len = length;
            }
        }

        private struct BLOCKHDR
        {
            internal uint _id;

            internal int _len;

            internal BLOCKHDR(int length)
            {
                _id = 544501094u;
                _len = length;
            }
        }

        private struct DATAHDR
        {
            internal uint _id;

            internal int _len;

            internal DATAHDR(int length)
            {
                _id = 1635017060u;
                _len = length;
            }
        }

        protected bool _aborted;

        private const uint RIFF_MARKER = 1179011410u;

        private const uint WAVE_MARKER = 1163280727u;

        private const uint FMT_MARKER = 544501094u;

        private const uint DATA_MARKER = 1635017060u;

        internal abstract TimeSpan Duration
        {
            get;
        }

        internal virtual long Position => 0L;

        internal virtual bool IsAborted
        {
            get
            {
                return _aborted;
            }
            set
            {
                _aborted = false;
            }
        }

        internal virtual byte[] WaveFormat => null;

        internal AudioBase()
        {
        }

        internal abstract void Begin(byte[] wfx);

        internal abstract void End();

        internal virtual void Play(IntPtr pBuff, int cb)
        {
            byte[] array = new byte[cb];
            Marshal.Copy(pBuff, array, 0, cb);
            Play(array);
        }

        internal virtual void Play(byte[] buffer)
        {
            GCHandle gCHandle = GCHandle.Alloc(buffer);
            Play(gCHandle.AddrOfPinnedObject(), buffer.Length);
            gCHandle.Free();
        }

        internal abstract void Pause();

        internal abstract void Resume();

        internal abstract void InjectEvent(TTSEvent ttsEvent);

        internal abstract void WaitUntilDone();

        internal abstract void Abort();

        internal void PlayWaveFile(AudioData audio)
        {
            try
            {
                if (!string.IsNullOrEmpty(audio._mimeType))
                {
                    WAVEFORMATEX wAVEFORMATEX = default(WAVEFORMATEX);
                    wAVEFORMATEX.nChannels = 1;
                    wAVEFORMATEX.nSamplesPerSec = 8000;
                    wAVEFORMATEX.nAvgBytesPerSec = 8000;
                    wAVEFORMATEX.nBlockAlign = 1;
                    wAVEFORMATEX.wBitsPerSample = 8;
                    wAVEFORMATEX.cbSize = 0;
                    string mimeType = audio._mimeType;
                    if (!(mimeType == "audio/basic"))
                    {
                        if (!(mimeType == "audio/x-alaw-basic"))
                        {
                            throw new FormatException(SR.Get(SRID.UnknownMimeFormat));
                        }
                        wAVEFORMATEX.wFormatTag = 6;
                    }
                    else
                    {
                        wAVEFORMATEX.wFormatTag = 7;
                    }
                    Begin(wAVEFORMATEX.ToBytes());
                    try
                    {
                        byte[] array = new byte[(int)audio._stream.Length];
                        audio._stream.Read(array, 0, array.Length);
                        Play(array);
                    }
                    finally
                    {
                        WaitUntilDone();
                        End();
                    }
                }
                else
                {
                    BinaryReader binaryReader = new BinaryReader(audio._stream);
                    try
                    {
                        byte[] waveFormat = GetWaveFormat(binaryReader);
                        if (waveFormat == null)
                        {
                            throw new FormatException(SR.Get(SRID.NotValidAudioFile, audio._uri.ToString()));
                        }
                        Begin(waveFormat);
                        try
                        {
                            while (true)
                            {
                                DATAHDR dATAHDR = default(DATAHDR);
                                if (audio._stream.Position + 8 >= audio._stream.Length)
                                {
                                    break;
                                }
                                dATAHDR._id = binaryReader.ReadUInt32();
                                dATAHDR._len = binaryReader.ReadInt32();
                                if (dATAHDR._id == 1635017060)
                                {
                                    byte[] buffer = Helpers.ReadStreamToByteArray(audio._stream, dATAHDR._len);
                                    Play(buffer);
                                }
                                else
                                {
                                    audio._stream.Seek(dATAHDR._len, SeekOrigin.Current);
                                }
                            }
                        }
                        finally
                        {
                            WaitUntilDone();
                            End();
                        }
                    }
                    finally
                    {
                        ((IDisposable)binaryReader).Dispose();
                    }
                }
            }
            finally
            {
                audio.Dispose();
            }
        }

        internal static byte[] GetWaveFormat(BinaryReader br)
        {
            RIFFHDR rIFFHDR = default(RIFFHDR);
            rIFFHDR._id = br.ReadUInt32();
            rIFFHDR._len = br.ReadInt32();
            rIFFHDR._type = br.ReadUInt32();
            if (rIFFHDR._id != 1179011410 && rIFFHDR._type != 1163280727)
            {
                return null;
            }
            BLOCKHDR bLOCKHDR = default(BLOCKHDR);
            bLOCKHDR._id = br.ReadUInt32();
            bLOCKHDR._len = br.ReadInt32();
            if (bLOCKHDR._id != 544501094)
            {
                return null;
            }
            byte[] array = br.ReadBytes(bLOCKHDR._len);
            if (bLOCKHDR._len == 16)
            {
                byte[] array2 = new byte[18];
                Array.Copy(array, array2, 16);
                array = array2;
            }
            return array;
        }

        internal static void WriteWaveHeader(Stream stream, WAVEFORMATEX waveEx, long position, int cData)
        {
            RIFFHDR rIFFHDR = new RIFFHDR(0);
            BLOCKHDR bLOCKHDR = new BLOCKHDR(0);
            DATAHDR dATAHDR = new DATAHDR(0);
            int num = Marshal.SizeOf((object)rIFFHDR);
            int num2 = Marshal.SizeOf((object)bLOCKHDR);
            int length = waveEx.Length;
            int num3 = Marshal.SizeOf((object)dATAHDR);
            int num4 = num + num2 + length + num3;
            using (MemoryStream memoryStream = new MemoryStream())
            {
                BinaryWriter binaryWriter = new BinaryWriter(memoryStream);
                try
                {
                    rIFFHDR._len = num4 + cData - 8;
                    binaryWriter.Write(rIFFHDR._id);
                    binaryWriter.Write(rIFFHDR._len);
                    binaryWriter.Write(rIFFHDR._type);
                    bLOCKHDR._len = length;
                    binaryWriter.Write(bLOCKHDR._id);
                    binaryWriter.Write(bLOCKHDR._len);
                    binaryWriter.Write(waveEx.ToBytes());
                    dATAHDR._len = cData;
                    binaryWriter.Write(dATAHDR._id);
                    binaryWriter.Write(dATAHDR._len);
                    stream.Seek(position, SeekOrigin.Begin);
                    stream.Write(memoryStream.GetBuffer(), 0, (int)memoryStream.Length);
                }
                finally
                {
                    ((IDisposable)binaryWriter).Dispose();
                }
            }
        }
    }
}