#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license or other governing licenses that can be found in the LICENSE.md file or at
 * https://raw.githubusercontent.com/Krypton-Suite/Extended-Toolkit/master/LICENSE
 */
#endregion

namespace Krypton.Toolkit.Suite.Extended.Utilities.System.Synthesis
{
    internal class LexiconEntry
    {
        internal Uri _uri;

        internal string _mediaType;

        internal LexiconEntry(Uri uri, string mediaType)
        {
            _uri = uri;
            _mediaType = mediaType;
        }

        public override bool Equals(object obj)
        {
            LexiconEntry lexiconEntry = obj as LexiconEntry;
            if (lexiconEntry != null)
            {
                return _uri.Equals(lexiconEntry._uri);
            }
            return false;
        }

        public override int GetHashCode()
        {
            return _uri.GetHashCode();
        }
    }
}