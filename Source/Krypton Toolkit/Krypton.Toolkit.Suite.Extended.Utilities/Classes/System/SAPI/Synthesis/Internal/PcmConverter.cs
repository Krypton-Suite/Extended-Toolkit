#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license or other governing licenses that can be found in the LICENSE.md file or at
 * https://raw.githubusercontent.com/Krypton-Suite/Extended-Toolkit/master/LICENSE
 */
#endregion

namespace Krypton.Toolkit.Suite.Extended.Utilities.System.Synthesis
{
    internal class PcmConverter
    {
        private enum Block
        {
            First,
            Middle,
            Last
        }

        private WAVEFORMATEX _inWavFormat;

        private WAVEFORMATEX _outWavFormat;

        private AudioCodec _iInFormatType;

        private AudioCodec _iOutFormatType;

        private Block _eChunkStatus;

        private int _iUpFactor;

        private int _iFilterHalf;

        private int _iDownFactor;

        private int _iFilterLen;

        private int _iBuffLen;

        private float[] _filterCoeff;

        private float[] _leftMemory;

        private float[] _rightMemory;

        private const float _dHalfFilterLen = 0.0005f;

        private static readonly int[] piPrimes = new int[12]
        {
            2,
            3,
            5,
            7,
            11,
            13,
            17,
            19,
            23,
            29,
            31,
            37
        };

        internal bool PrepareConverter(ref WAVEFORMATEX inWavFormat, ref WAVEFORMATEX outWavFormat)
        {
            bool result = true;
            if (inWavFormat.nSamplesPerSec <= 0 || inWavFormat.nChannels > 2 || inWavFormat.nChannels <= 0 || outWavFormat.nChannels <= 0 || outWavFormat.nSamplesPerSec <= 0 || outWavFormat.nChannels > 2)
            {
                throw new FormatException();
            }
            _iInFormatType = AudioFormatConverter.TypeOf(inWavFormat);
            _iOutFormatType = AudioFormatConverter.TypeOf(outWavFormat);
            if (_iInFormatType < AudioCodec.G711U || _iOutFormatType < AudioCodec.G711U)
            {
                throw new FormatException();
            }
            if (outWavFormat.nSamplesPerSec == inWavFormat.nSamplesPerSec && _iOutFormatType == _iInFormatType && outWavFormat.nChannels == inWavFormat.nChannels)
            {
                result = false;
            }
            else
            {
                if (inWavFormat.nSamplesPerSec != outWavFormat.nSamplesPerSec)
                {
                    CreateResamplingFilter(inWavFormat.nSamplesPerSec, outWavFormat.nSamplesPerSec);
                }
                _inWavFormat = inWavFormat;
                _outWavFormat = outWavFormat;
            }
            return result;
        }

        internal byte[] ConvertSamples(byte[] pvInSamples)
        {
            short[] data = null;
            short[] array = AudioFormatConverter.Convert(pvInSamples, _iInFormatType, AudioCodec.PCM16);
            if (_inWavFormat.nChannels == 2 && _outWavFormat.nChannels == 1)
            {
                data = Resample(_inWavFormat, _outWavFormat, Stereo2Mono(array), _leftMemory);
            }
            else if (_inWavFormat.nChannels == 1 && _outWavFormat.nChannels == 2)
            {
                data = Mono2Stereo(Resample(_inWavFormat, _outWavFormat, array, _leftMemory));
            }
            if (_inWavFormat.nChannels == 2 && _outWavFormat.nChannels == 2)
            {
                if (_inWavFormat.nSamplesPerSec != _outWavFormat.nSamplesPerSec)
                {
                    short[] leftSamples;
                    short[] rightSamples;
                    SplitStereo(array, out leftSamples, out rightSamples);
                    data = MergeStereo(Resample(_inWavFormat, _outWavFormat, leftSamples, _leftMemory), Resample(_inWavFormat, _outWavFormat, rightSamples, _rightMemory));
                }
                else
                {
                    data = array;
                }
            }
            if (_inWavFormat.nChannels == 1 && _outWavFormat.nChannels == 1)
            {
                data = Resample(_inWavFormat, _outWavFormat, array, _leftMemory);
            }
            _eChunkStatus = Block.Middle;
            return AudioFormatConverter.Convert(data, AudioCodec.PCM16, _iOutFormatType);
        }

        private short[] Resample(WAVEFORMATEX inWavFormat, WAVEFORMATEX outWavFormat, short[] pnBuff, float[] memory)
        {
            if (inWavFormat.nSamplesPerSec != outWavFormat.nSamplesPerSec)
            {
                float[] inSamples = Short2Float(pnBuff);
                inSamples = Resampling(inSamples, memory);
                pnBuff = Float2Short(inSamples);
            }
            return pnBuff;
        }

        private static float[] Short2Float(short[] inSamples)
        {
            float[] array = new float[inSamples.Length];
            for (int i = 0; i < inSamples.Length; i++)
            {
                array[i] = inSamples[i];
            }
            return array;
        }

        private static short[] Float2Short(float[] inSamples)
        {
            short[] array = new short[inSamples.Length];
            for (int i = 0; i < inSamples.Length; i++)
            {
                float num;
                if (inSamples[i] >= 0f)
                {
                    num = inSamples[i] + 0.5f;
                    if (num > 32767f)
                    {
                        num = 32767f;
                    }
                }
                else
                {
                    num = inSamples[i] - 0.5f;
                    if (num < -32768f)
                    {
                        num = -32768f;
                    }
                }
                array[i] = (short)num;
            }
            return array;
        }

        private static short[] Mono2Stereo(short[] inSamples)
        {
            short[] array = new short[inSamples.Length * 2];
            int num = 0;
            int num2 = 0;
            while (num < inSamples.Length)
            {
                array[num2] = inSamples[num];
                array[num2 + 1] = inSamples[num];
                num++;
                num2 += 2;
            }
            return array;
        }

        private static short[] Stereo2Mono(short[] inSamples)
        {
            short[] array = new short[inSamples.Length / 2];
            int num = 0;
            int num2 = 0;
            while (num < inSamples.Length)
            {
                array[num2] = (short)((inSamples[num] + inSamples[num + 1]) / 2);
                num += 2;
                num2++;
            }
            return array;
        }

        private static short[] MergeStereo(short[] leftSamples, short[] rightSamples)
        {
            short[] array = new short[leftSamples.Length * 2];
            int num = 0;
            int num2 = 0;
            while (num < leftSamples.Length)
            {
                array[num2] = leftSamples[num];
                array[num2 + 1] = rightSamples[num];
                num++;
                num2 += 2;
            }
            return array;
        }

        private static void SplitStereo(short[] inSamples, out short[] leftSamples, out short[] rightSamples)
        {
            int num = inSamples.Length / 2;
            leftSamples = new short[num];
            rightSamples = new short[num];
            int i = 0;
            int num2 = 0;
            for (; i < inSamples.Length; i += 2)
            {
                leftSamples[num2] = inSamples[i];
                rightSamples[num2] = inSamples[i + 1];
            }
        }

        private void CreateResamplingFilter(int inHz, int outHz)
        {
            if (inHz <= 0)
            {
                throw new ArgumentOutOfRangeException("inHz");
            }
            if (outHz <= 0)
            {
                throw new ArgumentOutOfRangeException("outHz");
            }
            FindResampleFactors(inHz, outHz);
            int num = (_iUpFactor > _iDownFactor) ? _iUpFactor : _iDownFactor;
            _iFilterHalf = (int)((float)(inHz * num) * 0.0005f);
            _iFilterLen = 2 * _iFilterHalf + 1;
            _filterCoeff = WindowedLowPass(0.5f / (float)num, _iUpFactor);
            _iBuffLen = (int)((float)_iFilterLen / (float)_iUpFactor);
            _leftMemory = new float[_iBuffLen];
            _rightMemory = new float[_iBuffLen];
            _eChunkStatus = Block.First;
        }

        private float[] WindowedLowPass(float dCutOff, float dGain)
        {
            float[] array = null;
            float[] array2 = null;
            array2 = Blackman(_iFilterLen, true);
            array = new float[_iFilterLen];
            double num = Math.PI * 2.0 * (double)dCutOff;
            array[_iFilterHalf] = (float)((double)dGain * 2.0 * (double)dCutOff);
            for (long num2 = 1L; num2 <= _iFilterHalf; num2++)
            {
                double num3 = (double)dGain * Math.Sin(num * (double)num2) / (Math.PI * (double)num2) * (double)array2[_iFilterHalf - num2];
                array[_iFilterHalf + num2] = (float)num3;
                array[_iFilterHalf - num2] = (float)num3;
            }
            return array;
        }

        private void FindResampleFactors(int inHz, int outHz)
        {
            int num = 1;
            while (num != 0)
            {
                num = 0;
                for (int i = 0; i < piPrimes.Length; i++)
                {
                    if (inHz % piPrimes[i] == 0 && outHz % piPrimes[i] == 0)
                    {
                        inHz /= piPrimes[i];
                        outHz /= piPrimes[i];
                        num = 1;
                        break;
                    }
                }
            }
            _iUpFactor = outHz;
            _iDownFactor = inHz;
        }

        private float[] Resampling(float[] inSamples, float[] pdMemory)
        {
            int num = inSamples.Length;
            int num2;
            int num3;
            if (_eChunkStatus == Block.First)
            {
                num2 = (num * _iUpFactor - _iFilterHalf) / _iDownFactor;
                num3 = 1;
            }
            else if (_eChunkStatus == Block.Middle)
            {
                num2 = num * _iUpFactor / _iDownFactor;
                num3 = 2;
            }
            else
            {
                num2 = _iFilterHalf * _iUpFactor / _iDownFactor;
                num3 = 2;
            }
            if (num2 < 0)
            {
                num2 = 0;
            }
            float[] array = new float[num2];
            for (int i = 0; i < num2; i++)
            {
                double num4 = 0.0;
                int num5 = (i * _iDownFactor - num3 * _iFilterHalf) / _iUpFactor;
                int num6 = i * _iDownFactor - (num5 * _iUpFactor + num3 * _iFilterHalf);
                for (int j = 0; j < _iFilterLen / _iUpFactor; j++)
                {
                    if (_iUpFactor * j > num6)
                    {
                        if (num5 + j >= 0 && num5 + j < num)
                        {
                            num4 += (double)(inSamples[num5 + j] * _filterCoeff[_iUpFactor * j - num6]);
                        }
                        else if (num5 + j < 0)
                        {
                            num4 += (double)(pdMemory[_iBuffLen + num5 + j] * _filterCoeff[_iUpFactor * j - num6]);
                        }
                    }
                }
                array[i] = (float)num4;
            }
            if (_eChunkStatus != Block.Last)
            {
                int num5 = num - (_iBuffLen + 1);
                for (int k = 0; k < _iBuffLen; k++)
                {
                    if (num5 >= 0)
                    {
                        pdMemory[k] = inSamples[num5++];
                        continue;
                    }
                    num5++;
                    pdMemory[k] = 0f;
                }
            }
            return array;
        }

        private static float[] Blackman(int iLength, bool bSymmetric)
        {
            float[] array = new float[iLength];
            double num = Math.PI * 2.0;
            num = ((!bSymmetric) ? (num / (double)(float)iLength) : (num / (double)(float)(iLength - 1)));
            double num2 = 2.0 * num;
            for (int i = 0; i < iLength; i++)
            {
                array[i] = (float)(0.42 - 0.5 * Math.Cos(num * (double)i) + 0.08 * Math.Cos(num2 * (double)i));
            }
            return array;
        }
    }
}