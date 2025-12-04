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

/// <summary>
/// A class at a lower-level than ExceptionReporter due to the need to abstract out the option for the
/// implementation of IScreenshooter
/// Call Send() method here directly with any IScreenshooter implementation (including the dummy provided <see cref="NoScreenShot"/> - which will be
/// effectively the same as setting <see cref="ExceptionReportInfo.TakeScreenshot"/>to false)
/// </summary>
public class ExceptionReporterBase
{
    /// <summary>
    /// 
    /// </summary>
    protected readonly ExceptionReportInfo _info;

    /// <summary>
    /// Initialise the ExceptionReporter
    /// </summary>
    protected ExceptionReporterBase()
    {
        _info = new ExceptionReportInfo();
    }

    /// <summary>
    /// Public access to configuration/settings
    /// </summary>
    public ExceptionReportInfo Config => _info;

    /// <summary>
    /// Send the report, asynchronously, without showing a dialog (silent send)
    /// <see cref="ExceptionReportInfo.SendMethod"/>must be SMTP or WebService, else this is ignored (silently)
    /// </summary>
    /// <param name="screenShooter">The screen-shotting code might be specific to WinForms, so this is an option to send anything that implements IScreenshooter</param>
    /// <param name="sendEvent">Provide implementation of IReportSendEvent to receive error/updates on calling thread</param>
    /// <param name="exceptions">The exception/s to include in the report</param>
    protected void Send(IScreenShooter screenShooter, IReportSendEvent? sendEvent = null, params Exception[] exceptions)
    {
        _info.SetExceptions(exceptions);

        var sender = new SenderFactory(_info, sendEvent ?? new SilentSendEvent(), screenShooter).Get();
        var report = new ReportGenerator(_info);
        sender.Send(report.Generate());
    }
}