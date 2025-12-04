#region MIT License
/*
 *
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

namespace Krypton.Toolkit.Suite.Extended.Global.Utilities;

/// <summary>Adapted from https://www.codeproject.com/Articles/18509/Add-a-UAC-shield-to-a-button-when-elevation-is-req.</summary>
public static class UACSecurity
{
    #region Win32 Calls
    [DllImport("user32")]
    public static extern UInt32 SendMessage(IntPtr hWnd, UInt32 msg, UInt32 wParam, UInt32 lParam);
    #endregion

    #region Constants
    internal const int BCM_FIRST = 0x1600, BCM_SETSHIELD = BCM_FIRST + 0x000C;
    #endregion

    #region Methods
    static internal bool IsVistaOrHigher() => Environment.OSVersion.Version.Major < 6;

    /// <summary>
    /// Checks if the process is elevated
    /// </summary>
    /// <returns>If is elevated</returns>
    static internal bool IsAdmin()
    {
        WindowsIdentity id = WindowsIdentity.GetCurrent();
        WindowsPrincipal p = new WindowsPrincipal(id);
        return p.IsInRole(WindowsBuiltInRole.Administrator);
    }

    /// <summary>
    /// Add a shield icon to a button
    /// </summary>
    /// <param name="b">The button</param>
    public static void AddShieldToButton(KryptonButton b) => SendMessage(b.Handle, BCM_SETSHIELD, 0, 0xFFFFFFFF);

    //static internal void AddShieldToButton(object b) => SendMessage(b.Handle, BCM_SETSHIELD, 0, 0xFFFFFFFF);

    /// <summary>
    /// Restart the current process with administrator credentials
    /// </summary>
    internal static void RestartElevated()
    {
        ProcessStartInfo startInfo = new ProcessStartInfo()
        {
            UseShellExecute = true,
            WorkingDirectory = Environment.CurrentDirectory,
            FileName = Application.ExecutablePath,
            Verb = "runas"
        };

        try
        {
            Process p = Process.Start(startInfo);
        }
        catch (System.ComponentModel.Win32Exception ex)
        {
            return; //If cancelled, do nothing
        }

        Application.Exit();
    }
    #endregion
}