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

namespace Krypton.Toolkit.Suite.Extended.Networking;

public class NetworkDrives
{
    #region API
    [DllImport("mpr.dll")] private static extern int WNetAddConnection2A(ref StructNetResource pstNetRes, string? psPassword, string? psUsername, int piFlags);
    [DllImport("mpr.dll")] private static extern int WNetCancelConnection2A(string psName, int piFlags, int pfForce);
    [DllImport("mpr.dll")] private static extern int WNetConnectionDialog(int phWnd, int piType);
    [DllImport("mpr.dll")] private static extern int WNetDisconnectDialog(int phWnd, int piType);
    [DllImport("mpr.dll")] private static extern int WNetRestoreConnectionW(int phWnd, string? psLocalDrive);

    [StructLayout(LayoutKind.Sequential)]
    private struct StructNetResource
    {
        public int iScope;
        public int iType;
        public int iDisplayType;
        public int iUsage;
        public string sLocalName;
        public string sRemoteName;
        public string sComment;
        public string sProvider;
    }

    private const int ResourcetypeDisk = 0x1;

    //Standard	
    private const int CONNECT_INTERACTIVE = 0x00000008;
    private const int CONNECT_PROMPT = 0x00000010;
    private const int CONNECT_UPDATE_PROFILE = 0x00000001;
    //IE4+
    private const int CONNECT_REDIRECT = 0x00000080;
    //NT5 only
    private const int CONNECT_COMMANDLINE = 0x00000800;
    private const int CONNECT_CMD_SAVECRED = 0x00001000;

    #endregion

    #region Properties and options
    private bool _lfSaveCredentials = false;
    /// <summary>
    /// Option to save credentials are reconnection...
    /// </summary>
    public bool SaveCredentials { get => _lfSaveCredentials; set => _lfSaveCredentials = value; }

    private bool _lfPersistent = false;
    /// <summary>
    /// Option to reconnect drive after log off / reboot ...
    /// </summary>
    public bool Persistent { get => _lfPersistent; set => _lfPersistent = value; }

    private bool _lfForce = false;
    /// <summary>
    /// Option to force connection if drive is already mapped...
    /// or force disconnection if network path is not responding...
    /// </summary>
    public bool Force { get => _lfForce; set => _lfForce = value; }

    private bool _lsPromptForCredentials = false;
    /// <summary>
    /// Option to prompt for user credintals when mapping a drive
    /// </summary>
    public bool PromptForCredentials { get => _lsPromptForCredentials; set => _lsPromptForCredentials = value; }

    private string _lsDrive = "s:";
    /// <summary>
    /// Drive to be used in mapping / unmapping...
    /// </summary>
    public string LocalDrive
    {
        get => _lsDrive;

        set
        {
            if (value.Length >= 1)
            {
                _lsDrive = $"{value.Substring(0, 1)}:";
            }
            else
            {
                _lsDrive = "";
            }
        }
    }
    private string _lsShareName = "\\\\Computer\\C$";
    /// <summary>
    /// Share address to map drive to.
    /// </summary>
    public string ShareName { get => _lsShareName; set => _lsShareName = value; }
    #endregion

    #region Function mapping
    /// <summary>
    /// Map network drive
    /// </summary>
    public void MapDrive() => ZMapDrive(null, null);
    /// <summary>
    /// Map network drive (using supplied Password)
    /// </summary>
    public void MapDrive(string password) => ZMapDrive(null, password);
    /// <summary>
    /// Map network drive (using supplied Username and Password)
    /// </summary>
    public void MapDrive(string username, string password) => ZMapDrive(username, password);
    /// <summary>
    /// Unmap network drive
    /// </summary>
    public void UnMapDrive() => ZUnMapDrive(_lfForce);
    /// <summary>
    /// Check / restore persistent network drive
    /// </summary>
    public void RestoreDrives() => ZRestoreDrive();
    /// <summary>
    /// Display windows dialog for mapping a network drive
    /// </summary>
    public void ShowConnectDialog(KryptonForm parentForm) => ZDisplayDialog(parentForm, 1);
    /// <summary>
    /// Display windows dialog for disconnecting a network drive
    /// </summary>
    public void ShowDisconnectDialog(KryptonForm parentForm) => ZDisplayDialog(parentForm, 2);


    #endregion

    #region Core functions

    // Map network drive
    private void ZMapDrive(string? psUsername, string? psPassword)
    {
        //create struct data
        StructNetResource stNetRes = new StructNetResource();
        stNetRes.iScope = 2;
        stNetRes.iType = ResourcetypeDisk;
        stNetRes.iDisplayType = 3;
        stNetRes.iUsage = 1;
        stNetRes.sRemoteName = _lsShareName;
        stNetRes.sLocalName = _lsDrive;
        //prepare params
        int iFlags = 0;
        if (_lfSaveCredentials) { iFlags += CONNECT_CMD_SAVECRED; }
        if (_lfPersistent) { iFlags += CONNECT_UPDATE_PROFILE; }
        if (_lsPromptForCredentials) { iFlags += CONNECT_INTERACTIVE + CONNECT_PROMPT; }
        if (psUsername == "") { psUsername = null; }
        if (psPassword == "") { psPassword = null; }
        //if force, unmap ready for new connection
        if (_lfForce) { try { ZUnMapDrive(true); } catch { } }
        //call and return
        int i = WNetAddConnection2A(ref stNetRes, psPassword, psUsername, iFlags);
        if (i > 0) { throw new Win32Exception(i); }
    }

    // Unmap network drive
    private void ZUnMapDrive(bool pfForce)
    {
        //call unmap and return
        int iFlags = 0;
        if (_lfPersistent) { iFlags += CONNECT_UPDATE_PROFILE; }
        int i = WNetCancelConnection2A(_lsDrive, iFlags, Convert.ToInt32(pfForce));
        if (i > 0) { throw new Win32Exception(i); }
    }
    // Check / Restore a network drive
    private void ZRestoreDrive()
    {
        //call restore and return
        int i = WNetRestoreConnectionW(0, null);
        if (i > 0) { throw new Win32Exception(i); }
    }
    // Display windows dialog
    private void ZDisplayDialog(KryptonForm? poParentForm, int piDialog)
    {
        int i = -1;
        int iHandle = 0;
        //get parent handle
        if (poParentForm != null)
        {
            iHandle = poParentForm.Handle.ToInt32();
        }
        //show dialog
        if (piDialog == 1)
        {
            i = WNetConnectionDialog(iHandle, ResourcetypeDisk);
        }
        else if (piDialog == 2)
        {
            i = WNetDisconnectDialog(iHandle, ResourcetypeDisk);
        }
        if (i > 0) { throw new Win32Exception(i); }
        //set focus on parent form
        poParentForm?.BringToFront();
    }
    #endregion
}