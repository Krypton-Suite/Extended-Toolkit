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

/// <summary>
/// Methods that can be used anywhere.
/// </summary>
public class GlobalMethods
{
    #region Variables
    private bool _isTargetPlatformSupported, _isTargetPlatform64BIT, _isAssemblies64BIT, _internetConnectionState;
    #endregion

    #region Properties
    /// <summary>
    /// The property to access and alter the variable _isTargetPlatformSupported.
    /// </summary>
    private bool IsTargetPlatformSupported
    {
        get => _isTargetPlatformSupported;

        set => _isTargetPlatformSupported = value;
    }

    /// <summary>
    /// The property to access and alter the variable _isTargetPlatform64BIT.
    /// </summary>
    private bool IsTargetPlatform64BIT
    {
        get => _isTargetPlatform64BIT;

        set => _isTargetPlatform64BIT = value;
    }

    /// <summary>
    /// The property to access and alter the variable _isAssemblies64BIT.
    /// </summary>
    private bool IsAssemblies64BIT
    {
        get => _isAssemblies64BIT;

        set => _isAssemblies64BIT = value;
    }

    /// <summary>
    /// Gets or sets a value indicating whether [internet connection state].
    /// </summary>
    /// <value>
    ///   <c>true</c> if [internet connection state]; otherwise, <c>false</c>.
    /// </value>
    private bool InternetConnectionState
    {
        get => _internetConnectionState;

        set => _internetConnectionState = value;
    }
    #endregion

    #region Constructor
    /// <summary>
    /// The default constructor.
    /// </summary>
    public GlobalMethods()
    {

    }
    #endregion

    #region Methods
    /// <summary>
    /// Checks to see if the client's version of Windows is supported or not.
    /// </summary>
    /// <param name="useLegacyVistaSupport">Include Windows Vista in the supported list (the default value is 'false').</param>
    /// <returns>True if the version of Windows is supported, false if not.</returns>
    public bool CheckIfTargetPlatformIsSupported(bool useLegacyVistaSupport = false)
    {
        try
        {
            if (useLegacyVistaSupport)
            {
                if (Environment.OSVersion.Version.Major >= 6)
                {
                    SetIsTargetPlatformSupported(true);
                }
                else
                {
                    SetIsTargetPlatformSupported(false);
                }
            }
            else
            {
                if (Environment.Version.Major >= 6 && Environment.Version.Minor >= 1)
                {
                    SetIsTargetPlatformSupported(true);
                }
                else
                {
                    SetIsTargetPlatformSupported(false);
                }
            }
        }
        catch (Exception exc)
        {
            DebugUtilities.NotImplemented(exc.ToString());

            SetIsTargetPlatformSupported(false);
        }

        return GetIsTargetPlatformSupported();
    }

    /// <summary>
    /// Checks to see whether the client is using a 64-bit version of Windows.
    /// </summary>
    /// <returns>True if a 64-bit version of Windows is detected, false if a 32-bit version of Windows is detected.</returns>
    public bool IsTargetPlatformRunningIn64BITMode()
    {
        try
        {
            if (Environment.Is64BitOperatingSystem)
            {
                SetIsTargetPlatform64BIT(true);
            }
            else
            {
                SetIsTargetPlatform64BIT(false);
            }
        }
        catch (Exception exc)
        {
            DebugUtilities.NotImplemented(exc.ToString());

            SetIsTargetPlatform64BIT(false);
        }

        return GetIsTargetPlatform64BIT();
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public bool AreAssemblies64BIT()
    {
        try
        {

        }
        catch (Exception exc)
        {
            DebugUtilities.NotImplemented(exc.ToString());

            SetIsAssemblies64BIT(false);
        }

        return GetIsAssemblies64BIT();
    }

    /// <summary>
    /// Elevates the application to use administrative privileges. To be used with <see cref="Button"/> button click.
    /// </summary>
    /// <param name="processName">The process name that you wish to elevate.</param>
    public void ElevateProcessWithAdministrativeRights(string processName)
    {
        WindowsPrincipal principal = new WindowsPrincipal(WindowsIdentity.GetCurrent());

        bool hasAdministrativeRight = principal.IsInRole(WindowsBuiltInRole.Administrator);

        if (!hasAdministrativeRight)
        {
            // Relaunch the application with administrative rights
            ProcessStartInfo processStartInfo = new ProcessStartInfo();

            processStartInfo.Verb = "runas";

            processStartInfo.FileName = processName;

            try
            {
                Process.Start(processStartInfo);
            }
            catch (Win32Exception wexc)
            {
                MessageBox.Show($"Error: {wexc.Message}", "An Error has Occurred", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return;
        }
    }

    /// <summary>
    /// Gets the name of the os friendly.
    /// </summary>
    /// <returns></returns>
    public string GetOSFriendlyName()
    {
        string productName = HKLM_GetString(@"SOFTWARE\Microsoft\Windows NT\CurrentVersion", "ProductName"),
            csdVersion = HKLM_GetString(@"SOFTWARE\Microsoft\Windows NT\CurrentVersion", "CSDVersion");

        if (productName != string.Empty)
        {
            return (productName.StartsWith("Microsoft") ? "" : "Microsoft ") + productName + (csdVersion != "" ? $" {csdVersion}"
                : "");
        }

        return string.Empty;
    }

    private string HKLM_GetString(string path, string key)
    {
        try
        {
            RegistryKey? registryKey = Registry.LocalMachine.OpenSubKey(path);

            if (registryKey == null)
            {
                return string.Empty;
            }

            return (string)registryKey.GetValue(key);
        }
        catch (Exception e)
        {
            KryptonExceptionDialog.Show(e, null, null);

            return string.Empty;
        }
    }

    // TODO: Fix this method
    /*
    /// <summary>
    /// This method checks if the client operating system supports the Windows API CodePack set of API's.
    /// </summary>
    /// <returns>True, if the client operating system supports the Windows API CodePack set of API's.</returns>
    public bool IsWindowsAPICodePackSupported()
    {
        if (TaskbarManager.IsPlatformSupported)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    */
    #endregion

    #region Setters and Getters
    /// <summary>
    /// Sets the IsTargetPlatformSupported to the value of value.
    /// </summary>
    /// <param name="value">The desired value of IsTargetPlatformSupported.</param>
    public void SetIsTargetPlatformSupported(bool value)
    {
        IsTargetPlatformSupported = value;
    }

    /// <summary>
    /// Returns the value of the IsTargetPlatformSupported.
    /// </summary>
    /// <returns>The value of the IsTargetPlatformSupported.</returns>
    public bool GetIsTargetPlatformSupported()
    {
        return IsTargetPlatformSupported;
    }

    /// <summary>
    /// Sets the IsTargetPlatform64BIT to the value of value.
    /// </summary>
    /// <param name="value">The desired value of IsTargetPlatform64BIT.</param>
    public void SetIsTargetPlatform64BIT(bool value)
    {
        IsTargetPlatform64BIT = value;
    }

    /// <summary>
    /// Returns the value of the IsTargetPlatform64BIT.
    /// </summary>
    /// <returns>The value of the IsTargetPlatform64BIT.</returns>
    public bool GetIsTargetPlatform64BIT()
    {
        return IsTargetPlatform64BIT;
    }

    /// <summary>
    /// Sets the IsAssemblies64BIT to the value of value.
    /// </summary>
    /// <param name="value">The desired value of IsAssemblies64BIT.</param>
    public void SetIsAssemblies64BIT(bool value)
    {
        IsAssemblies64BIT = value;
    }

    /// <summary>
    /// Returns the value of the IsAssemblies64BIT.
    /// </summary>
    /// <returns>The value of the IsAssemblies64BIT.</returns>
    public bool GetIsAssemblies64BIT()
    {
        return IsAssemblies64BIT;
    }

    /// <summary>
    /// Sets the InternetConnectionState to the value of value.
    /// </summary>
    /// <param name="value">The desired value of InternetConnectionState.</param>
    public void SetInternetConnectionState(bool value)
    {
        InternetConnectionState = value;
    }

    /// <summary>
    /// Returns the value of the InternetConnectionState.
    /// </summary>
    /// <returns>The value of the InternetConnectionState.</returns>
    public bool GetInternetConnectionState()
    {
        return InternetConnectionState;
    }
    #endregion

    #region De-constructor
    /// <summary>
    /// Finalizes an instance of the <see cref="GlobalMethods"/> class.
    /// </summary>
    ~GlobalMethods()
    {
        GC.SuppressFinalize(this);
    }
    #endregion
}


#region Static Class
/// <summary>
/// Static methods that can be used anywhere.
/// </summary>
public static class GlobalMethodsStatic
{
    #region Variables
    public static bool _isTargetPlatformSupported, _isTargetPlatform64BIT, _isAssemblies64BIT, _internetConnectionState;
    #endregion

    #region Properties
    /// <summary>
    /// The property to access and alter the variable _isTargetPlatformSupported.
    /// </summary>
    private static bool IsTargetPlatformSupported
    {
        get => _isTargetPlatformSupported;

        set => _isTargetPlatformSupported = value;
    }

    /// <summary>
    /// The property to access and alter the variable _isTargetPlatform64BIT.
    /// </summary>
    private static bool IsTargetPlatform64BIT
    {
        get => _isTargetPlatform64BIT;

        set => _isTargetPlatform64BIT = value;
    }

    /// <summary>
    /// The property to access and alter the variable _isAssemblies64BIT.
    /// </summary>
    private static bool IsAssemblies64BIT
    {
        get => _isAssemblies64BIT;

        set => _isAssemblies64BIT = value;
    }

    /// <summary>
    /// Gets or sets a value indicating whether [internet connection state].
    /// </summary>
    /// <value>
    ///   <c>true</c> if [internet connection state]; otherwise, <c>false</c>.
    /// </value>
    private static bool InternetConnectionState
    {
        get => _internetConnectionState;

        set => _internetConnectionState = value;
    }
    #endregion

    #region Methods
    /// <summary>
    /// Checks to see if the client's version of Windows is supported or not.
    /// </summary>
    /// <param name="useLegacyVistaSupport">Include Windows Vista in the supported list (the default value is 'false').</param>
    /// <returns>True if the version of Windows is supported, false if not.</returns>
    public static bool CheckIfTargetPlatformIsSupported(bool useLegacyVistaSupport = false)
    {
        try
        {
            if (useLegacyVistaSupport)
            {
                if (Environment.OSVersion.Version.Major >= 6)
                {
                    SetIsTargetPlatformSupported(true);
                }
                else
                {
                    SetIsTargetPlatformSupported(false);
                }
            }
            else
            {
                if (Environment.Version.Major >= 6 && Environment.Version.Minor >= 1)
                {
                    SetIsTargetPlatformSupported(true);
                }
                else
                {
                    SetIsTargetPlatformSupported(false);
                }
            }
        }
        catch (Exception exc)
        {
            KryptonExceptionDialog.Show(exc, null, null);

            SetIsTargetPlatformSupported(false);
        }

        return GetIsTargetPlatformSupported();
    }

    /// <summary>
    /// Checks to see whether the client is using a 64-bit version of Windows.
    /// </summary>
    /// <returns>True if a 64-bit version of Windows is detected, false if a 32-bit version of Windows is detected.</returns>
    public static bool IsTargetPlatformRunningIn64BITMode()
    {
        try
        {
            if (Environment.Is64BitOperatingSystem)
            {
                SetIsTargetPlatform64BIT(true);
            }
            else
            {
                SetIsTargetPlatform64BIT(false);
            }
        }
        catch (Exception exc)
        {
            DebugUtilities.NotImplemented(exc.ToString());

            SetIsTargetPlatform64BIT(false);
        }

        return GetIsTargetPlatform64BIT();
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public static bool AreAssemblies64BIT()
    {
        try
        {
            SetIsAssemblies64BIT(Environment.Is64BitProcess);
        }
        catch (Exception exc)
        {
            DebugUtilities.NotImplemented(exc.ToString());

            SetIsAssemblies64BIT(false);
        }

        return GetIsAssemblies64BIT();
    }

    /// <summary>
    /// Elevates the application to use administrative privileges. To be used with <see cref="Button"/> button click.
    /// </summary>
    /// <param name="processName">The process name that you wish to elevate.</param>
    public static void ElevateProcessWithAdministrativeRights(string processName)
    {
        WindowsPrincipal principal = new WindowsPrincipal(WindowsIdentity.GetCurrent());

        bool hasAdministrativeRight = principal.IsInRole(WindowsBuiltInRole.Administrator);

        if (!hasAdministrativeRight)
        {
            // Relaunch the application with administrative rights
            ProcessStartInfo processStartInfo = new ProcessStartInfo();

            processStartInfo.Verb = "runas";

            processStartInfo.FileName = processName;

            try
            {
                Process.Start(processStartInfo);
            }
            catch (Win32Exception wexc)
            {
                KryptonExceptionDialog.Show(wexc, null, null);

                DebugUtilities.NotImplemented(wexc.ToString());
            }
        }
    }

    /// <summary>
    /// Gets the os friendly name for static methods.
    /// </summary>
    /// <returns></returns>
    public static string GetOSFriendlyName()
    {
        string productName = HKLM_GetString(@"SOFTWARE\Microsoft\Windows NT\CurrentVersion", "ProductName"),
            csdVersion = HKLM_GetString(@"SOFTWARE\Microsoft\Windows NT\CurrentVersion", "CSDVersion");

        if (productName != string.Empty)
        {
            return (productName.StartsWith("Microsoft") ? "" : "Microsoft ") + productName + (csdVersion != "" ? $" {csdVersion}"
                : "");
        }

        return string.Empty;
    }

    private static string HKLM_GetString(string path, string key)
    {
        try
        {
            RegistryKey? registryKey = Registry.LocalMachine.OpenSubKey(path);

            if (registryKey == null)
            {
                return string.Empty;
            }

            return (string)registryKey.GetValue(key);
        }
        catch (Exception e)
        {
            KryptonExceptionDialog.Show(e, null, null);

            return string.Empty;
        }
    }

    // TODO: Fix this method
    /*
    /// <summary>
    /// This method checks if the client operating system supports the Windows API CodePack set of API's.
    /// </summary>
    /// <returns>True, if the client operating system supports the Windows API CodePack set of API's.</returns>
    public static bool IsWindowsAPICodePackSupported()
    {
        if (TaskbarManager.IsPlatformSupported)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    */

    /// <summary>
    /// Not the implemented yet.
    /// </summary>
    /// <param name="featureName">Name of the feature.</param>
    public static void NotImplementedYet(string? featureName = null)
    {
        if (featureName != null)
        {
            KryptonMessageBox.Show($"The feature: {featureName} is not implemented or fully functional yet. Please check back again later.", "Incomplete Feature", KryptonMessageBoxButtons.OK, KryptonMessageBoxIcon.Information);
        }
        else
        {
            KryptonMessageBox.Show("This is not implemented or fully functional yet. Please check back again later.", "Incomplete Feature", KryptonMessageBoxButtons.OK, KryptonMessageBoxIcon.Information);
        }
    }

    /// <summary>Anchors the selected control.</summary>
    /// <param name="control">The control.</param>
    /// <param name="anchorStyles">The anchor styles.</param>
    public static void AnchorSelectedControl(Control control, AnchorStyles anchorStyles) => control.Anchor = anchorStyles;

    /// <summary>Sets the selected control location.</summary>
    /// <param name="control">The control.</param>
    /// <param name="locatioonPoint">The locatioon point.</param>
    public static void SetSelectedControlLocation(Control control, Point locatioonPoint) => control.Location = locatioonPoint;
    #endregion

    #region Setters and Getters
    /// <summary>
    /// Sets the IsTargetPlatformSupported to the value of value.
    /// </summary>
    /// <param name="value">The desired value of IsTargetPlatformSupported.</param>
    public static void SetIsTargetPlatformSupported(bool value)
    {
        IsTargetPlatformSupported = value;
    }

    /// <summary>
    /// Returns the value of the IsTargetPlatformSupported.
    /// </summary>
    /// <returns>The value of the IsTargetPlatformSupported.</returns>
    public static bool GetIsTargetPlatformSupported()
    {
        return IsTargetPlatformSupported;
    }

    /// <summary>
    /// Sets the IsTargetPlatform64BIT to the value of value.
    /// </summary>
    /// <param name="value">The desired value of IsTargetPlatform64BIT.</param>
    public static void SetIsTargetPlatform64BIT(bool value)
    {
        IsTargetPlatform64BIT = value;
    }

    /// <summary>
    /// Returns the value of the IsTargetPlatform64BIT.
    /// </summary>
    /// <returns>The value of the IsTargetPlatform64BIT.</returns>
    public static bool GetIsTargetPlatform64BIT()
    {
        return IsTargetPlatform64BIT;
    }

    /// <summary>
    /// Sets the IsAssemblies64BIT to the value of value.
    /// </summary>
    /// <param name="value">The desired value of IsAssemblies64BIT.</param>
    public static void SetIsAssemblies64BIT(bool value)
    {
        IsAssemblies64BIT = value;
    }

    /// <summary>
    /// Returns the value of the IsAssemblies64BIT.
    /// </summary>
    /// <returns>The value of the IsAssemblies64BIT.</returns>
    public static bool GetIsAssemblies64BIT()
    {
        return IsAssemblies64BIT;
    }

    /// <summary>
    /// Sets the InternetConnectionState to the value of value.
    /// </summary>
    /// <param name="value">The desired value of InternetConnectionState.</param>
    private static void SetInternetConnectionState(bool value)
    {
        InternetConnectionState = value;
    }

    /// <summary>
    /// Returns the value of the InternetConnectionState.
    /// </summary>
    /// <returns>The value of the InternetConnectionState.</returns>
    private static bool GetInternetConnectionState()
    {
        return InternetConnectionState;
    }
    #endregion
}
#endregion