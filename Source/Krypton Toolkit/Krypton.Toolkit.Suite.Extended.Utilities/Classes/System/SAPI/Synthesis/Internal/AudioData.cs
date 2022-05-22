#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license or other governing licenses that can be found in the LICENSE.md file or at
 * https://raw.githubusercontent.com/Krypton-Suite/Extended-Toolkit/master/LICENSE
 */
#endregion

using Krypton.Toolkit.Suite.Extended.Utilities.System.Internal;

namespace Krypton.Toolkit.Suite.Extended.Utilities.System.Synthesis
{
    internal class AudioData : IDisposable
    {
        internal Uri _uri;

        internal string _mimeType;

        internal Stream _stream;

        private string _localFile;

        private ResourceLoader _resourceLoader;

        internal AudioData(Uri uri, ResourceLoader resourceLoader)
        {
            _uri = uri;
            _resourceLoader = resourceLoader;
            Uri baseUri;
            _stream = _resourceLoader.LoadFile(uri, out _mimeType, out baseUri, out _localFile);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        ~AudioData()
        {
            Dispose(false);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (_localFile != null)
                {
                    _resourceLoader.UnloadFile(_localFile);
                }
                if (_stream != null)
                {
                    _stream.Dispose();
                    _stream = null;
                    _localFile = null;
                    _uri = null;
                }
            }
        }
    }
}