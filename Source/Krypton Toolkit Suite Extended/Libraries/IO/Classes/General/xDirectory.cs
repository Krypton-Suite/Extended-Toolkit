using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Threading;

namespace Krypton.Toolkit.Suite.Extended.IO
{
    /// <summary>
    /// xDirectory - Copy Files and SubFolders.
    /// https://www.codeproject.com/Articles/10040/xDirectory-Copy-Copy-Folder-SubFolders-and-Files
    /// </summary>
    public class xDirectory
    {


        #region Private Members
        /// <summary>
        /// The Source Directory.
        /// </summary>
        private DirectoryInfo _source = null;

        /// <summary>
        /// The Destination Directory.
        /// </summary>
        private DirectoryInfo _destination = null;

        /// <summary>
        /// The File Filters for "GetFiles".
        /// </summary>
        private List<string> _fileFilters = new List<string>();

        /// <summary>
        /// The Folder Filter for "GetDirectories".
        /// </summary>
        private string _folderFilter = null;

        /// <summary>
        /// The Overwrite Setting: Whether or not to overwrite on copy.
        /// </summary>
        private bool _overwrite = false;

        /// <summary>
        /// The Status of the xDirectory "StartCopy" Object.
        /// </summary>
        private static xDirectoryStatus _copierStatus = xDirectoryStatus.STOPPED;

        /// <summary>
        /// The "Cancel" Setting. Set to true to Cancel the xDirectory.StartCopy Method.
        /// </summary>
        private static bool _cancelCopy = false;

        #endregion



        #region Constructor

        /// <summary>
        /// The Default Constructor for the xDirectory Object
        /// </summary>
        public xDirectory()
        { }

        #endregion



        #region Event Related Methods

        /// <summary>
        /// The 'Item Indexed' Event
        /// </summary>
        public event ItemIndexedEventHandler ItemIndexed;

        /// <summary>
        /// The 'On Item Indexed' Event Handler: Called when an Item (File or Folder) Is Indexed
        /// </summary>
        /// <param name="e">The 'Item Indexed' Event Arguments.</param>
        protected virtual void OnItemIndexed(ItemIndexedEventArgs e)
        {
            ItemIndexedEventHandler Handler = ItemIndexed;
            if (Handler != null)
            {
                foreach (ItemIndexedEventHandler Caster in Handler.GetInvocationList())
                {
                    ISynchronizeInvoke SyncInvoke = Caster.Target as ISynchronizeInvoke;
                    try
                    {
                        if (SyncInvoke != null && SyncInvoke.InvokeRequired)
                            SyncInvoke.Invoke(Handler, new object[] { this, e });
                        else
                            Caster(this, e);
                    }
                    catch
                    { }
                }
            }
        }

        /// <summary>
        /// The 'Index Complete' Event
        /// </summary>
        public event IndexCompleteEventHandler IndexComplete;

        /// <summary>
        /// The 'On Index Complete' Event Handler: Called when Indexing of the Source Folder is Complete.
        /// </summary>
        /// <param name="e">The 'Index Complete' Event Arguments.</param>
        protected virtual void OnIndexComplete(IndexCompleteEventArgs e)
        {
            IndexCompleteEventHandler Handler = IndexComplete;
            if (Handler != null)
            {
                foreach (IndexCompleteEventHandler Caster in Handler.GetInvocationList())
                {
                    ISynchronizeInvoke SyncInvoke = Caster.Target as ISynchronizeInvoke;
                    try
                    {
                        if (SyncInvoke != null && SyncInvoke.InvokeRequired)
                            SyncInvoke.Invoke(Handler, new object[] { this, e });
                        else
                            Caster(this, e);
                    }
                    catch
                    { }
                }
            }
        }

        /// <summary>
        /// The 'Item Copied' Event
        /// </summary>
        public event ItemCopiedEventHandler ItemCopied;

        /// <summary>
        /// The 'On Item Copied' Event Handler: Called when an Item (File or Folder) Is Copied from the Source to Destination
        /// </summary>
        /// <param name="e">The 'Item Copied' Event Arguments.</param>
        protected virtual void OnItemCopied(ItemCopiedEventArgs e)
        {
            ItemCopiedEventHandler Handler = ItemCopied;
            if (Handler != null)
            {
                foreach (ItemCopiedEventHandler Caster in Handler.GetInvocationList())
                {
                    ISynchronizeInvoke SyncInvoke = Caster.Target as ISynchronizeInvoke;
                    try
                    {
                        if (SyncInvoke != null && SyncInvoke.InvokeRequired)
                            SyncInvoke.Invoke(Handler, new object[] { this, e });
                        else
                            Caster(this, e);
                    }
                    catch
                    { }
                }
            }
        }

        /// <summary>
        /// The 'Copy Complete' Event
        /// </summary>
        public event CopyCompleteEventHandler CopyComplete;

        /// <summary>
        /// The 'On Copy Complete' Event Handler: Called when Copying of the Source Folder to Destination Folder is Complete.
        /// </summary>
        /// <param name="e">The 'Item Copied' Event Arguments.</param>
        protected virtual void OnCopyComplete(CopyCompleteEventArgs e)
        {
            CopyCompleteEventHandler Handler = CopyComplete;
            if (Handler != null)
            {
                foreach (CopyCompleteEventHandler Caster in Handler.GetInvocationList())
                {
                    ISynchronizeInvoke SyncInvoke = Caster.Target as ISynchronizeInvoke;
                    try
                    {
                        if (SyncInvoke != null && SyncInvoke.InvokeRequired)
                            SyncInvoke.Invoke(Handler, new object[] { this, e });
                        else
                            Caster(this, e);
                    }
                    catch
                    { }
                }
            }
        }

        /// <summary>
        /// The 'Copy Error' Event
        /// </summary>
        public event CopyErrorEventHandler CopyError;

        /// <summary>
        /// The 'On Copy Error' Event Handler: Called when an Attempted Copy of a file Fails.
        /// </summary>
        /// <param name="e">The 'Copy Error' Event Arguments.</param>
        protected virtual void OnCopyError(CopyErrorEventArgs e)
        {
            CopyErrorEventHandler Handler = CopyError;
            if (Handler != null)
            {
                foreach (CopyErrorEventHandler Caster in Handler.GetInvocationList())
                {
                    ISynchronizeInvoke syncInvoke = Caster.Target as ISynchronizeInvoke;
                    try
                    {
                        if (syncInvoke != null && syncInvoke.InvokeRequired)
                            syncInvoke.Invoke(Handler, new object[] { this, e });
                        else
                            Caster(this, e);
                    }
                    catch
                    { }
                }
            }
        }

        #endregion



        #region Public Properties

        /// <summary>
        /// The Source Directory.
        /// </summary>
        public DirectoryInfo Source
        {
            get { return _source; }
            set
            {
                if (_copierStatus != xDirectoryStatus.STOPPED)
                    throw new Exception("Attempt to Set Property 'Source' While AsyncCopier Status != Stopped");
                _source = value;
            }
        }

        /// <summary>
        /// The Destination Directory.
        /// </summary>
        public DirectoryInfo Destination
        {
            get { return _destination; }
            set
            {
                if (_copierStatus != xDirectoryStatus.STOPPED)
                    throw new Exception("Attempt to Set Property 'Destinatiton' While AsyncCopier Status != Stopped");
                _destination = value;
            }
        }

        /// <summary>
        /// The File Filters for "GetFiles".
        /// </summary>
        public List<string> FileFilters
        {
            get { return _fileFilters; }
            set
            {
                if (_copierStatus != xDirectoryStatus.STOPPED)
                    throw new Exception("Attempt to Set Property 'FileFilter' While AsyncCopier Status != Stopped");
                _fileFilters = value;
            }
        }

        /// <summary>
        /// The Folder Filter for "GetDirectories".
        /// </summary>
        public string FolderFilter
        {
            get { return _folderFilter; }
            set
            {
                if (_copierStatus != xDirectoryStatus.STOPPED)
                    throw new Exception("Attempt to Set Property 'FolderFilter' While AsyncCopier Status != Stopped");
                _folderFilter = value;
            }
        }

        /// <summary>
        /// The Overwrite Setting: Whether or not to overwrite on copy.
        /// </summary>
        public bool Overwrite
        {
            get { return _overwrite; }
            set
            {
                if (_copierStatus != xDirectoryStatus.STOPPED)
                    throw new Exception("Attempt to Set Property 'Overwrite' While AsyncCopier Status != Stopped");
                _overwrite = value;
            }
        }

        /// <summary>
        /// The Status of the xDirectory.StartCopy Method
        /// </summary>
        public xDirectoryStatus Status
        {
            get { return _copierStatus; }
        }

        #endregion



        #region Public Methods

        /// <summary>
        /// The 'Start Copy' Method: Async Call to Start the Copy Process.
        /// </summary>
        public void StartCopy()
        {
            try
            {
                if (_copierStatus != xDirectoryStatus.STOPPED)
                    throw new Exception("Attempt to call StartCopy Failed - Status is not 'Stopped'");

                _cancelCopy = false;

                // Error Checking
                ///////////////////////////////////////////////////////

                if (_source == null)
                    throw new ArgumentException("Source Directory: NULL");

                if (_destination == null)
                    throw new ArgumentException("Destination Directory: NULL");

                if (!_source.Exists)
                    throw new IOException("Source Directory: Does Not Exist");

                if (string.IsNullOrEmpty(_folderFilter))
                    _folderFilter = "*";

                if (List<string>.ReferenceEquals(_fileFilters, null))
                    _fileFilters = new List<string>();

                if (_fileFilters.Count == 0)
                    _fileFilters.Add("*");


                // This can be changed to suit the way the programmer wishes the thread to be created/used.
                ///////////////////////////////////////////////////////

                ThreadPool.QueueUserWorkItem(new WaitCallback(DoWork));
            }
            catch
            { throw; }
        }


        // DirectoryInfo Source/Directory Method Versions
        ///////////////////////////////////////////////////////

        /// <summary>
        /// The 'Start Copy' Method: Async Call to Start the Copy Process.
        /// </summary>
        /// <param name="Source">The Source Directory.</param>
        /// <param name="Destination">The Destination Directory.</param>
        public void StartCopy(DirectoryInfo Source, DirectoryInfo Destination)
        {
            try
            {
                _source = Source;
                _destination = Destination;

                StartCopy();
            }
            catch
            { throw; }
        }

        /// <summary>
        /// The 'Start Copy' Method: Async Call to Start the Copy Process.
        /// </summary>
        /// <param name="Source">The Source Directory.</param>
        /// <param name="Destination">The Destination Directory.</param>
        /// <param name="Overwrite">Whether or not to force Overwrite on Destination.</param>
        public void StartCopy(DirectoryInfo Source, DirectoryInfo Destination, bool Overwrite)
        {
            try
            {
                _source = Source;
                _destination = Destination;
                _overwrite = Overwrite;

                StartCopy();
            }
            catch
            { throw; }
        }

        /// <summary>
        /// The 'Start Copy' Method: Async Call to Start the Copy Process.
        /// </summary>
        /// <param name="Source">The Source Directory.</param>
        /// <param name="Destination">The Destination Directory.</param>
        /// <param name="FileFilters">The File Filters.</param>
        public void StartCopy(DirectoryInfo Source, DirectoryInfo Destination, List<string> FileFilters)
        {
            try
            {
                _source = Source;
                _destination = Destination;
                _fileFilters = FileFilters;

                StartCopy();
            }
            catch
            { throw; }
        }

        /// <summary>
        /// The 'Start Copy' Method: Async Call to Start the Copy Process.
        /// </summary>
        /// <param name="Source">The Source Directory.</param>
        /// <param name="Destination">The Destination Directory.</param>
        /// <param name="FileFilters">The File Filters.</param>
        /// <param name="Overwrite">Whether or not to force Overwrite on Destination.</param>
        public void StartCopy(DirectoryInfo Source, DirectoryInfo Destination, List<string> FileFilters, bool Overwrite)
        {
            try
            {
                _source = Source;
                _destination = Destination;
                _fileFilters = FileFilters;
                _overwrite = Overwrite;

                StartCopy();
            }
            catch
            { throw; }
        }

        /// <summary>
        /// The 'Start Copy' Method: Async Call to Start the Copy Process.
        /// </summary>
        /// <param name="Source">The Source Directory.</param>
        /// <param name="Destination">The Destination Directory.</param>
        /// <param name="FileFilters">The File Filters.</param>
        /// <param name="FolderFilter">The Folder Filter.</param>
        public void StartCopy(DirectoryInfo Source, DirectoryInfo Destination, List<string> FileFilters, string FolderFilter)
        {
            try
            {
                _source = Source;
                _destination = Destination;
                _fileFilters = FileFilters;
                _folderFilter = FolderFilter;

                StartCopy();
            }
            catch
            { throw; }
        }

        /// <summary>
        /// The 'Start Copy' Method: Async Call to Start the Copy Process.
        /// </summary>
        /// <param name="Source">The Source Directory.</param>
        /// <param name="Destination">The Destination Directory.</param>
        /// <param name="FileFilter">The File Filters.</param>
        /// <param name="FolderFilter">The Folder Filter.</param>
        /// <param name="Overwrite">Whether or not to force Overwrite on Destination.</param>
        public void StartCopy(DirectoryInfo Source, DirectoryInfo Destination, List<string> FileFilters, string FolderFilter, bool Overwrite)
        {
            try
            {
                _source = Source;
                _destination = Destination;
                _fileFilters = FileFilters;
                _folderFilter = FolderFilter;
                _overwrite = Overwrite;

                StartCopy();
            }
            catch
            { throw; }
        }


        // String Source/Directory Method Versions
        ///////////////////////////////////////////////////////

        /// <summary>
        /// The 'Start Copy' Method: Async Call to Start the Copy Process.
        /// </summary>
        /// <param name="Source">The Source Directory.</param>
        /// <param name="Destination">The Destination Directory.</param>
        public void StartCopy(string Source, string Destination)
        {
            try
            {
                _source = new DirectoryInfo(Source);
                _destination = new DirectoryInfo(Destination);

                StartCopy();
            }
            catch
            { throw; }
        }

        /// <summary>
        /// The 'Start Copy' Method: Async Call to Start the Copy Process.
        /// </summary>
        /// <param name="Source">The Source Directory.</param>
        /// <param name="Destination">The Destination Directory.</param>
        /// <param name="Overwrite">Whether or not to force Overwrite on Destination.</param>
        public void StartCopy(string Source, string Destination, bool Overwrite)
        {
            try
            {
                _source = new DirectoryInfo(Source);
                _destination = new DirectoryInfo(Destination);
                _overwrite = Overwrite;

                StartCopy();
            }
            catch
            { throw; }
        }

        /// <summary>
        /// The 'Start Copy' Method: Async Call to Start the Copy Process.
        /// </summary>
        /// <param name="Source">The Source Directory.</param>
        /// <param name="Destination">The Destination Directory.</param>
        /// <param name="FileFilter">The File Filter.</param>
        public void StartCopy(string Source, string Destination, List<string> FileFilters)
        {
            try
            {
                _source = new DirectoryInfo(Source);
                _destination = new DirectoryInfo(Destination);
                _fileFilters = FileFilters;

                StartCopy();
            }
            catch
            { throw; }
        }

        /// <summary>
        /// The 'Start Copy' Method: Async Call to Start the Copy Process.
        /// </summary>
        /// <param name="Source">The Source Directory.</param>
        /// <param name="Destination">The Destination Directory.</param>
        /// <param name="FileFilter">The File Filter.</param>
        /// <param name="Overwrite">Whether or not to force Overwrite on Destination.</param>
        public void StartCopy(string Source, string Destination, List<string> FileFilters, bool Overwrite)
        {
            try
            {
                _source = new DirectoryInfo(Source);
                _destination = new DirectoryInfo(Destination);
                _fileFilters = FileFilters;
                _overwrite = Overwrite;

                StartCopy();
            }
            catch
            { throw; }
        }

        /// <summary>
        /// The 'Start Copy' Method: Async Call to Start the Copy Process.
        /// </summary>
        /// <param name="Source">The Source Directory.</param>
        /// <param name="Destination">The Destination Directory.</param>
        /// <param name="FileFilter">The File Filter.</param>
        /// <param name="FolderFilter">The Folder Filter.</param>
        public void StartCopy(string Source, string Destination, List<string> FileFilters, string FolderFilter)
        {
            try
            {
                _source = new DirectoryInfo(Source);
                _destination = new DirectoryInfo(Destination);
                _fileFilters = FileFilters;
                _folderFilter = FolderFilter;

                StartCopy();
            }
            catch
            { throw; }
        }

        /// <summary>
        /// The 'Start Copy' Method: Async Call to Start the Copy Process.
        /// </summary>
        /// <param name="Source">The Source Directory.</param>
        /// <param name="Destination">The Destination Directory.</param>
        /// <param name="FileFilter">The File Filter.</param>
        /// <param name="FolderFilter">The Folder Filter.</param>
        /// <param name="Overwrite">Whether or not to force Overwrite on Destination.</param>
        public void StartCopy(string Source, string Destination, List<string> FileFilters, string FolderFilter, bool Overwrite)
        {
            try
            {
                _source = new DirectoryInfo(Source);
                _destination = new DirectoryInfo(Destination);
                _fileFilters = FileFilters;
                _folderFilter = FolderFilter;
                _overwrite = Overwrite;

                StartCopy();
            }
            catch
            { throw; }
        }

        /// <summary>
        /// The 'Cancel Copy' Method: To Cancel the Working Thread of the xDirectory.StartCopy Method.
        /// </summary>
        public void CancelCopy()
        {
            _cancelCopy = true;
        }

        #endregion



        #region Private Methods

        /// <summary>
        /// The Main Work Method of the xDirectory Class: Handled in a Separate Thread.
        /// </summary>
        /// <param name="StateInfo">Undefined</param>
        private void DoWork(object StateInfo)
        {
            _copierStatus = xDirectoryStatus.STARTED;

            int iterator = 0;
            List<DirectoryInfo> FolderSourceList = new List<DirectoryInfo>();
            List<FileInfo> FileSourceList = new List<FileInfo>();
            DirectoryInfo FolderPath;
            FileInfo FilePath;

            try
            {
                // Part 1: Indexing
                ///////////////////////////////////////////////////////

                _copierStatus = xDirectoryStatus.INDEXING;

                FolderSourceList.Add(_source);

                while (iterator < FolderSourceList.Count)
                {
                    if (_cancelCopy) return;

                    foreach (DirectoryInfo di in FolderSourceList[iterator].GetDirectories(_folderFilter))
                    {
                        if (_cancelCopy) return;

                        FolderSourceList.Add(di);

                        OnItemIndexed(new ItemIndexedEventArgs(
                            di.FullName,
                            0,
                            FolderSourceList.Count,
                            true));
                    }

                    foreach (string FileFilter in _fileFilters)
                    {
                        foreach (FileInfo fi in FolderSourceList[iterator].GetFiles(FileFilter))
                        {
                            if (_cancelCopy) return;

                            FileSourceList.Add(fi);

                            OnItemIndexed(new ItemIndexedEventArgs(
                                fi.FullName,
                                fi.Length,
                                FileSourceList.Count,
                                false));
                        }
                    }

                    iterator++;
                }

                OnIndexComplete(new IndexCompleteEventArgs(
                    FolderSourceList.Count,
                    FileSourceList.Count));



                // Part 2: Destination Folder Creation
                ///////////////////////////////////////////////////////

                _copierStatus = xDirectoryStatus.COPYINGDIRECTORIES;

                for (iterator = 0; iterator < FolderSourceList.Count; iterator++)
                {
                    if (_cancelCopy) return;


                    if (FolderSourceList[iterator].Exists)
                    {
                        FolderPath = new DirectoryInfo(
                            _destination.FullName +
                            Path.DirectorySeparatorChar +
                            FolderSourceList[iterator].FullName.Remove(0, _source.FullName.Length));

                        try
                        {

                            if (!FolderPath.Exists) FolderPath.Create(); // Prevent IOException

                            OnItemCopied(new ItemCopiedEventArgs(
                                    FolderSourceList[iterator].FullName,
                                    FolderPath.FullName,
                                    0,
                                    iterator,
                                    FolderSourceList.Count,
                                    true));
                        }
                        catch (Exception iError)
                        {
                            OnCopyError(new CopyErrorEventArgs(
                                    FolderSourceList[iterator].FullName,
                                    FolderPath.FullName,
                                    iError));
                        }
                    }

                }



                // Part 3: Source to Destination File Copy
                ///////////////////////////////////////////////////////

                _copierStatus = xDirectoryStatus.COPYINGFILES;

                for (iterator = 0; iterator < FileSourceList.Count; iterator++)
                {
                    if (_cancelCopy) return;

                    if (FileSourceList[iterator].Exists)
                    {
                        FilePath = new FileInfo(_destination.FullName + Path.DirectorySeparatorChar + FileSourceList[iterator].FullName.Remove(0, _source.FullName.Length + 1));

                        try
                        {
                            if (_overwrite)
                                FileSourceList[iterator].CopyTo(FilePath.FullName, true);
                            else
                            {
                                if (!FilePath.Exists)
                                    FileSourceList[iterator].CopyTo(FilePath.FullName, true);
                            }

                            OnItemCopied(new ItemCopiedEventArgs(
                                    FileSourceList[iterator].FullName,
                                    FilePath.FullName,
                                    FileSourceList[iterator].Length,
                                    iterator,
                                    FileSourceList.Count,
                                    false));

                        }
                        catch (Exception iError)
                        {
                            OnCopyError(new CopyErrorEventArgs(
                                    FileSourceList[iterator].FullName,
                                    FilePath.FullName,
                                    iError));
                        }
                    }

                }

            }
            catch
            { throw; }
            finally
            {
                _copierStatus = xDirectoryStatus.STOPPED;
                OnCopyComplete(new CopyCompleteEventArgs(_cancelCopy));
            }
        }

        #endregion
    }


}