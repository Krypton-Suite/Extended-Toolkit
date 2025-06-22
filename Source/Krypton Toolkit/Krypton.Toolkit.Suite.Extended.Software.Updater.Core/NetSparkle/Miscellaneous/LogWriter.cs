#region License

/*
 * Copyright(c) 2022 Deadpikle
 *
 * Permission is hereby granted, free of charge, to any person obtaining a copy
 * of this software and associated documentation files (the "Software"), to deal
 * in the Software without restriction, including without limitation the rights
 * to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
 * copies of the Software, and to permit persons to whom the Software is
 * furnished to do so, subject to the following conditions:
 *
 * The above copyright notice and this permission notice shall be included in
 * all copies or substantial portions of the Software.
 *
 * THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
 * IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
 * FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
 * AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
 * LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
 * OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
 * THE SOFTWARE.
 */

#endregion

namespace Krypton.Toolkit.Suite.Extended.Software.Updater.Core;

/// <summary>
/// A simple class to handle log information for NetSparkleUpdater.
/// Make sure to do any setup for this class that you want
/// to do before calling StartLoop on your <see cref="SparkleUpdater"/> object.
/// </summary>
public class LogWriter : ILogger
{
    /// <summary>
    /// Tag to show before any log statements
    /// </summary>
    public static string _tag = "netsparkle:";

    /// <summary>
    /// Empty constructor -> sets PrintDiagnosticToConsole to false
    /// </summary>
    public LogWriter()
    {
        PrintDiagnosticToConsole = false;
    }

    /// <summary>
    /// LogWriter constructor that takes a bool to determine
    /// the value for printDiagnosticToConsole
    /// </summary>
    /// <param name="printDiagnosticToConsole">False to print to <seealso cref="Debug.WriteLine(string)"/>;
    /// true to print to <seealso cref="Console.WriteLine(string)"/></param>
    public LogWriter(bool printDiagnosticToConsole)
    {
        PrintDiagnosticToConsole = printDiagnosticToConsole;
    }

    #region Properties

    /// <summary>
    /// True if this class should print to <seealso cref="Console.WriteLine(string)"/>;
    /// false if this object should print to <seealso cref="Debug.WriteLine(string)"/>.
    /// Defaults to false.
    /// </summary>
    public bool PrintDiagnosticToConsole { get; set; }

    #endregion

    /// <inheritdoc/>
    public virtual void PrintMessage(string message, params object[] arguments)
    {
        if (PrintDiagnosticToConsole)
        {
            Console.WriteLine(_tag + @" " + message, arguments);
        }
        else
        {
            Trace.WriteLine(string.Format(_tag + " " + message, arguments));
        }
    }
}