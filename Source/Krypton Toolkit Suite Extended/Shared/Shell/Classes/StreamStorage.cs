using System;
using System.IO;
using System.Runtime.InteropServices;

namespace Krypton.Toolkit.Suite.Extended.Shell
{
    internal class StreamStorageProvider : IFileInfoProvider, IDirInfoProvider
    {
        #region Fields

        private ShellItem providerItem;
        private FileAccess fileAccess;

        #endregion

        public StreamStorageProvider(FileAccess fileAccess)
        {
            this.fileAccess = fileAccess;
        }

        #region Free

        internal void ReleaseStorage()
        {
            dirInfoRetrieved = false;
        }

        internal void ReleaseStream()
        {
            if (tempStreamReader != null)
            {
                tempStreamReader.CloseStream();
                tempStreamReader = null;
            }

            if (tempParentStorage != null)
            {
                Marshal.ReleaseComObject(tempParentStorage);
                Marshal.Release(tempParentStoragePtr);
                tempParentStorage = null;
            }
        }

        #endregion

        #region IFileInfoProvider Members

        private ShellStreamReader tempStreamReader;
        private IStorage tempParentStorage;
        private IntPtr tempParentStoragePtr;

        public ShellAPI.STATSTG GetFileInfo()
        {
            if (tempStreamReader != null)
                return tempStreamReader.StreamInfo;
            else if (providerItem != null)
            {
                if (tempParentStorage == null)
                    ShellHelper.GetIStorage(providerItem.ParentItem, out tempParentStoragePtr, out tempParentStorage);

                tempStreamReader = new ShellStreamReader(providerItem, tempParentStorage, fileAccess);
                return tempStreamReader.StreamInfo;
            }
            else
                throw new Exception("Not possible to retrieve the STATSTG.");
        }

        public Stream GetFileStream()
        {
            if (tempStreamReader != null)
                return tempStreamReader;
            else if (providerItem != null)
            {
                if (tempParentStorage == null)
                    ShellHelper.GetIStorage(providerItem.ParentItem, out tempParentStoragePtr, out tempParentStorage);

                tempStreamReader = new ShellStreamReader(providerItem, tempParentStorage, fileAccess);
                return tempStreamReader;
            }
            else
                throw new Exception("Not possible to open a filestream.");
        }

        #endregion

        #region IDirInfoProvider Members

        private ShellAPI.STATSTG dirInfo;
        private bool dirInfoRetrieved = false;

        public ShellAPI.STATSTG GetDirInfo()
        {
            if (dirInfoRetrieved)
                return dirInfo;
            else if (providerItem != null)
            {
                IntPtr tempPtr;
                IStorage tempStorage;

                if (ShellHelper.GetIStorage(providerItem, out tempPtr, out tempStorage))
                {
                    tempStorage.Stat(out dirInfo, ShellAPI.STATFLAG.NONAME);
                    Marshal.ReleaseComObject(tempStorage);
                    Marshal.Release(tempPtr);
                }
                else
                    throw new Exception("Not possible to retrieve the STATSTG.");

                dirInfoRetrieved = true;
                return dirInfo;
            }
            else
                throw new Exception("Not possible to retrieve the STATSTG.");
        }

        #endregion

        #region Properties

        public ShellItem ProviderItem
        {
            get { return providerItem; }
            set { providerItem = value; }
        }

        public FileAccess FileAccess
        {
            get { return fileAccess; }
            set { fileAccess = value; }
        }

        #endregion
    }

    public class ShellStreamReader : Stream, IDisposable
    {
        #region Fields

        private ShellItem shellItem;

        private IntPtr streamPtr;
        private IStream stream;

        private bool canRead, canWrite;

        private ShellAPI.STATSTG streamInfo;
        private bool streamInfoRead = false;

        private long currentPos;

        private bool disposed = false;

        #endregion

        internal ShellStreamReader(ShellItem shellItem, IStorage parentStorage, FileAccess access)
        {
            this.shellItem = shellItem;

            OpenStream(parentStorage, ref access);

            this.canRead = (access == FileAccess.Read || access == FileAccess.ReadWrite);
            this.canWrite = (access == FileAccess.Write || access == FileAccess.ReadWrite);
            currentPos = 0;
        }

        ~ShellStreamReader()
        {
            CloseStream();
        }

        #region Stream Members

        public override bool CanRead
        {
            get { return canRead; }
        }

        public override bool CanSeek
        {
            get { return true; }
        }

        public override bool CanWrite
        {
            get { return canWrite; }
        }

        public override void Flush()
        {

        }

        public override long Length
        {
            get
            {
                if (CanRead)
                    return StreamInfo.cbSize;
                else
                    return 0;
            }
        }

        public override long Position
        {
            get
            {
                return currentPos;
            }
            set
            {
                Seek(value, SeekOrigin.Begin);
            }
        }

        public override int Read(byte[] buffer, int offset, int count)
        {
            if (CanRead)
            {
                byte[] readBytes = new byte[count];

                IntPtr readNrPtr = Marshal.AllocCoTaskMem(32);
                stream.Read(readBytes, count, readNrPtr);

                int readNr = (int)Marshal.PtrToStructure(readNrPtr, typeof(Int32));
                Marshal.FreeCoTaskMem(readNrPtr);

                Array.Copy(readBytes, 0, buffer, offset, readNr);
                currentPos += readNr;
                return readNr;
            }
            else
                return 0;
        }

        public override void SetLength(long value)
        {
            if (CanWrite)
                stream.SetSize(value);
        }

        public override void Write(byte[] buffer, int offset, int count)
        {
            if (CanWrite)
            {
                byte[] writeBytes = new byte[count];
                Array.Copy(buffer, offset, writeBytes, 0, count);

                IntPtr writtenNrPtr = Marshal.AllocCoTaskMem(64);
                stream.Write(writeBytes, count, writtenNrPtr);

                long writtenNr = (long)Marshal.PtrToStructure(writtenNrPtr, typeof(Int64));
                Marshal.FreeCoTaskMem(writtenNrPtr);

                currentPos += writtenNr;
            }
        }

        public override long Seek(long offset, SeekOrigin origin)
        {
            if (CanSeek)
            {
                IntPtr newPosPtr = Marshal.AllocCoTaskMem(64);
                stream.Seek(offset, origin, newPosPtr);

                long newPos = (long)Marshal.PtrToStructure(newPosPtr, typeof(Int64));
                Marshal.FreeCoTaskMem(newPosPtr);

                return (currentPos = newPos);
            }
            else
                return -1;
        }

        #endregion

        #region IDisposable Members

        void IDisposable.Dispose()
        {
            if (!disposed)
            {
                disposed = true;

                if (stream != null)
                {
                    Marshal.ReleaseComObject(stream);
                    stream = null;
                }

                if (streamPtr != IntPtr.Zero)
                {
                    Marshal.Release(streamPtr);
                    streamPtr = IntPtr.Zero;
                }

                GC.SuppressFinalize(this);
            }
        }

        #endregion

        #region Open/Close Stream

        public override void Close()
        {

        }

        internal void CloseStream()
        {
            base.Close();

            if (stream != null)
            {
                Marshal.ReleaseComObject(stream);
                Marshal.Release(streamPtr);
            }
        }

        internal ShellAPI.STATSTG StreamInfo
        {
            get
            {
                if (!streamInfoRead)
                {
                    stream.Stat(out streamInfo, ShellAPI.STATFLAG.NONAME);
                    streamInfoRead = true;
                }
                return streamInfo;
            }
        }

        private void OpenStream(IStorage parentStorage, ref FileAccess access)
        {
            ShellAPI.STGM grfmode = ShellAPI.STGM.SHARE_DENY_WRITE;

            switch (access)
            {
                case FileAccess.ReadWrite:
                    grfmode |= ShellAPI.STGM.READWRITE;
                    break;

                case FileAccess.Write:
                    grfmode |= ShellAPI.STGM.WRITE;
                    break;
            }

            if (parentStorage != null)
            {
                if (parentStorage.OpenStream(
                        shellItem.Text + (shellItem.IsLink ? ".lnk" : string.Empty),
                        IntPtr.Zero,
                        grfmode,
                        0,
                        out streamPtr) == ShellAPI.S_OK)
                {
                    stream = (IStream)Marshal.GetTypedObjectForIUnknown(streamPtr, typeof(IStream));
                }
                else if (access != FileAccess.Read)
                {
                    if (parentStorage.OpenStream(
                        shellItem.Text + (shellItem.IsLink ? ".lnk" : string.Empty),
                        IntPtr.Zero,
                        ShellAPI.STGM.SHARE_DENY_WRITE,
                        0,
                        out streamPtr) == ShellAPI.S_OK)
                    {
                        access = FileAccess.Read;
                        stream = (IStream)Marshal.GetTypedObjectForIUnknown(streamPtr, typeof(IStream));
                    }
                    else
                        throw new IOException(String.Format("Can't open stream: {0}", shellItem));
                }
                else
                    throw new IOException(String.Format("Can't open stream: {0}", shellItem));
            }
            else
            {
                access = FileAccess.Read;

                if (!ShellHelper.GetIStream(shellItem, out streamPtr, out stream))
                    throw new IOException(String.Format("Can't open stream: {0}", shellItem));
            }
        }

        #endregion
    }
}
