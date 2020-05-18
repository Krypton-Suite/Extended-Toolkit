using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Krypton.Toolkit.Suite.Extended.Shell
{
    [ComImport]
    [GuidAttribute("4657278B-411B-11d2-839A-00C04FD918D0")]
    [InterfaceTypeAttribute(ComInterfaceType.InterfaceIsIUnknown)]
    public interface IDropTargetHelper
    {
        // Notifies the drag-image manager that the drop target's IDropTarget::DragEnter method has been called
        [PreserveSig]
        Int32 DragEnter(
            IntPtr hwndTarget,
            IntPtr pDataObject,
            ref ShellAPI.POINT ppt,
            DragDropEffects dwEffect);

        // Notifies the drag-image manager that the drop target's IDropTarget::DragLeave method has been called
        [PreserveSig]
        Int32 DragLeave();

        // Notifies the drag-image manager that the drop target's IDropTarget::DragOver method has been called
        [PreserveSig]
        Int32 DragOver(
            ref ShellAPI.POINT ppt,
            DragDropEffects dwEffect);

        // Notifies the drag-image manager that the drop target's IDropTarget::Drop method has been called
        [PreserveSig]
        Int32 Drop(
            IntPtr pDataObject,
            ref ShellAPI.POINT ppt,
            DragDropEffects dwEffect);

        // Notifies the drag-image manager to show or hide the drag image
        [PreserveSig]
        Int32 Show(
            bool fShow);
    }
}