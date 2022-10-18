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

namespace Krypton.Toolkit.Suite.Extended.Software.Updater.NetSparkle
{
    /// <summary>
    /// A simple class to handle log information for NetSparkleUPdater.
    /// Make sure to do any setup for this class that you want
    /// to do before calling StartLoop on your SparkleUpdater object.
    /// </summary>
    public class LogWriter
    {
        /// <summary>
        /// Tag to show before any log statements
        /// </summary>
        protected string tag = "netsparkle:";
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
        /// <param name="printDiagnosticToConsole">Whether this object should print via Debug.WriteLine or Console.WriteLine</param>
        public LogWriter(bool printDiagnosticToConsole)
        {
            PrintDiagnosticToConsole = printDiagnosticToConsole;
        }

        #region Properties

        /// <summary>
        /// true if this class should print to Console.WriteLine.
        /// false if this object should print to Debug.WriteLine.
        /// Defaults to false.
        /// </summary>
        public bool PrintDiagnosticToConsole { get; set; }

        #endregion

        /// <summary>
        /// Print a message to the log output.
        /// </summary>
        /// <param name="message">Message to print</param>
        /// <param name="arguments">Arguments to print (e.g. if using {0} format arguments)</param>
        public virtual void PrintMessage(string message, params object[] arguments)
        {
            if (PrintDiagnosticToConsole)
            {
                Console.WriteLine(tag + " " + message, arguments);
            }
            else
            {
                Debug.WriteLine(tag + " " + message, arguments);
            }
        }
    }
}