using System;
using System.Runtime.InteropServices;

namespace Krypton.Toolkit.Suite.Extended.Shell
{
    [ComImport]
    [GuidAttribute("DE5BF786-477A-11d2-839D-00C04FD918D0")]
    [InterfaceTypeAttribute(ComInterfaceType.InterfaceIsIUnknown)]
    public interface IDragSourceHelper
    {
        // Initializes the drag-image manager for a windowless control
        [PreserveSig]
        Int32 InitializeFromBitmap(
            ref ShellAPI.SHDRAGIMAGE pshdi,
            IntPtr pDataObject);

        // Initializes the drag-image manager for a control with a window
        [PreserveSig]
        Int32 InitializeFromWindow(
            IntPtr hwnd,
            ref ShellAPI.POINT ppt,
            IntPtr pDataObject);
    }
}