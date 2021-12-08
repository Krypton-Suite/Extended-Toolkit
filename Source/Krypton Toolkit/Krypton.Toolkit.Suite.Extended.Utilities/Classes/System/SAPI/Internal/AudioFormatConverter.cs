#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license or other governing licenses that can be found in the LICENSE.md file or at
 * https://raw.githubusercontent.com/Krypton-Suite/Extended-Toolkit/master/LICENSE
 */
#endregion

using Krypton.Toolkit.Suite.Extended.Utilities.System.AudioFormat;

namespace Krypton.Toolkit.Suite.Extended.Utilities.System.Internal
{
    internal static class AudioFormatConverter
    {
        private enum StreamFormat
        {
            Default = -1,
            NoAssignedFormat,
            Text,
            NonStandardFormat,
            ExtendedAudioFormat,
            PCM_8kHz8BitMono,
            PCM_8kHz8BitStereo,
            PCM_8kHz16BitMono,
            PCM_8kHz16BitStereo,
            PCM_11kHz8BitMono,
            PCM_11kHz8BitStereo,
            PCM_11kHz16BitMono,
            PCM_11kHz16BitStereo,
            PCM_12kHz8BitMono,
            PCM_12kHz8BitStereo,
            PCM_12kHz16BitMono,
            PCM_12kHz16BitStereo,
            PCM_16kHz8BitMono,
            PCM_16kHz8BitStereo,
            PCM_16kHz16BitMono,
            PCM_16kHz16BitStereo,
            PCM_22kHz8BitMono,
            PCM_22kHz8BitStereo,
            PCM_22kHz16BitMono,
            PCM_22kHz16BitStereo,
            PCM_24kHz8BitMono,
            PCM_24kHz8BitStereo,
            PCM_24kHz16BitMono,
            PCM_24kHz16BitStereo,
            PCM_32kHz8BitMono,
            PCM_32kHz8BitStereo,
            PCM_32kHz16BitMono,
            PCM_32kHz16BitStereo,
            PCM_44kHz8BitMono,
            PCM_44kHz8BitStereo,
            PCM_44kHz16BitMono,
            PCM_44kHz16BitStereo,
            PCM_48kHz8BitMono,
            PCM_48kHz8BitStereo,
            PCM_48kHz16BitMono,
            PCM_48kHz16BitStereo,
            TrueSpeech_8kHz1BitMono,
            CCITT_ALaw_8kHzMono,
            CCITT_ALaw_8kHzStereo,
            CCITT_ALaw_11kHzMono,
            CCITT_ALaw_11kHzStereo,
            CCITT_ALaw_22kHzMono,
            CCITT_ALaw_22kHzStereo,
            CCITT_ALaw_44kHzMono,
            CCITT_ALaw_44kHzStereo,
            CCITT_uLaw_8kHzMono,
            CCITT_uLaw_8kHzStereo,
            CCITT_uLaw_11kHzMono,
            CCITT_uLaw_11kHzStereo,
            CCITT_uLaw_22kHzMono,
            CCITT_uLaw_22kHzStereo,
            CCITT_uLaw_44kHzMono,
            CCITT_uLaw_44kHzStereo,
            ADPCM_8kHzMono,
            ADPCM_8kHzStereo,
            ADPCM_11kHzMono,
            ADPCM_11kHzStereo,
            ADPCM_22kHzMono,
            ADPCM_22kHzStereo,
            ADPCM_44kHzMono,
            ADPCM_44kHzStereo,
            GSM610_8kHzMono,
            GSM610_11kHzMono,
            GSM610_22kHzMono,
            GSM610_44kHzMono,
            NUM_FORMATS
        }

        private enum WaveFormatId
        {
            Pcm = 1,
            AdPcm = 2,
            TrueSpeech = 34,
            Alaw = 6,
            Mulaw = 7,
            Gsm610 = 49
        }

        [StructLayout(LayoutKind.Sequential)]
        private class WaveFormatEx
        {
            public ushort wFormatTag;

            public ushort nChannels;

            public uint nSamplesPerSec;

            public uint nAvgBytesPerSec;

            public ushort nBlockAlign;

            public ushort wBitsPerSample;

            public ushort cbSize;
        }

        internal static SpeechAudioFormatInfo ToSpeechAudioFormatInfo(IntPtr waveFormatPtr)
        {
            WaveFormatEx waveFormatEx = (WaveFormatEx)Marshal.PtrToStructure(waveFormatPtr, typeof(WaveFormatEx));
            byte[] array = new byte[waveFormatEx.cbSize];
            IntPtr ptr = new IntPtr(waveFormatPtr.ToInt64() + Marshal.SizeOf((object)waveFormatEx));
            for (int i = 0; i < waveFormatEx.cbSize; i++)
            {
                array[i] = Marshal.ReadByte(ptr, i);
            }
            return new SpeechAudioFormatInfo((EncodingFormat)waveFormatEx.wFormatTag, (int)waveFormatEx.nSamplesPerSec, (short)waveFormatEx.wBitsPerSample, (short)waveFormatEx.nChannels, (int)waveFormatEx.nAvgBytesPerSec, (short)waveFormatEx.nBlockAlign, array);
        }

        internal static SpeechAudioFormatInfo ToSpeechAudioFormatInfo(string formatString)
        {
            short result;
            if (short.TryParse(formatString, NumberStyles.None, CultureInfo.InvariantCulture, out result))
            {
                return ConvertFormat((StreamFormat)result);
            }
            return null;
        }

        private static SpeechAudioFormatInfo ConvertFormat(StreamFormat eFormat)
        {
            WaveFormatEx waveFormatEx = new WaveFormatEx();
            byte[] array = null;
            if (eFormat >= StreamFormat.PCM_8kHz8BitMono && eFormat <= StreamFormat.PCM_48kHz16BitStereo)
            {
                uint num = (uint)(eFormat - 4);
                bool flag = (num & 1) != 0;
                bool flag2 = (num & 2) != 0;
                uint num2 = (num & 0x3C) >> 2;
                uint[] array2 = new uint[9]
                {
                    8000u,
                    11025u,
                    12000u,
                    16000u,
                    22050u,
                    24000u,
                    32000u,
                    44100u,
                    48000u
                };
                waveFormatEx.wFormatTag = 1;
                waveFormatEx.nChannels = (waveFormatEx.nBlockAlign = (ushort)((!flag) ? 1 : 2));
                waveFormatEx.nSamplesPerSec = array2[num2];
                waveFormatEx.wBitsPerSample = 8;
                if (flag2)
                {
                    waveFormatEx.wBitsPerSample *= 2;
                    waveFormatEx.nBlockAlign *= 2;
                }
                waveFormatEx.nAvgBytesPerSec = waveFormatEx.nSamplesPerSec * waveFormatEx.nBlockAlign;
            }
            else
            {
                switch (eFormat)
                {
                    case StreamFormat.TrueSpeech_8kHz1BitMono:
                        waveFormatEx.wFormatTag = 34;
                        waveFormatEx.nChannels = 1;
                        waveFormatEx.nSamplesPerSec = 8000u;
                        waveFormatEx.nAvgBytesPerSec = 1067u;
                        waveFormatEx.nBlockAlign = 32;
                        waveFormatEx.wBitsPerSample = 1;
                        waveFormatEx.cbSize = 32;
                        array = new byte[32];
                        array[0] = 1;
                        array[2] = 240;
                        break;
                    case StreamFormat.CCITT_ALaw_8kHzMono:
                    case StreamFormat.CCITT_ALaw_8kHzStereo:
                    case StreamFormat.CCITT_ALaw_11kHzMono:
                    case StreamFormat.CCITT_ALaw_11kHzStereo:
                    case StreamFormat.CCITT_ALaw_22kHzMono:
                    case StreamFormat.CCITT_ALaw_22kHzStereo:
                    case StreamFormat.CCITT_ALaw_44kHzMono:
                    case StreamFormat.CCITT_ALaw_44kHzStereo:
                        {
                            uint num8 = (uint)(eFormat - 41);
                            uint num9 = num8 / 2u;
                            uint[] array13 = new uint[4]
                            {
                        8000u,
                        11025u,
                        22050u,
                        44100u
                            };
                            bool flag5 = (num8 & 1) != 0;
                            waveFormatEx.wFormatTag = 6;
                            waveFormatEx.nChannels = (waveFormatEx.nBlockAlign = (ushort)((!flag5) ? 1 : 2));
                            waveFormatEx.nSamplesPerSec = array13[num9];
                            waveFormatEx.wBitsPerSample = 8;
                            waveFormatEx.nAvgBytesPerSec = waveFormatEx.nSamplesPerSec * waveFormatEx.nBlockAlign;
                            break;
                        }
                    default:
                        if (eFormat >= StreamFormat.CCITT_uLaw_8kHzMono && eFormat <= StreamFormat.CCITT_uLaw_44kHzStereo)
                        {
                            uint num3 = (uint)(eFormat - 49);
                            uint num4 = num3 / 2u;
                            uint[] array3 = new uint[4]
                            {
                            8000u,
                            11025u,
                            22050u,
                            44100u
                            };
                            bool flag3 = (num3 & 1) != 0;
                            waveFormatEx.wFormatTag = 7;
                            waveFormatEx.nChannels = (waveFormatEx.nBlockAlign = (ushort)((!flag3) ? 1 : 2));
                            waveFormatEx.nSamplesPerSec = array3[num4];
                            waveFormatEx.wBitsPerSample = 8;
                            waveFormatEx.nAvgBytesPerSec = waveFormatEx.nSamplesPerSec * waveFormatEx.nBlockAlign;
                        }
                        else if (eFormat >= StreamFormat.ADPCM_8kHzMono && eFormat <= StreamFormat.ADPCM_44kHzStereo)
                        {
                            uint[] array4 = new uint[4]
                            {
                            8000u,
                            11025u,
                            22050u,
                            44100u
                            };
                            uint[] array5 = new uint[8]
                            {
                            4096u,
                            8192u,
                            5644u,
                            11289u,
                            11155u,
                            22311u,
                            22179u,
                            44359u
                            };
                            uint[] array6 = new uint[4]
                            {
                            256u,
                            256u,
                            512u,
                            1024u
                            };
                            byte[] array7 = new byte[32]
                            {
                            244,
                            1,
                            7,
                            0,
                            0,
                            1,
                            0,
                            0,
                            0,
                            2,
                            0,
                            255,
                            0,
                            0,
                            0,
                            0,
                            192,
                            0,
                            64,
                            0,
                            240,
                            0,
                            0,
                            0,
                            204,
                            1,
                            48,
                            255,
                            136,
                            1,
                            24,
                            255
                            };
                            byte[] array8 = new byte[32]
                            {
                            244,
                            3,
                            7,
                            0,
                            0,
                            1,
                            0,
                            0,
                            0,
                            2,
                            0,
                            255,
                            0,
                            0,
                            0,
                            0,
                            192,
                            0,
                            64,
                            0,
                            240,
                            0,
                            0,
                            0,
                            204,
                            1,
                            48,
                            255,
                            136,
                            1,
                            24,
                            255
                            };
                            byte[] array9 = new byte[32]
                            {
                            244,
                            7,
                            7,
                            0,
                            0,
                            1,
                            0,
                            0,
                            0,
                            2,
                            0,
                            255,
                            0,
                            0,
                            0,
                            0,
                            192,
                            0,
                            64,
                            0,
                            240,
                            0,
                            0,
                            0,
                            204,
                            1,
                            48,
                            255,
                            136,
                            1,
                            24,
                            255
                            };
                            byte[][] array10 = new byte[4][]
                            {
                            array7,
                            array7,
                            array8,
                            array9
                            };
                            uint num5 = (uint)(eFormat - 57);
                            uint num6 = num5 / 2u;
                            bool flag4 = (num5 & 1) != 0;
                            waveFormatEx.wFormatTag = 2;
                            waveFormatEx.nChannels = (ushort)((!flag4) ? 1 : 2);
                            waveFormatEx.nSamplesPerSec = array4[num6];
                            waveFormatEx.nAvgBytesPerSec = array5[num5];
                            waveFormatEx.nBlockAlign = (ushort)(array6[num6] * waveFormatEx.nChannels);
                            waveFormatEx.wBitsPerSample = 4;
                            waveFormatEx.cbSize = 32;
                            array = (byte[])array10[num6].Clone();
                        }
                        else if (eFormat >= StreamFormat.GSM610_8kHzMono && eFormat <= StreamFormat.GSM610_44kHzMono)
                        {
                            uint[] array11 = new uint[4]
                            {
                            8000u,
                            11025u,
                            22050u,
                            44100u
                            };
                            uint[] array12 = new uint[4]
                            {
                            1625u,
                            2239u,
                            4478u,
                            8957u
                            };
                            uint num7 = (uint)(eFormat - 65);
                            waveFormatEx.wFormatTag = 49;
                            waveFormatEx.nChannels = 1;
                            waveFormatEx.nSamplesPerSec = array11[num7];
                            waveFormatEx.nAvgBytesPerSec = array12[num7];
                            waveFormatEx.nBlockAlign = 65;
                            waveFormatEx.wBitsPerSample = 0;
                            waveFormatEx.cbSize = 2;
                            array = new byte[2]
                            {
                            64,
                            1
                            };
                        }
                        else
                        {
                            waveFormatEx = null;
                            if (eFormat != 0 && eFormat != StreamFormat.Text)
                            {
                                throw new FormatException();
                            }
                        }
                        break;
                }
            }
            if (waveFormatEx == null)
            {
                return null;
            }
            return new SpeechAudioFormatInfo((EncodingFormat)waveFormatEx.wFormatTag, (int)waveFormatEx.nSamplesPerSec, waveFormatEx.wBitsPerSample, waveFormatEx.nChannels, (int)waveFormatEx.nAvgBytesPerSec, waveFormatEx.nBlockAlign, array);
        }
    }
}