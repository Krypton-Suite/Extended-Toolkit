#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license or other governing licenses that can be found in the LICENSE.md file or at
 * https://raw.githubusercontent.com/Krypton-Suite/Extended-Toolkit/master/LICENSE
 */
#endregion

namespace Krypton.Toolkit.Suite.Extended.Utilities.System.Synthesis
{
    /// <filterpriority>2</filterpriority>
    public class BookmarkReachedEventArgs : PromptEventArgs
    {
        private string _bookmark;

        private TimeSpan _audioPosition;

        public string Bookmark => _bookmark;

        public TimeSpan AudioPosition => _audioPosition;

        internal BookmarkReachedEventArgs(Prompt prompt, string bookmark, TimeSpan audioPosition)
            : base(prompt)
        {
            _bookmark = bookmark;
            _audioPosition = audioPosition;
        }
    }
}
