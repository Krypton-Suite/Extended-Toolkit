using System;
using System.IO;
using System.Runtime.InteropServices;

namespace Krypton.Toolkit.Suite.Extended.Shell
{
    [ComImport]
    [Guid("0000000c-0000-0000-C000-000000000046")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface IStream
    {
        // Reads a specified number of bytes from the stream object into memory 
        // starting at the current seek pointer
        [PreserveSig]
        Int32 Read(
            [MarshalAs(UnmanagedType.LPArray)]
            byte[] pv,
            int cb,
            IntPtr pcbRead);

        // Writes a specified number of bytes into the stream object starting at 
        // the current seek pointer
        [PreserveSig]
        Int32 Write(
            [MarshalAs(UnmanagedType.LPArray)]
            byte[] pv,
            int cb,
            IntPtr pcbWritten);

        // Changes the seek pointer to a new location relative to the beginning 
        // of the stream, the end of the stream, or the current seek pointer
        [PreserveSig]
        Int32 Seek(
            long dlibMove,
            SeekOrigin dwOrigin,
            IntPtr plibNewPosition);

        // Changes the size of the stream object
        [PreserveSig]
        Int32 SetSize(
            long libNewSize);

        // Copies a specified number of bytes from the current seek pointer in 
        // the stream to the current seek pointer in another stream
        [PreserveSig]
        Int32 CopyTo(
            IStream pstm,
            long cb,
            IntPtr pcbRead,
            IntPtr pcbWritten);

        // Ensures that any changes made to a stream object open in transacted 
        // mode are reflected in the parent storage object
        [PreserveSig]
        Int32 Commit(
            ShellAPI.STGC grfCommitFlags);

        // Discards all changes that have been made to a transacted stream since 
        // the last call to IStream::Commit
        [PreserveSig]
        Int32 Revert();

        // Restricts access to a specified range of bytes in the stream. Supporting 
        // this functionality is optional since some file systems do not provide it
        [PreserveSig]
        Int32 LockRegion(
            long libOffset,
            long cb,
            ShellAPI.LOCKTYPE dwLockType);

        // Removes the access restriction on a range of bytes previously restricted 
        // with IStream::LockRegion
        [PreserveSig]
        Int32 UnlockRegion(
            long libOffset,
            long cb,
            ShellAPI.LOCKTYPE dwLockType);

        // Retrieves the STATSTG structure for this stream
        [PreserveSig]
        Int32 Stat(
            out ShellAPI.STATSTG pstatstg,
            ShellAPI.STATFLAG grfStatFlag);

        // Creates a new stream object that references the same bytes as the original 
        // stream but provides a separate seek pointer to those bytes
        [PreserveSig]
        Int32 Clone(
            out IntPtr ppstm);
    }
}