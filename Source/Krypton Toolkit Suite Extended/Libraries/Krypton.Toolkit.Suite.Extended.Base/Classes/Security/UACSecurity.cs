﻿using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Security.Principal;
using System.Windows.Forms;

namespace Krypton.Toolkit.Suite.Extended.Base
{
    /// <summary>Adapted from https://www.codeproject.com/Articles/18509/Add-a-UAC-shield-to-a-button-when-elevation-is-req.</summary>
    internal static class UACSecurity
    {
        #region Win32 Calls
        [DllImport("user32")]
        public static extern UInt32 SendMessage(IntPtr hWnd, UInt32 msg, UInt32 wParam, UInt32 lParam);
        #endregion

        #region Constants
        internal const int BCM_FIRST = 0x1600, BCM_SETSHIELD = (BCM_FIRST + 0x000C);
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
        static internal void AddShieldToButton(KryptonButton b) => SendMessage(b.Handle, BCM_SETSHIELD, 0, 0xFFFFFFFF);

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
            catch (Win32Exception ex)
            {
                return; //If cancelled, do nothing
            }

            Application.Exit();
        }
        #endregion
    }
}