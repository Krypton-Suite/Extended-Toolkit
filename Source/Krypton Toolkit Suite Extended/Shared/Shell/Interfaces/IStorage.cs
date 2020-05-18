using System;
using System.Runtime.InteropServices;

namespace Krypton.Toolkit.Suite.Extended.Shell
{
    [ComImport]
    [Guid("0000000b-0000-0000-C000-000000000046")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface IStorage
    {
        [PreserveSig]
        Int32 CreateStream(
            [MarshalAs(UnmanagedType.LPWStr)]
            string pwcsName,
            ShellAPI.STGM grfMode,
            int reserved1,
            int reserved2,
            out IntPtr ppstm);

        [PreserveSig]
        Int32 OpenStream(
            [MarshalAs(UnmanagedType.LPWStr)]
            string pwcsName,
            IntPtr reserved1,
            ShellAPI.STGM grfMode,
            int reserved2,
            out IntPtr ppstm);

        [PreserveSig]
        Int32 CreateStorage(
            [MarshalAs(UnmanagedType.LPWStr)]
            string pwcsName,
            ShellAPI.STGM grfMode,
            int reserved1,
            int reserved2,
            out IntPtr ppstg);

        [PreserveSig]
        Int32 OpenStorage(
            [MarshalAs(UnmanagedType.LPWStr)]
            string pwcsName,
            IStorage pstgPriority,
            ShellAPI.STGM grfMode,
            IntPtr snbExclude,
            int reserved,
            out IntPtr ppstg);

        [PreserveSig]
        Int32 CopyTo(
            int ciidExclude,
            ref Guid rgiidExclude,
            IntPtr snbExclude,
            IStorage pstgDest);

        [PreserveSig]
        Int32 MoveElementTo(
            [MarshalAs(UnmanagedType.LPWStr)]
            string pwcsName,
            IStorage pstgDest,
            [MarshalAs(UnmanagedType.LPWStr)]
            string pwcsNewName,
            ShellAPI.STGMOVE grfFlags);

        [PreserveSig]
        Int32 Commit(
            ShellAPI.STGC grfCommitFlags);

        [PreserveSig]
        Int32 Revert();

        [PreserveSig]
        Int32 EnumElements(
            int reserved1,
            IntPtr reserved2,
            int reserved3,
            out IntPtr ppenum);

        [PreserveSig]
        Int32 DestroyElement(
            [MarshalAs(UnmanagedType.LPWStr)]
            string pwcsName);

        [PreserveSig]
        Int32 RenameElement(
            [MarshalAs(UnmanagedType.LPWStr)]
            string pwcsOldName,
            [MarshalAs(UnmanagedType.LPWStr)]
            string pwcsNewName);

        [PreserveSig]
        Int32 SetElementTimes(
            [MarshalAs(UnmanagedType.LPWStr)]
            string pwcsName,
            ShellAPI.FILETIME pctime,
            ShellAPI.FILETIME patime,
            ShellAPI.FILETIME pmtime);

        [PreserveSig]
        Int32 SetClass(
            ref Guid clsid);

        [PreserveSig]
        Int32 SetStateBits(
            int grfStateBits,
            int grfMask);

        [PreserveSig]
        Int32 Stat(
            out ShellAPI.STATSTG pstatstg,
            ShellAPI.STATFLAG grfStatFlag);
    }
}