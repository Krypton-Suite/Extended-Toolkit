using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Krypton.Toolkit.Suite.Extended.Shell
{
    [ComImport]
    [GuidAttribute("00000121-0000-0000-C000-000000000046")]
    [InterfaceTypeAttribute(ComInterfaceType.InterfaceIsIUnknown)]
    public interface IDropSource
    {
        // Determines whether a drag-and-drop operation should continue
        [PreserveSig]
        Int32 QueryContinueDrag(
            bool fEscapePressed,
            ShellAPI.MK grfKeyState);

        // Gives visual feedback to an end user during a drag-and-drop operation
        [PreserveSig]
        Int32 GiveFeedback(
            DragDropEffects dwEffect);
    }
}