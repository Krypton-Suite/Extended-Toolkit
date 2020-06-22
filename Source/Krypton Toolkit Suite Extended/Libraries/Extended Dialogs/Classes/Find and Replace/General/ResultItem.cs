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
using System.Collections.Generic;
using System.Text;

namespace Krypton.Toolkit.Extended.Dialogs
{
    abstract public class ResultItem
    {
        public string FileName { get; set; }
        public string FilePath { get; set; }
        public string FileRelativePath { get; set; }
        public Encoding FileEncoding { get; set; }
        public int NumMatches { get; set; }
        public List<LiteMatch> Matches { get; set; }
        public bool IsSuccess { get; set; }
        public bool IsBinaryFile { get; set; }
        public bool FailedToOpen { get; set; }
        public string ErrorMessage { get; set; }

        internal bool IncludeFilesWithoutMatches { get; set; }

        public bool IncludeInResultsList
        {
            get
            {
                if (IsSuccess && NumMatches == 0 && IncludeFilesWithoutMatches)
                    return true;

                if (IsSuccess && NumMatches > 0)
                    return true;

                if (!IsSuccess && !String.IsNullOrEmpty(ErrorMessage))
                    return true;

                return false;
            }
        }

        public bool IsReplaced
        {
            get { return this.IsSuccess && this.NumMatches > 0; }  //Account for case when no matches found
        }
    }
}