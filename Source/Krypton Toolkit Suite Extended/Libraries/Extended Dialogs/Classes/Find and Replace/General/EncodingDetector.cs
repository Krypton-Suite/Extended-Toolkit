#region License
/*
 * MIT License
 *
 * Copyright (c) 2017 ENTech Solutions
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
*/
#endregion

using System;
using System.Linq;
using System.Text;

namespace Krypton.Toolkit.Extended.Dialogs
{
    public class EncodingDetector
    {

        [Flags]
        public enum Options
        {
            KlerkSoftBom = 1,
            KlerkSoftHeuristics = 2,
            MLang = 4
        }

        public static Encoding Detect(byte[] bytes, EncodingDetector.Options opts = Options.KlerkSoftBom | Options.MLang, Encoding defaultEncoding = null)
        {
            Encoding encoding = null;

            if ((opts & Options.KlerkSoftBom) == Options.KlerkSoftBom)
            {
                StopWatch.Start("DetectEncoding: UsingKlerksSoftBom");

                encoding = DetectEncodingUsingKlerksSoftBom(bytes);

                StopWatch.Stop("DetectEncoding: UsingKlerksSoftBom");
            }

            if (encoding != null)
                return encoding;

            if ((opts & Options.KlerkSoftHeuristics) == Options.KlerkSoftHeuristics)
            {
                StopWatch.Start("DetectEncoding: UsingKlerksSoftHeuristics");
                encoding = DetectEncodingUsingKlerksSoftHeuristics(bytes);
                StopWatch.Stop("DetectEncoding: UsingKlerksSoftHeuristics");
            }

            if (encoding != null)
                return encoding;

            if ((opts & Options.MLang) == Options.MLang)
            {
                StopWatch.Start("DetectEncoding: UsingMLang");
                encoding = DetectEncodingUsingMLang(bytes);
                StopWatch.Stop("DetectEncoding: UsingMLang");
            }

            if (encoding == null)
                encoding = defaultEncoding;

            return encoding;
        }

        private static Encoding DetectEncodingUsingKlerksSoftBom(byte[] bytes)
        {
            Encoding encoding = null;
            if (bytes.Count() >= 4)
                encoding = KlerksSoftEncodingDetector.DetectBOMBytes(bytes);

            return encoding;
        }


        private static Encoding DetectEncodingUsingKlerksSoftHeuristics(byte[] bytes)
        {
            Encoding encoding = KlerksSoftEncodingDetector.DetectUnicodeInByteSampleByHeuristics(bytes);

            return encoding;
        }

        private static Encoding DetectEncodingUsingMLang(Byte[] bytes)
        {
            try
            {
                Encoding[] detected = EncodingTools.DetectInputCodepages(bytes, 1);
                if (detected.Length > 0)
                {
                    return detected[0];
                }
            }
            catch //(COMException ex)
            {
                // return default codepage on error
            }

            return null;
        }

    }
}