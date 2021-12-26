namespace Krypton.Toolkit.Suite.Extended.IO
{
    /// <summary>
    /// Represents the method that is used to handle file selected event.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="fse"></param>
    public delegate void FileSelectedEventHandler(object sender, FileSelectEventArgs fse);


    /// <summary>
    /// Provides for FileSelect event.
    /// </summary>
    public class FileSelectEventArgs : EventArgs
    {
        private string _fileName;

        /// <summary>
        /// Gets or sets the file name that trigered the event.
        /// </summary>
        public string FileName
        {
            get { return _fileName; }
            set { _fileName = FileName; }
        }
        /// <summary>
        /// Initializes a new instance of the FileSelectEventArgs in order to provide
        /// data for FileSelected event.
        /// </summary>
        /// <param name="fileName"></param>
        public FileSelectEventArgs(string fileName)
        {
            _fileName = fileName;
        }

    }
}