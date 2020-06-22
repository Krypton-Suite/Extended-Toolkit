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

namespace Krypton.Toolkit.Extended.Dialogs
{
    [Flags]
    public enum MLCPF
    {
        // Not currently supported.
        MLDETECTF_MAILNEWS = 0x0001,

        // Not currently supported.
        MLDETECTF_BROWSER = 0x0002,

        // Detection result must be valid for conversion and text rendering.
        MLDETECTF_VALID = 0x0004,

        // Detection result must be valid for conversion.
        MLDETECTF_VALID_NLS = 0x0008,

        //Preserve preferred code page order. 
        //This is meaningful only if you have set the puiPreferredCodePages parameter in IMultiLanguage3::DetectOutboundCodePage or IMultiLanguage3::DetectOutboundCodePageInIStream.
        MLDETECTF_PRESERVE_ORDER = 0x0010,

        // Only return one of the preferred code pages as the detection result. 
        // This is meaningful only if you have set the puiPreferredCodePages parameter in IMultiLanguage3::DetectOutboundCodePage or IMultiLanguage3::DetectOutboundCodePageInIStream.
        MLDETECTF_PREFERRED_ONLY = 0x0020,

        // Filter out graphical symbols and punctuation.
        MLDETECTF_FILTER_SPECIALCHAR = 0x0040,

        // Return only Unicode codepages if the euro character is detected. 
        MLDETECTF_EURO_UTF8 = 0x0080
    }

}