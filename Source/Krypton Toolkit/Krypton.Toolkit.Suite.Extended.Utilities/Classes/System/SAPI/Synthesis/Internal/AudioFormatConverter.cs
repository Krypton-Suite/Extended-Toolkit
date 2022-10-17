#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license or other governing licenses that can be found in the LICENSE.md file or at
 * https://raw.githubusercontent.com/Krypton-Suite/Extended-Toolkit/master/LICENSE
 */
#endregion

namespace Krypton.Toolkit.Suite.Extended.Utilities.System.Synthesis
{
    internal static class AudioFormatConverter
    {
        internal enum WaveFormatTag
        {
            WAVE_FORMAT_PCM = 1,
            WAVE_FORMAT_ALAW = 6,
            WAVE_FORMAT_MULAW = 7
        }

        private delegate short[] ConvertByteShort(byte[] data, int size);

        private delegate byte[] ConvertShortByte(short[] data, int size);

        private static byte[] _uLawCompTableCached;

        private static byte[] _aLawCompTableCached;

        private static readonly int[] exp_lut_linear2alaw = new int[128]
        {
            1,
            1,
            2,
            2,
            3,
            3,
            3,
            3,
            4,
            4,
            4,
            4,
            4,
            4,
            4,
            4,
            5,
            5,
            5,
            5,
            5,
            5,
            5,
            5,
            5,
            5,
            5,
            5,
            5,
            5,
            5,
            5,
            6,
            6,
            6,
            6,
            6,
            6,
            6,
            6,
            6,
            6,
            6,
            6,
            6,
            6,
            6,
            6,
            6,
            6,
            6,
            6,
            6,
            6,
            6,
            6,
            6,
            6,
            6,
            6,
            6,
            6,
            6,
            6,
            7,
            7,
            7,
            7,
            7,
            7,
            7,
            7,
            7,
            7,
            7,
            7,
            7,
            7,
            7,
            7,
            7,
            7,
            7,
            7,
            7,
            7,
            7,
            7,
            7,
            7,
            7,
            7,
            7,
            7,
            7,
            7,
            7,
            7,
            7,
            7,
            7,
            7,
            7,
            7,
            7,
            7,
            7,
            7,
            7,
            7,
            7,
            7,
            7,
            7,
            7,
            7,
            7,
            7,
            7,
            7,
            7,
            7,
            7,
            7,
            7,
            7,
            7,
            7
        };

        private static int[] exp_lut_linear2ulaw = new int[256]
        {
            0,
            0,
            1,
            1,
            2,
            2,
            2,
            2,
            3,
            3,
            3,
            3,
            3,
            3,
            3,
            3,
            4,
            4,
            4,
            4,
            4,
            4,
            4,
            4,
            4,
            4,
            4,
            4,
            4,
            4,
            4,
            4,
            5,
            5,
            5,
            5,
            5,
            5,
            5,
            5,
            5,
            5,
            5,
            5,
            5,
            5,
            5,
            5,
            5,
            5,
            5,
            5,
            5,
            5,
            5,
            5,
            5,
            5,
            5,
            5,
            5,
            5,
            5,
            5,
            6,
            6,
            6,
            6,
            6,
            6,
            6,
            6,
            6,
            6,
            6,
            6,
            6,
            6,
            6,
            6,
            6,
            6,
            6,
            6,
            6,
            6,
            6,
            6,
            6,
            6,
            6,
            6,
            6,
            6,
            6,
            6,
            6,
            6,
            6,
            6,
            6,
            6,
            6,
            6,
            6,
            6,
            6,
            6,
            6,
            6,
            6,
            6,
            6,
            6,
            6,
            6,
            6,
            6,
            6,
            6,
            6,
            6,
            6,
            6,
            6,
            6,
            6,
            6,
            7,
            7,
            7,
            7,
            7,
            7,
            7,
            7,
            7,
            7,
            7,
            7,
            7,
            7,
            7,
            7,
            7,
            7,
            7,
            7,
            7,
            7,
            7,
            7,
            7,
            7,
            7,
            7,
            7,
            7,
            7,
            7,
            7,
            7,
            7,
            7,
            7,
            7,
            7,
            7,
            7,
            7,
            7,
            7,
            7,
            7,
            7,
            7,
            7,
            7,
            7,
            7,
            7,
            7,
            7,
            7,
            7,
            7,
            7,
            7,
            7,
            7,
            7,
            7,
            7,
            7,
            7,
            7,
            7,
            7,
            7,
            7,
            7,
            7,
            7,
            7,
            7,
            7,
            7,
            7,
            7,
            7,
            7,
            7,
            7,
            7,
            7,
            7,
            7,
            7,
            7,
            7,
            7,
            7,
            7,
            7,
            7,
            7,
            7,
            7,
            7,
            7,
            7,
            7,
            7,
            7,
            7,
            7,
            7,
            7,
            7,
            7,
            7,
            7,
            7,
            7,
            7,
            7,
            7,
            7,
            7,
            7,
            7,
            7,
            7,
            7,
            7,
            7
        };

        private static int[] ULaw_exp_table = new int[256]
        {
            -32124,
            -31100,
            -30076,
            -29052,
            -28028,
            -27004,
            -25980,
            -24956,
            -23932,
            -22908,
            -21884,
            -20860,
            -19836,
            -18812,
            -17788,
            -16764,
            -15996,
            -15484,
            -14972,
            -14460,
            -13948,
            -13436,
            -12924,
            -12412,
            -11900,
            -11388,
            -10876,
            -10364,
            -9852,
            -9340,
            -8828,
            -8316,
            -7932,
            -7676,
            -7420,
            -7164,
            -6908,
            -6652,
            -6396,
            -6140,
            -5884,
            -5628,
            -5372,
            -5116,
            -4860,
            -4604,
            -4348,
            -4092,
            -3900,
            -3772,
            -3644,
            -3516,
            -3388,
            -3260,
            -3132,
            -3004,
            -2876,
            -2748,
            -2620,
            -2492,
            -2364,
            -2236,
            -2108,
            -1980,
            -1884,
            -1820,
            -1756,
            -1692,
            -1628,
            -1564,
            -1500,
            -1436,
            -1372,
            -1308,
            -1244,
            -1180,
            -1116,
            -1052,
            -988,
            -924,
            -876,
            -844,
            -812,
            -780,
            -748,
            -716,
            -684,
            -652,
            -620,
            -588,
            -556,
            -524,
            -492,
            -460,
            -428,
            -396,
            -372,
            -356,
            -340,
            -324,
            -308,
            -292,
            -276,
            -260,
            -244,
            -228,
            -212,
            -196,
            -180,
            -164,
            -148,
            -132,
            -120,
            -112,
            -104,
            -96,
            -88,
            -80,
            -72,
            -64,
            -56,
            -48,
            -40,
            -32,
            -24,
            -16,
            -8,
            0,
            32124,
            31100,
            30076,
            29052,
            28028,
            27004,
            25980,
            24956,
            23932,
            22908,
            21884,
            20860,
            19836,
            18812,
            17788,
            16764,
            15996,
            15484,
            14972,
            14460,
            13948,
            13436,
            12924,
            12412,
            11900,
            11388,
            10876,
            10364,
            9852,
            9340,
            8828,
            8316,
            7932,
            7676,
            7420,
            7164,
            6908,
            6652,
            6396,
            6140,
            5884,
            5628,
            5372,
            5116,
            4860,
            4604,
            4348,
            4092,
            3900,
            3772,
            3644,
            3516,
            3388,
            3260,
            3132,
            3004,
            2876,
            2748,
            2620,
            2492,
            2364,
            2236,
            2108,
            1980,
            1884,
            1820,
            1756,
            1692,
            1628,
            1564,
            1500,
            1436,
            1372,
            1308,
            1244,
            1180,
            1116,
            1052,
            988,
            924,
            876,
            844,
            812,
            780,
            748,
            716,
            684,
            652,
            620,
            588,
            556,
            524,
            492,
            460,
            428,
            396,
            372,
            356,
            340,
            324,
            308,
            292,
            276,
            260,
            244,
            228,
            212,
            196,
            180,
            164,
            148,
            132,
            120,
            112,
            104,
            96,
            88,
            80,
            72,
            64,
            56,
            48,
            40,
            32,
            24,
            16,
            8,
            0
        };

        private static int[] ALaw_exp_table = new int[256]
        {
            -5504,
            -5248,
            -6016,
            -5760,
            -4480,
            -4224,
            -4992,
            -4736,
            -7552,
            -7296,
            -8064,
            -7808,
            -6528,
            -6272,
            -7040,
            -6784,
            -2752,
            -2624,
            -3008,
            -2880,
            -2240,
            -2112,
            -2496,
            -2368,
            -3776,
            -3648,
            -4032,
            -3904,
            -3264,
            -3136,
            -3520,
            -3392,
            -22016,
            -20992,
            -24064,
            -23040,
            -17920,
            -16896,
            -19968,
            -18944,
            -30208,
            -29184,
            -32256,
            -31232,
            -26112,
            -25088,
            -28160,
            -27136,
            -11008,
            -10496,
            -12032,
            -11520,
            -8960,
            -8448,
            -9984,
            -9472,
            -15104,
            -14592,
            -16128,
            -15616,
            -13056,
            -12544,
            -14080,
            -13568,
            -344,
            -328,
            -376,
            -360,
            -280,
            -264,
            -312,
            -296,
            -472,
            -456,
            -504,
            -488,
            -408,
            -392,
            -440,
            -424,
            -88,
            -72,
            -120,
            -104,
            -24,
            -8,
            -56,
            -40,
            -216,
            -200,
            -248,
            -232,
            -152,
            -136,
            -184,
            -168,
            -1376,
            -1312,
            -1504,
            -1440,
            -1120,
            -1056,
            -1248,
            -1184,
            -1888,
            -1824,
            -2016,
            -1952,
            -1632,
            -1568,
            -1760,
            -1696,
            -688,
            -656,
            -752,
            -720,
            -560,
            -528,
            -624,
            -592,
            -944,
            -912,
            -1008,
            -976,
            -816,
            -784,
            -880,
            -848,
            5504,
            5248,
            6016,
            5760,
            4480,
            4224,
            4992,
            4736,
            7552,
            7296,
            8064,
            7808,
            6528,
            6272,
            7040,
            6784,
            2752,
            2624,
            3008,
            2880,
            2240,
            2112,
            2496,
            2368,
            3776,
            3648,
            4032,
            3904,
            3264,
            3136,
            3520,
            3392,
            22016,
            20992,
            24064,
            23040,
            17920,
            16896,
            19968,
            18944,
            30208,
            29184,
            32256,
            31232,
            26112,
            25088,
            28160,
            27136,
            11008,
            10496,
            12032,
            11520,
            8960,
            8448,
            9984,
            9472,
            15104,
            14592,
            16128,
            15616,
            13056,
            12544,
            14080,
            13568,
            344,
            328,
            376,
            360,
            280,
            264,
            312,
            296,
            472,
            456,
            504,
            488,
            408,
            392,
            440,
            424,
            88,
            72,
            120,
            104,
            24,
            8,
            56,
            40,
            216,
            200,
            248,
            232,
            152,
            136,
            184,
            168,
            1376,
            1312,
            1504,
            1440,
            1120,
            1056,
            1248,
            1184,
            1888,
            1824,
            2016,
            1952,
            1632,
            1568,
            1760,
            1696,
            688,
            656,
            752,
            720,
            560,
            528,
            624,
            592,
            944,
            912,
            1008,
            976,
            816,
            784,
            880,
            848
        };

        internal static short[] Convert(byte[] data, AudioCodec from, AudioCodec to)
        {
            ConvertByteShort convertByteShort = null;
            switch (from)
            {
                case AudioCodec.PCM8:
                    if (to == AudioCodec.PCM16)
                    {
                        convertByteShort = ConvertLinear8LinearByteShort;
                    }
                    break;
                case AudioCodec.PCM16:
                    if (to == AudioCodec.PCM16)
                    {
                        convertByteShort = ConvertLinear2LinearByteShort;
                    }
                    break;
                case AudioCodec.G711U:
                    if (to == AudioCodec.PCM16)
                    {
                        convertByteShort = ConvertULaw2Linear;
                    }
                    break;
                case AudioCodec.G711A:
                    if (to == AudioCodec.PCM16)
                    {
                        convertByteShort = ConvertALaw2Linear;
                    }
                    break;
                default:
                    throw new FormatException();
            }
            if (convertByteShort == null)
            {
                throw new FormatException();
            }
            return convertByteShort(data, data.Length);
        }

        internal static byte[] Convert(short[] data, AudioCodec from, AudioCodec to)
        {
            ConvertShortByte convertShortByte = null;
            if (from == AudioCodec.PCM16)
            {
                switch (to)
                {
                    case AudioCodec.PCM8:
                        convertShortByte = ConvertLinear8LinearShortByte;
                        break;
                    case AudioCodec.PCM16:
                        convertShortByte = ConvertLinear2LinearShortByte;
                        break;
                    case AudioCodec.G711U:
                        convertShortByte = ConvertLinear2ULaw;
                        break;
                    case AudioCodec.G711A:
                        convertShortByte = ConvertLinear2ALaw;
                        break;
                }
                return convertShortByte(data, data.Length);
            }
            throw new FormatException();
        }

        internal static AudioCodec TypeOf(WAVEFORMATEX format)
        {
            AudioCodec result = AudioCodec.Undefined;
            switch (format.wFormatTag)
            {
                case 1:
                    switch (format.nBlockAlign / format.nChannels)
                    {
                        case 1:
                            result = AudioCodec.PCM8;
                            break;
                        case 2:
                            result = AudioCodec.PCM16;
                            break;
                    }
                    break;
                case 6:
                    result = AudioCodec.G711A;
                    break;
                case 7:
                    result = AudioCodec.G711U;
                    break;
            }
            return result;
        }

        internal static byte[] ConvertLinear2ULaw(short[] data, int size)
        {
            byte[] array = new byte[size];
            _uLawCompTableCached = ((_uLawCompTableCached == null) ? CalcLinear2ULawTable() : _uLawCompTableCached);
            for (int i = 0; i < size; i++)
            {
                array[i] = _uLawCompTableCached[(ushort)data[i] >> 2];
            }
            return array;
        }

        internal static short[] ConvertULaw2Linear(byte[] data, int size)
        {
            short[] array = new short[size];
            for (int i = 0; i < size; i++)
            {
                int num = ULaw_exp_table[data[i]];
                array[i] = (short)num;
            }
            return array;
        }

        private static byte[] CalcLinear2ULawTable()
        {
            bool flag = false;
            byte[] array = new byte[16384];
            for (int i = 0; i < 65535; i += 4)
            {
                short num = (short)i;
                int num2 = num >> 2 << 2;
                int num3 = (num2 >> 8) & 0x80;
                if (num3 != 0)
                {
                    num2 = -num2;
                }
                if (num2 > 32635)
                {
                    num2 = 32635;
                }
                num2 += 132;
                int num4 = exp_lut_linear2ulaw[(num2 >> 7) & 0xFF];
                int num5 = (num2 >> num4 + 3) & 0xF;
                byte b = (byte)(~(num3 | (num4 << 4) | num5));
                if (flag && b == 0)
                {
                    b = 2;
                }
                array[i >> 2] = b;
            }
            return array;
        }

        internal static byte[] ConvertLinear2ALaw(short[] data, int size)
        {
            byte[] array = new byte[size];
            _aLawCompTableCached = ((_aLawCompTableCached == null) ? CalcLinear2ALawTable() : _aLawCompTableCached);
            for (int i = 0; i < size; i++)
            {
                array[i] = _aLawCompTableCached[(ushort)data[i] >> 2];
            }
            return array;
        }

        internal static short[] ConvertALaw2Linear(byte[] data, int size)
        {
            short[] array = new short[size];
            for (int i = 0; i < size; i++)
            {
                int num = ALaw_exp_table[data[i]];
                array[i] = (short)num;
            }
            return array;
        }

        private static byte[] CalcLinear2ALawTable()
        {
            byte[] array = new byte[16384];
            for (int i = 0; i < 65535; i += 4)
            {
                short num = (short)i;
                int num2 = num >> 2 << 2;
                int num3 = (~num2 >> 8) & 0x80;
                if (num3 == 0)
                {
                    num2 = -num2;
                }
                if (num2 > 31744)
                {
                    num2 = 31744;
                }
                byte b;
                if (num2 >= 256)
                {
                    int num4 = exp_lut_linear2alaw[(num2 >> 8) & 0x7F];
                    int num5 = (num2 >> num4 + 3) & 0xF;
                    b = (byte)((num4 << 4) | num5);
                }
                else
                {
                    b = (byte)(num2 >> 4);
                }
                b = (array[i >> 2] = (byte)(b ^ (byte)(num3 ^ 0x55)));
            }
            return array;
        }

        private static short[] ConvertLinear2LinearByteShort(byte[] data, int size)
        {
            short[] array = new short[size / 2];
            for (int i = 0; i < size; i += 2)
            {
                array[i / 2] = (short)(data[i] + (short)(data[i + 1] << 8));
            }
            return array;
        }

        private static short[] ConvertLinear8LinearByteShort(byte[] data, int size)
        {
            short[] array = new short[size];
            for (int i = 0; i < size; i++)
            {
                array[i] = (short)(data[i] - 128 << 8);
            }
            return array;
        }

        private static byte[] ConvertLinear2LinearShortByte(short[] data, int size)
        {
            byte[] array = new byte[size * 2];
            for (int i = 0; i < size; i++)
            {
                short num = data[i];
                array[2 * i] = (byte)num;
                array[2 * i + 1] = (byte)(num >> 8);
            }
            return array;
        }

        private static byte[] ConvertLinear8LinearShortByte(short[] data, int size)
        {
            byte[] array = new byte[size];
            for (int i = 0; i < size; i++)
            {
                array[i] = (byte)((ushort)(data[i] + 127 >> 8) + 128);
            }
            return array;
        }
    }
}