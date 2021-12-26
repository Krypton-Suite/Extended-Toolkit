#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license or other governing licenses that can be found in the LICENSE.md file or at
 * https://raw.githubusercontent.com/Krypton-Suite/Extended-Toolkit/master/LICENSE
 */
#endregion

namespace Krypton.Toolkit.Suite.Extended.File.Copier
{
    // http://www.pinvoke.net/default.aspx/kernel32.CopyFileEx
    /// <summary>
    /// Copies a list of files or a directory tree to a destination
    /// 
    /// Support for GUI is implamented by the ICopyFilesDiag interface
    /// and passed to the class in the copy() method.
    /// </summary>
    public class CopyFiles
    {
        #region Variables
        private List<string> _files = new List<string>(), _newFileNames = new List<string>();

        private List<ST_CopyFileDetails> _filesCopied = new List<ST_CopyFileDetails>();

        private int _totalFiles = 0, _totalFilesCopied = 0;

        private string _destinationDir = "", _sourceDir = "", _currentFilename;

        private bool _cancel = false;

        private IAsyncResult CopyResult;

        private DEL_CopyFiles _delCopy;

        private ICopyFileDetails _digWindow;
        #endregion

        #region Structs
        public struct ST_CopyFileDetails
        {

            string OriginalURI;
            string NewURI;

            // Constructor
            public ST_CopyFileDetails(string FromURI, string ToURI)
            {
                OriginalURI = FromURI;
                NewURI = ToURI;
            }

        }
        #endregion

        #region Enumerations
        [Flags]
        private enum CopyFileFlags : uint
        {
            COPY_FILE_FAIL_IF_EXISTS = 0x00000001,
            COPY_FILE_RESTARTABLE = 0x00000002,
            COPY_FILE_OPEN_SOURCE_FOR_WRITE = 0x00000004,
            COPY_FILE_ALLOW_DECRYPTED_DESTINATION = 0x00000008
        }

        private enum CopyProgressResult : uint
        {
            PROGRESS_CONTINUE = 0,
            PROGRESS_CANCEL = 1,
            PROGRESS_STOP = 2,
            PROGRESS_QUIET = 3
        }

        private enum CopyProgressCallbackReason : uint
        {
            CALLBACK_CHUNK_FINISHED = 0x00000000,
            CALLBACK_STREAM_SWITCH = 0x00000001
        }
        #endregion

        #region Custom Events
        public event DEL_copyComplete EV_copyComplete;

        public event DEL_copyCanceled EV_copyCanceled;
        #endregion

        #region Delegates
        private delegate CopyProgressResult CopyProgressRoutine(long TotalFileSize, long TotalBytesTransferred, long StreamSize, long StreamBytesTransferred, uint dwStreamNumber, CopyProgressCallbackReason dwCallbackReason, IntPtr hSourceFile, IntPtr hDestinationFile, IntPtr lpData);

        private delegate CopyProgressResult DEL_CopyProgressHandler(long total, long transferred, long streamSize, long StreamByteTrans, uint dwStreamNumber, CopyProgressCallbackReason reason, IntPtr hSourceFile, IntPtr hDestinationFile, IntPtr lpData);

        private delegate void DEL_CopyFiles();

        private delegate void DEL_ShowDiag(ICopyFileDetails diag);

        private delegate void DEL_HideDiag(ICopyFileDetails diag);

        private delegate void DEL_CopyfilesCallback(IAsyncResult r);

        public delegate void DEL_cancelCopy();

        public delegate void DEL_copyComplete();

        public delegate void DEL_copyCanceled(List<ST_CopyFileDetails> filescopied);
        #endregion

        #region Constructors
        /// <summary>Initializes a new instance of the <see cref="CopyFiles" /> class.</summary>
        /// <param name="source">The source.</param>
        /// <param name="destination">The destination.</param>
        public CopyFiles(string source, string destination)
        {
            _sourceDir = source;

            _destinationDir = destination;
        }

        /// <summary>Initializes a new instance of the <see cref="CopyFiles" /> class.</summary>
        /// <param name="sourceFiles">The source files.</param>
        /// <param name="destination">The destination.</param>
        public CopyFiles(List<string> sourceFiles, string destination)
        {
            //The _sourceDir does not need to be set if the user is supplying a 
            //list of files.
            //
            //Example :
            //      Source                      Destination
            //      c:\Temp1\Test.txt           c:\DestFolder\Test.txt
            //      c:\temp2\temp1\test1.txt    c:\DestFolder\Test1.txt
            //      c:\temp3\blah\Test.txt      c:\DestFolder\Test (2).txt
            //
            //This is worked out in CheckFilenames()
            _files = sourceFiles;

            _totalFiles = _files.Count;

            _destinationDir = destination;
        }
        #endregion

        #region Kernel32 Calls
        [DllImport("kernel32.dll", SetLastError = true, CharSet = CharSet.Auto)]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern unsafe bool CopyFileEx(string lpExistingFileName, string lpNewFileName, CopyProgressRoutine lpProgressRoutine, IntPtr lpData, bool* pbCancel, CopyFileFlags dwCopyFlags);
        #endregion

        #region Methods
        private List<string> GetFiles(string _sourceDir)
        {

            // Variables
            List<string> foundFiles = new List<string>();
            string[] fileEntries;
            string[] subdirEntries;

            //Add root files in this DIR to the list
            fileEntries = Directory.GetFiles(_sourceDir);
            foreach (string filename in fileEntries)
            {
                foundFiles.Add(filename);
            }

            //Loop the DIR's in the current DIR
            subdirEntries = Directory.GetDirectories(_sourceDir);
            foreach (string subdir in subdirEntries)
            {

                //Dont open Folder Redirects as this can end up in an infinate loop
                if ((System.IO.File.GetAttributes(subdir) &
                     FileAttributes.ReparsePoint) !=
                     FileAttributes.ReparsePoint)
                {
                    //Run recursivly to follow this DIR tree 
                    //adding all the files along the way
                    foundFiles.AddRange(GetFiles(subdir));
                }

            }

            return foundFiles;
        }

        private CopyProgressResult CopyProgressHandler(long total, long transferred, long streamSize, long StreamByteTrans, uint dwStreamNumber, CopyProgressCallbackReason reason, IntPtr hSourceFile, IntPtr hDestinationFile, IntPtr lpData)
        {
            //Check to see if there is a dialog window to use
            if (_digWindow != null)
            {
                //Are we going to send the update on the correct thread?
                if (_digWindow.SynchronizationObject != null && _digWindow.SynchronizationObject.InvokeRequired)
                {
                    _digWindow.SynchronizationObject.Invoke(new CopyProgressRoutine(CopyProgressHandler),
                                new Object[] { total, transferred, streamSize, StreamByteTrans, dwStreamNumber, reason, hSourceFile, hDestinationFile, lpData });
                }
                else
                {
                    _digWindow.Update(_totalFiles, _totalFilesCopied, total, transferred, _currentFilename);
                }

            }
            return CopyProgressResult.PROGRESS_CONTINUE;
        }

        private void ShowDiag(ICopyFileDetails diag)
        {
            //Check to see if there is a dialog window to use
            if (_digWindow != null)
            {
                //Are we going to send the update on the correct thread?
                if (_digWindow.SynchronizationObject != null && _digWindow.SynchronizationObject.InvokeRequired)
                {
                    _digWindow.SynchronizationObject.Invoke(new DEL_ShowDiag(ShowDiag),
                        new Object[] { diag });
                }
                else
                {
                    diag.Show();
                }
            }
        }

        private void HideDiag(ICopyFileDetails diag)
        {
            //Check to see if there is a dialog window to use
            if (_digWindow != null)
            {
                //Are we going to send the update on the correct thread?
                if (_digWindow.SynchronizationObject != null && _digWindow.SynchronizationObject.InvokeRequired)
                {
                    _digWindow.SynchronizationObject.Invoke(new DEL_HideDiag(HideDiag),
                        new Object[] { diag });
                }
                else
                {
                    diag.Hide();
                    _cancel = false;
                }
            }
        }

        private void CancelCopy()
        {
            _cancel = true;
            OnCopyCanceled();
        }

        private void Copyfiles()
        {

            int index = 0;

            //Show the dialog box and hook into its cancel event if
            //a dialog box has been given
            if (_digWindow != null)
            {
                _digWindow.EN_cancelCopy += CancelCopy;
                ShowDiag(_digWindow);
            }

            //If we have been a _sourceDir then find all the files to copy
            if (_sourceDir != "")
            {
                _files = GetFiles(_sourceDir);
            }
            else
            {
                CheckFilenames();
            }

            _totalFiles = _files.Count;

            //Loop each file and copy it.
            foreach (string filename in _files.ToArray())
            {
                string[] filepath;
                string tempFilepath;
                string tempDirPath = "";

                //If we have a source directory, strip that off the filename
                if (_sourceDir != "")
                {
                    tempFilepath = filename;
                    tempFilepath = tempFilepath.Replace(_sourceDir, "");
                    tempFilepath = Path.Combine(_destinationDir, tempFilepath);
                }
                //otherwise strip off all the folder path
                else
                {
                    tempFilepath = Path.Combine(_destinationDir, _newFileNames[index]);
                }

                //Save the new DIR path and check the DIR exsits,
                //if it does not then create it so the files can copy
                filepath = tempFilepath.Split('\\');
                for (int i = 0; i < filepath.Length - 1; i++)
                {
                    tempDirPath += filepath[i] + "\\";
                }
                if (!Directory.Exists(tempDirPath))
                {
                    Directory.CreateDirectory(tempDirPath);
                }

                //Have be been told to stop copying files
                if (_cancel)
                {
                    break;
                }

                //Set the file thats just about to get copied
                _currentFilename = filename;

                //Unsafe is need to show that we are using 
                //pointers which are classed as "unsafe" in .net
                //
                //CopyFileEx needs a pointer to the cancel boolean, it checks this
                //constantly as the file copies, if it gets set to true it will stop
                //
                //Note :
                //  fixed is used to get the memory pointer of our local boolean.
                //  It is then saved in a pointer (declared like a normal type but
                //  with a * at the end)
                //  
                //  We can then pass this memory address to the Kernal32 call.
                unsafe
                {
                    fixed (bool* cancelp = &_cancel)
                    {
                        CopyFileEx(filename, tempFilepath, new CopyProgressRoutine(CopyProgressHandler), IntPtr.Zero, cancelp, 0);
                    }
                }
                _filesCopied.Add(new ST_CopyFileDetails(filename, tempFilepath));
                _totalFilesCopied += 1;
                index += 1;

            }

        }

        private void OnCopyComplete()
        {
            if (EV_copyComplete != null)
            {
                EV_copyComplete();
            }
        }

        private void OnCopyCanceled()
        {
            if (EV_copyCanceled != null)
            {
                EV_copyCanceled(_filesCopied);
            }
        }

        private void CheckFilenames()
        {
            // Variables
            string[] fileNames = new string[_files.Count];
            List<string> tempFileNameArr;
            int index = 0;
            int innerIndex = 0;
            int filenameIndex = 0;
            int filenameNumber = 0;

            //Load filenames into an array
            foreach (string tempFileName in _files)
            {
                fileNames[index] = Path.GetFileName(tempFileName);
                index += 1;
            }

            //Loop each filename in the array
            index = 0;
            foreach (string originalFilename in fileNames)
            {

                //See if this filename is repeated in the list
                innerIndex = 0;
                filenameNumber = 2;
                foreach (string dupeFilename in fileNames)
                {
                    //dont compair the same index!
                    if (innerIndex != index)
                    {

                        if (originalFilename == dupeFilename)
                        {
                            //insert the duplicate number into the new filename e.g (2) and clear
                            //the current name.
                            tempFileNameArr = new List<string>(fileNames[innerIndex].Split('.'));
                            tempFileNameArr.Insert(tempFileNameArr.Count - 1, "[*REMOVEME*] (" + filenameNumber + ")");
                            fileNames[innerIndex] = "";

                            //Rebuild the new filename
                            filenameIndex = 0;
                            foreach (string newFilename in tempFileNameArr)
                            {

                                //put a dot before the file extension
                                if (filenameIndex == tempFileNameArr.Count - 1)
                                { fileNames[innerIndex] += "."; }

                                //append the new filename
                                fileNames[innerIndex] += newFilename.Replace("[*REMOVEME*]", "");

                                //only add a . if its not the injected portion e.g (2)
                                if ((filenameIndex < tempFileNameArr.Count - 3 && newFilename.StartsWith("[*REMOVEME*]") == false))
                                { fileNames[innerIndex] += "."; }

                                filenameIndex += 1;
                            }

                            //Trim any trailing .'s
                            fileNames[innerIndex].TrimEnd(new char[] { '.' });
                            filenameNumber += 1;
                        }
                    }
                    innerIndex += 1;
                }
                index += 1;

            }

            //Update the list of new filenames.
            _newFileNames = new List<string>(fileNames);

        }

        //Copy the files
        public void Copy()
        {
            Copyfiles();
        }

        public void CopyAsync(ICopyFileDetails diag)
        {
            _digWindow = diag;

            if (_digWindow != null && _digWindow.SynchronizationObject == null)
            {
                throw new Exception("Dialog window sent with no SynchronizationObject");
            }

            _delCopy = new DEL_CopyFiles(Copyfiles);
            CopyResult = _delCopy.BeginInvoke(CopyfilesCallback, null);
        }

        // Async Callbacks
        private void CopyfilesCallback(IAsyncResult r)
        {
            //Kill off the thread as its finished.
            _delCopy.EndInvoke(CopyResult);
            HideDiag(_digWindow);
            OnCopyComplete();
        }
        #endregion
    }
}