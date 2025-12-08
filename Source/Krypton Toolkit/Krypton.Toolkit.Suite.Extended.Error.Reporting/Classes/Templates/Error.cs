#region MIT License
/*
 * MIT License
 *
 * Copyright (c) 2017 - 2026 Krypton Suite
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

namespace Krypton.Toolkit.Suite.Extended.Error.Reporting;

public class Error
{
    //===== required variables =====

    /// <summary> DateTime of exception - defaults is 'Now' but would normally be set via config </summary>
    public DateTime When { get; set; } = DateTime.Now;

    /// <summary> Full stack trace string, including any and all inner exceptions and/or multiple exceptions </summary>
    public string FullStackTrace { get; set; }

    /// <summary> Optional - user input </summary>
    public string Explanation { get; set; }

    /// <summary> an ID to uniquely identify this particular report (defaults to a generated GUID) </summary>
    public string ID { get; set; } = Guid.NewGuid().ToString();

    //===== calculated variables
    public Exception Exception { get; set; }

    public string Message => Exception.Message;

    public string Date => When.ToShortDateString();

    public string Time => When.ToShortTimeString();
    //=====
}