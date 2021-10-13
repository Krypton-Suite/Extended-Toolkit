namespace Krypton.Toolkit.Suite.Extended.File.Copier
{
    public interface ICopyFileDetails
    {
        ISynchronizeInvoke SynchronizationObject { get; set; }

        //This event should fire when you want to cancel the copy
        event CopyFiles.DEL_cancelCopy EN_cancelCopy;

        //This is how the CopyClass will send your dialog information about
        //the transfer
        void Update(int totalFiles, int copiedFiles, long totalBytes, long copiedBytes, string currentFilename);
        void Show();
        void Hide();
    }
}