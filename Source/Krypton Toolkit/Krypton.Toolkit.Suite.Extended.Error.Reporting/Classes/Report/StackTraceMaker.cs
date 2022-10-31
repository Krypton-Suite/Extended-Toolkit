#region MIT License
/*
 * MIT License
 *
 * Copyright (c) 2017 - 2023 Krypton Suite
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
 *
 */
#endregion

namespace Krypton.Toolkit.Suite.Extended.Error.Reporting
{
    internal class StackTraceMaker : IStackTraceMaker
    {
        private readonly IList<Exception> _exceptions;

        public StackTraceMaker(params Exception[] exceptions)
        {
            _exceptions = exceptions;
        }

        public string FullStackTrace()
        {
            var sb = new StringBuilder();

            foreach (var exception in _exceptions)
            {
                sb.AppendLine(this.StackTrace(exception));
            }

            return sb.ToString();
        }

        /// <summary>
        /// Create a line-delimited string of the exception hierarchy 
        /// //TODO see Label='EH' in View, which is partly duplicated
        /// </summary>
        private string StackTrace(Exception exception)
        {
            var currentException = exception;
            var stringBuilder = new StringBuilder();
            var count = 0;

            while (currentException != null)
            {
                if (count++ == 0)
                    stringBuilder.AppendLine("Top-level Exception");
                else
                    stringBuilder.AppendLine("Inner Exception " + (count - 1));

                stringBuilder
                    .AppendLine("Type:    " + currentException.GetType())
                    .AppendLine("Message: " + currentException.Message)
                    .AppendLine("Source:  " + currentException.Source);

                if (currentException.StackTrace != null)
                {
                    stringBuilder.AppendLine("Stack Trace: " + currentException.StackTrace.Trim());
                }

                currentException = currentException.InnerException;
            }

            var exceptionString = stringBuilder.ToString();
            return exceptionString.TrimEnd();
        }
    }
}