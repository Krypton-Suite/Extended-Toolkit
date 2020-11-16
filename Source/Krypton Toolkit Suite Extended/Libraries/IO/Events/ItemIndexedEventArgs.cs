#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license or other governing licenses that can be found in the LICENSE.md file or at
 * https://raw.githubusercontent.com/Krypton-Suite/Extended-Toolkit/master/LICENSE
 */
#endregion

using System;

namespace Krypton.Toolkit.Suite.Extended.IO
{
    #region Event Handler Delegates

    /// <summary>
    /// The 'Item Indexed' Event Handler Delegate
    /// </summary>
    /// <param name="sender">The Object that sent the Event</param>
    /// <param name="e">The 'Item Indexed' Event Argument</param>
    public delegate void ItemIndexedEventHandler(object sender, ItemIndexedEventArgs e);

    /// <summary>
    /// The 'Index Complete' Event Handler Delegate
    /// </summary>
    /// <param name="sender">The Object that sent the Event</param>
    /// <param name="e">The 'Index Complete' Event Argument</param>
    public delegate void IndexCompleteEventHandler(object sender, IndexCompleteEventArgs e);

    /// <summary>
    /// The 'Item Copied' Event Handler Delegate
    /// </summary>
    /// <param name="sender">The Object that sent the Event</param>
    /// <param name="e">The 'Item Copied' Event Argument</param>
    public delegate void ItemCopiedEventHandler(object sender, ItemCopiedEventArgs e);

    /// <summary>
    /// The 'Copy Complete' Event Handler Delegate
    /// </summary>
    /// <param name="sender">The Object that sent the Event</param>
    /// <param name="e">The 'Copy Complete' Event Argument</param>
    public delegate void CopyCompleteEventHandler(object sender, CopyCompleteEventArgs e);

    /// <summary>
    /// The 'Copy Error' Event Handler Delegate
    /// </summary>
    /// <param name="sender">The Object that sent the Event</param>
    /// <param name="e">The 'Copy Error' Event Argument</param>
    public delegate void CopyErrorEventHandler(object sender, CopyErrorEventArgs e);

    #endregion



    #region Event Arguments

    /// <summary>
    /// The 'Item Indexed' Event Argument
    /// </summary>
    public class ItemIndexedEventArgs : EventArgs
    {
        private string _Source;
        private long _Size;
        private int _CurrentCount;
        private bool _IsFolder;

        public ItemIndexedEventArgs(string Source, long Size, int CurrentCount, bool IsFolder)
        {
            _Source = Source;
            _Size = Size;
            _CurrentCount = CurrentCount;
            _IsFolder = IsFolder;
        }

        public string Source { get { return _Source; } }
        public long Size { get { return _Size; } }
        public int CurrentCount { get { return _CurrentCount; } }
        public bool IsFolder { get { return _IsFolder; } }
    }

    /// <summary>
    /// The 'Index Complete' Event Argument
    /// </summary>
    public class IndexCompleteEventArgs : EventArgs
    {
        private int _FolderCount;
        private int _FileCount;

        public IndexCompleteEventArgs(int FolderCount, int FileCount)
        {
            _FolderCount = FolderCount;
            _FileCount = FileCount;
        }

        public int FolderCount { get { return _FolderCount; } }
        public int FileCount { get { return _FileCount; } }
    }

    /// <summary>
    /// The 'Item Copied' Event Argument
    /// </summary>
    public class ItemCopiedEventArgs : EventArgs
    {
        private string _Source;
        private string _Destination;
        private long _Size;
        private int _Index;
        private int _TotalCount;
        private bool _IsFolder;

        public ItemCopiedEventArgs(string Source, string Destination, long Size, int Index, int TotalCount, bool IsFolder)
        {
            _Source = Source;
            _Destination = Destination;
            _Index = Index;
            _Size = Size;
            _TotalCount = TotalCount;
            _IsFolder = IsFolder;
        }

        public string Source { get { return _Source; } }
        public string Destination { get { return _Destination; } }
        public long Size { get { return _Size; } }
        public int Index { get { return _Index; } }
        public int TotalCount { get { return _TotalCount; } }
        public bool IsFolder { get { return _IsFolder; } }
    }

    /// <summary>
    /// The 'Copy Complete' Event Argument
    /// </summary>
    public class CopyCompleteEventArgs : EventArgs
    {
        private bool _Cancelled;

        public CopyCompleteEventArgs(bool Cancelled)
        {
            _Cancelled = Cancelled;
        }

        public bool Cancelled => _Cancelled;
    }

    /// <summary>
    /// The 'Copy Error' Event Argument
    /// </summary>
    public class CopyErrorEventArgs : EventArgs
    {
        private string _Source;
        private string _Destination;
        private Exception _Exception;

        public CopyErrorEventArgs(string Source, string Destination, Exception Exception)
        {
            _Source = Source;
            _Destination = Destination;
            _Exception = Exception;
        }

        public string Source => _Source;
        public string Destination => _Destination;
        public Exception Exception => _Exception;
    }

    #endregion
}