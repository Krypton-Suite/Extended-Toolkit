#region MIT License
/*
 *
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
    /// <summary>
    /// The communication method used to send a report 
    /// </summary>
    public enum ReportSendMethod
    {
        ///<summary>
        /// No sending (default)
        /// </summary>
        None,

        ///<summary>
        /// Tries to use the Windows default Email client eg Outlook via SMTP
        /// If a compatible client isn't installed, it will not work, so there is some risk - but in that case, an
        /// error message will prompt the user to use the "Copy" feature and manually send the result
        /// <remarks>
        /// requires <see cref="ExceptionReportInfo.EmailReportAddress"/> to be set to a valid email</remarks>
        /// </summary>
        SimpleMAPI,

        ///<summary>
        /// Sends an Email via an SMTP server - requires other config (host/port etc) properties starting with 'Smtp'
        /// </summary>
        SMTP,

        /// <summary>
        /// WebService - requires a REST API server accepting content-type 'application/json' of type POST and a
        /// JSON packet containing the properties represented in the DataContract class 'ExceptionReportPacket'
        /// An example project demonstrating requirements is included in the fExceptionReporter.NET solution
        /// </summary>
        WebService
    }
}