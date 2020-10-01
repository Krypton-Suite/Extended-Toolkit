using System;

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