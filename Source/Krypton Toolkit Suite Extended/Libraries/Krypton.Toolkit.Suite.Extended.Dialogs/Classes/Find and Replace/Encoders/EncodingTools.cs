﻿#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license or other governing licenses that can be found in the LICENSE.md file or at
 * https://raw.githubusercontent.com/Krypton-Suite/Extended-Toolkit/master/LICENSE
 */
#endregion

using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;

namespace Krypton.Toolkit.Suite.Extended.Dialogs
{
    public static class EncodingTools
    {
        // this only contains ascii, default windows code page and unicode
        public static int[] PreferedEncodingsForStream;

        // this contains all codepages, sorted by preference and byte usage 
        public static int[] PreferedEncodings;

        // this contains all codepages, sorted by preference and byte usage 
        public static int[] AllEncodings;



        /// <summary>
        /// Static constructor that fills the default preferred codepages
        /// </summary>
        static EncodingTools()
        {

            List<int> streamEcodings = new List<int>();
            List<int> allEncodings = new List<int>();
            List<int> mimeEcodings = new List<int>();

            // asscii - most simple so put it in first place...
            streamEcodings.Add(Encoding.ASCII.CodePage);
            mimeEcodings.Add(Encoding.ASCII.CodePage);
            allEncodings.Add(Encoding.ASCII.CodePage);


            // add default 2nd for all encodings
            allEncodings.Add(Encoding.Default.CodePage);
            // default is single byte?
            if (Encoding.Default.IsSingleByte)
            {
                // put it in second place
                streamEcodings.Add(Encoding.Default.CodePage);
                mimeEcodings.Add(Encoding.Default.CodePage);
            }



            // prefer JIS over JIS-SHIFT (JIS is detected better than JIS-SHIFT)
            // this one does include cyrilic (strange but true)
            allEncodings.Add(50220);
            mimeEcodings.Add(50220);


            // always allow unicode flavours for streams (they all have a preamble)
            streamEcodings.Add(Encoding.Unicode.CodePage);
            foreach (EncodingInfo enc in Encoding.GetEncodings())
            {
                if (!streamEcodings.Contains(enc.CodePage))
                {
                    Encoding encoding = Encoding.GetEncoding(enc.CodePage);
                    if (encoding.GetPreamble().Length > 0)
                        streamEcodings.Add(enc.CodePage);
                }
            }


            // stream is done here
            PreferedEncodingsForStream = streamEcodings.ToArray();


            // all singlebyte encodings
            foreach (EncodingInfo enc in Encoding.GetEncodings())
            {


                if (!enc.GetEncoding().IsSingleByte)
                    continue;

                if (!allEncodings.Contains(enc.CodePage))
                    allEncodings.Add(enc.CodePage);

                // only add iso and IBM encodings to mime encodings 
                if (enc.CodePage <= 1258)
                {
                    mimeEcodings.Add(enc.CodePage);
                }
            }

            // add the rest (multibyte)
            foreach (EncodingInfo enc in Encoding.GetEncodings())
            {
                if (!enc.GetEncoding().IsSingleByte)
                {
                    if (!allEncodings.Contains(enc.CodePage))
                        allEncodings.Add(enc.CodePage);

                    // only add iso and IBM encodings to mime encodings 
                    if (enc.CodePage <= 1258)
                    {
                        mimeEcodings.Add(enc.CodePage);
                    }
                }
            }

            // add unicodes
            mimeEcodings.Add(Encoding.Unicode.CodePage);


            PreferedEncodings = mimeEcodings.ToArray();
            AllEncodings = allEncodings.ToArray();
        }


        /// <summary>
        /// Checks if specified string data is acii data.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static bool IsAscii(string data)
        {
            // assume empty string to be ascii
            if ((data == null) || (data.Length == 0))
                return true;
            foreach (char c in data)
            {
                if ((int)c > 127)
                {
                    return false;
                }
            }

            return true;
        }

        /// <summary>
        /// Gets the best Encoding for usage in mime encodings
        /// </summary>
        /// <param name="input">text to detect</param>
        /// <returns>the suggested encoding</returns>
        public static Encoding GetMostEfficientEncoding(string input)
        {
            return GetMostEfficientEncoding(input, PreferedEncodings);
        }

        /// <summary>
        /// Gets the best ISO Encoding for usage in a stream
        /// </summary>
        /// <param name="input">text to detect</param>
        /// <returns>the suggested encoding</returns>
        public static Encoding GetMostEfficientEncodingForStream(string input)
        {
            return GetMostEfficientEncoding(input, PreferedEncodingsForStream);
        }

        /// <summary>
        /// Gets the best fitting encoding from a list of possible encodings
        /// </summary>
        /// <param name="input">text to detect</param>
        /// <param name="preferedEncodings">an array of codepages</param>
        /// <returns>the suggested encoding</returns>
        public static Encoding GetMostEfficientEncoding(string input, int[] preferedEncodings)
        {
            Encoding enc = DetectOutgoingEncoding(input, preferedEncodings, true);
            // unicode.. hmmm... check for smallest encoding
            if (enc.CodePage == Encoding.Unicode.CodePage)
            {
                int byteCount = Encoding.UTF7.GetByteCount(input);
                enc = Encoding.UTF7;
                int bestByteCount = byteCount;

                // utf8 smaller?
                byteCount = Encoding.UTF8.GetByteCount(input);
                if (byteCount < bestByteCount)
                {
                    enc = Encoding.UTF8;
                    bestByteCount = byteCount;
                }

                // unicode smaller?
                byteCount = Encoding.Unicode.GetByteCount(input);
                if (byteCount < bestByteCount)
                {
                    enc = Encoding.Unicode;
                    bestByteCount = byteCount;
                }
            }
            else
            {

            }
            return enc;
        }

        public static Encoding DetectOutgoingEncoding(string input)
        {
            return DetectOutgoingEncoding(input, PreferedEncodings, true);
        }

        public static Encoding DetectOutgoingStreamEncoding(string input)
        {
            return DetectOutgoingEncoding(input, PreferedEncodingsForStream, true);
        }

        public static Encoding[] DetectOutgoingEncodings(string input)
        {
            return DetectOutgoingEncodings(input, PreferedEncodings, true);
        }

        public static Encoding[] DetectOutgoingStreamEncodings(string input)
        {
            return DetectOutgoingEncodings(input, PreferedEncodingsForStream, true);
        }

        private static Encoding DetectOutgoingEncoding(string input, int[] preferedEncodings, bool preserveOrder)
        {

            if (input == null)
                throw new ArgumentNullException("input");

            // empty strings can always be encoded as ASCII
            if (input.Length == 0)
                return Encoding.ASCII;

            Encoding result = Encoding.ASCII;

            // get the IMultiLanguage3 interface
            IMultiLanguage3 multilang3 = new CMultiLanguageClass();
            if (multilang3 == null)
                throw new System.Runtime.InteropServices.COMException("Failed to get IMultilang3");
            try
            {
                int[] resultCodePages =
                    new int[preferedEncodings != null ? preferedEncodings.Length : Encoding.GetEncodings().Length];
                uint detectedCodepages = (uint)resultCodePages.Length;
                ushort specialChar = (ushort)'?';


                // get unmanaged arrays
                IntPtr pPrefEncs = preferedEncodings == null
                                       ? IntPtr.Zero
                                       : Marshal.AllocCoTaskMem(sizeof(uint) * preferedEncodings.Length);
                IntPtr pDetectedEncs = Marshal.AllocCoTaskMem(sizeof(uint) * resultCodePages.Length);

                try
                {
                    if (preferedEncodings != null)
                        Marshal.Copy(preferedEncodings, 0, pPrefEncs, preferedEncodings.Length);

                    Marshal.Copy(resultCodePages, 0, pDetectedEncs, resultCodePages.Length);

                    MLCPF options = MLCPF.MLDETECTF_VALID_NLS;
                    if (preserveOrder)
                        options |= MLCPF.MLDETECTF_PRESERVE_ORDER;

                    if (preferedEncodings != null)
                        options |= MLCPF.MLDETECTF_PREFERRED_ONLY;

                    multilang3.DetectOutboundCodePage(options,
                                                      input, (uint)input.Length,
                                                      pPrefEncs, (uint)(preferedEncodings == null ? 0 : preferedEncodings.Length),

                                                      pDetectedEncs, ref detectedCodepages,
                                                      ref specialChar);

                    // get result
                    if (detectedCodepages > 0)
                    {
                        int[] theResult = new int[detectedCodepages];
                        Marshal.Copy(pDetectedEncs, theResult, 0, theResult.Length);
                        result = Encoding.GetEncoding(theResult[0]);
                    }

                }
                finally
                {
                    if (pPrefEncs != IntPtr.Zero)
                        Marshal.FreeCoTaskMem(pPrefEncs);
                    Marshal.FreeCoTaskMem(pDetectedEncs);
                }
            }
            finally
            {
                Marshal.FinalReleaseComObject(multilang3);
            }
            return result;
        }

        public static Encoding[] DetectOutgoingEncodings(string input, int[] preferedEncodings, bool preserveOrder)
        {

            if (input == null)
                throw new ArgumentNullException("input");

            // empty strings can always be encoded as ASCII
            if (input.Length == 0)
                return new Encoding[] { Encoding.ASCII };

            List<Encoding> result = new List<Encoding>();

            // get the IMultiLanguage3 interface
            IMultiLanguage3 multilang3 = new CMultiLanguageClass();

            if (multilang3 == null)
                throw new System.Runtime.InteropServices.COMException("Failed to get IMultilang3");
            try
            {
                int[] resultCodePages = new int[preferedEncodings.Length];
                uint detectedCodepages = (uint)resultCodePages.Length;
                ushort specialChar = (ushort)'?';


                // get unmanaged arrays
                IntPtr pPrefEncs = Marshal.AllocCoTaskMem(sizeof(uint) * preferedEncodings.Length);
                IntPtr pDetectedEncs = preferedEncodings == null
                                           ? IntPtr.Zero
                                           : Marshal.AllocCoTaskMem(sizeof(uint) * resultCodePages.Length);

                try
                {
                    if (preferedEncodings != null)
                        Marshal.Copy(preferedEncodings, 0, pPrefEncs, preferedEncodings.Length);

                    Marshal.Copy(resultCodePages, 0, pDetectedEncs, resultCodePages.Length);

                    MLCPF options = MLCPF.MLDETECTF_VALID_NLS |
                                                  MLCPF.MLDETECTF_PREFERRED_ONLY;
                    if (preserveOrder)
                        options |= MLCPF.MLDETECTF_PRESERVE_ORDER;

                    if (preferedEncodings != null)
                        options |= MLCPF.MLDETECTF_PREFERRED_ONLY;

                    // finally... call to DetectOutboundCodePage
                    multilang3.DetectOutboundCodePage(options,
                                                      input, (uint)input.Length,
                                                      pPrefEncs, (uint)(preferedEncodings == null ? 0 : preferedEncodings.Length),
                                                      pDetectedEncs, ref detectedCodepages,
                                                      ref specialChar);

                    // get result
                    if (detectedCodepages > 0)
                    {
                        int[] theResult = new int[detectedCodepages];
                        Marshal.Copy(pDetectedEncs, theResult, 0, theResult.Length);


                        // get the encodings for the codepages
                        for (int i = 0; i < detectedCodepages; i++)
                            result.Add(Encoding.GetEncoding(theResult[i]));

                    }

                }
                finally
                {
                    if (pPrefEncs != IntPtr.Zero)
                        Marshal.FreeCoTaskMem(pPrefEncs);
                    Marshal.FreeCoTaskMem(pDetectedEncs);
                }
            }
            finally
            {
                Marshal.FinalReleaseComObject(multilang3);
            }
            // nothing found
            return result.ToArray();
        }


        /// <summary>
        /// Detect the most probable codepage from an byte array
        /// </summary>
        /// <param name="input">array containing the raw data</param>
        /// <returns>the detected encoding or the default encoding if the detection failed</returns>
        public static Encoding DetectInputCodepage(byte[] input)
        {
            try
            {
                Encoding[] detected = DetectInputCodepages(input, 1);
                if (detected.Length > 0)
                    return detected[0];
                return Encoding.Default;
            }
            catch (COMException)
            {
                // return default codepage on error
                return Encoding.Default;
            }
        }

        /// <summary>
        /// Rerurns up to maxEncodings codpages that are assumed to be apropriate
        /// </summary>
        /// <param name="input">array containing the raw data</param>
        /// <param name="maxEncodings">maxiumum number of encodings to detect</param>
        /// <returns>an array of Encoding with assumed encodings</returns>
        public static Encoding[] DetectInputCodepages(byte[] input, int maxEncodings)
        {

            StopWatch.Start("DetectInputCodepages_" + Thread.CurrentThread.ManagedThreadId);

            if (maxEncodings < 1)
                throw new ArgumentOutOfRangeException("at least one encoding must be returend", "maxEncodings");

            if (input == null)
                throw new ArgumentNullException("input");

            // empty strings can always be encoded as ASCII
            if (input.Length == 0)
                return new Encoding[] { Encoding.ASCII };

            // expand the string to be at least 256 bytes
            if (input.Length < 256)
            {
                byte[] newInput = new byte[256];
                int steps = 256 / input.Length;
                for (int i = 0; i < steps; i++)
                    Array.Copy(input, 0, newInput, input.Length * i, input.Length);

                int rest = 256 % input.Length;
                if (rest > 0)
                    Array.Copy(input, 0, newInput, steps * input.Length, rest);
                input = newInput;
            }



            List<Encoding> result = new List<Encoding>();

            // get the IMultiLanguage" interface
            IMultiLanguage2 multilang2 = new CMultiLanguageClass();

            if (multilang2 == null)
                throw new System.Runtime.InteropServices.COMException("Failed to get IMultilang2");
            try
            {
                DetectEncodingInfo[] detectedEncdings = new DetectEncodingInfo[maxEncodings];

                int scores = detectedEncdings.Length;
                int srcLen = input.Length;

                // setup options (none)   
                MLDETECTCP options = MLDETECTCP.MLDETECTCP_NONE;


                StopWatch.Start("multilang2.DetectInputCodepage_" + Thread.CurrentThread.ManagedThreadId);

                // finally... call to DetectInputCodepage
                multilang2.DetectInputCodepage(options, 0,
                                               ref input[0], ref srcLen, ref detectedEncdings[0], ref scores);

                StopWatch.Stop("multilang2.DetectInputCodepage_" + Thread.CurrentThread.ManagedThreadId);

                // get result
                if (scores > 0)
                {
                    for (int i = 0; i < scores; i++)
                    {
                        // add the result
                        result.Add(Encoding.GetEncoding((int)detectedEncdings[i].nCodePage));
                    }
                }
            }
            finally
            {
                Marshal.FinalReleaseComObject(multilang2);
            }

            StopWatch.Stop("DetectInputCodepages_" + Thread.CurrentThread.ManagedThreadId);

            // nothing found
            return result.ToArray();
        }


        /*  Eric made no difference
	    public static IMultiLanguage2 _multilang2;

		public static void PreDetectInputCodepages2()
	    {
			StopWatch.Start("PreDetectInputCodepages2_" + Thread.CurrentThread.ManagedThreadId);

			// get the IMultiLanguage" interface
			_multilang2 = new CMultiLanguageClass();

			if (_multilang2 == null)
				throw new System.Runtime.InteropServices.COMException("Failed to get IMultilang2");

			StopWatch.Stop("PreDetectInputCodepages2_" + Thread.CurrentThread.ManagedThreadId);

	    }

	    public static Encoding[] DetectInputCodepages2(byte[] input, int maxEncodings)
		{
			StopWatch.Start("DetectInputCodepages2_" + Thread.CurrentThread.ManagedThreadId);

			if (maxEncodings < 1)
				throw new ArgumentOutOfRangeException("at least one encoding must be returend", "maxEncodings");

			if (input == null)
				throw new ArgumentNullException("input");

			// empty strings can always be encoded as ASCII
			if (input.Length == 0)
				return new Encoding[] { Encoding.ASCII };
		
			// expand the string to be at least 256 bytes
			if (input.Length < 256)
			{
				byte[] newInput = new byte[256];
				int steps = 256 / input.Length;
				for (int i = 0; i < steps; i++)
					Array.Copy(input, 0, newInput, input.Length * i, input.Length);

				int rest = 256 % input.Length;
				if (rest > 0)
					Array.Copy(input, 0, newInput, steps * input.Length, rest);
				input = newInput;
			}

			
			DetectEncodingInfo[] detectedEncdings = new DetectEncodingInfo[maxEncodings];
	
			// setup options (none)   
			MLDETECTCP options = MLDETECTCP.MLDETECTCP_NONE;

			List<Encoding> result = new List<Encoding>();
			int scores = detectedEncdings.Length;
			int srcLen = input.Length;

			StopWatch.Start("multilang2.DetectInputCodepage2_" + Thread.CurrentThread.ManagedThreadId);

			// finally... call to DetectInputCodepage
			_multilang2.DetectInputCodepage(options, 0,
				ref input[0], ref srcLen, ref detectedEncdings[0], ref scores);

			StopWatch.Stop("multilang2.DetectInputCodepage2_" + Thread.CurrentThread.ManagedThreadId);

			// get result
			if (scores > 0)
			{
				for (int i = 0; i < scores; i++)
				{
					// add the result
					result.Add(Encoding.GetEncoding((int)detectedEncdings[i].nCodePage));
				}
			}
			
			StopWatch.Stop("DetectInputCodepages2_" + Thread.CurrentThread.ManagedThreadId);
			
			// nothing found
			return result.ToArray();
		}


		public static void PostDetectInputCodepages2()
		{
			Marshal.FinalReleaseComObject(_multilang2);
		}

		 */

        /// <summary>
        /// Opens a text file and returns the content 
        /// encoded in the most probable encoding
        /// </summary>
        /// <param name="path">path to the souce file</param>
        /// <returns>the text content of the file</returns>
        public static string ReadTextFile(string path)
        {
            if (path == null)
                throw new ArgumentNullException("path");

            using (Stream fs = File.Open(path, FileMode.Open))
            {
                byte[] rawData = new byte[fs.Length];
                Encoding enc = DetectInputCodepage(rawData);
                return enc.GetString(rawData);
            }
        }

        /// <summary>
        /// Returns a stream reader for the given
        /// text file with the best encoding applied
        /// </summary>
        /// <param name="path">path to the file</param>
        /// <returns>a StreamReader for the file</returns>
        public static StreamReader OpenTextFile(string path)
        {
            if (path == null)
                throw new ArgumentNullException("path");
            return OpenTextStream(File.Open(path, FileMode.Open));
        }

        /// <summary>
        /// Creates a stream reader from a stream and detects
        /// the encoding form the first bytes in the stream
        /// </summary>
        /// <param name="stream">a stream to wrap</param>
        /// <returns>the newly created StreamReader</returns>
        public static StreamReader OpenTextStream(Stream stream)
        {
            // check stream parameter
            if (stream == null)
                throw new ArgumentNullException("stream");
            if (!stream.CanSeek)
                throw new ArgumentException("the stream must support seek operations", "stream");

            // assume default encoding at first place
            Encoding detectedEncoding = Encoding.Default;

            // seek to stream start
            stream.Seek(0, SeekOrigin.Begin);

            // buffer for preamble and up to 512b sample text for dection
            byte[] buf = new byte[System.Math.Min(stream.Length, 512)];

            stream.Read(buf, 0, buf.Length);
            detectedEncoding = DetectInputCodepage(buf);
            // seek back to stream start
            stream.Seek(0, SeekOrigin.Begin);


            return new StreamReader(stream, detectedEncoding);

        }

    }
}