﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace Krypton.Toolkit.Suite.Extended.Networking
{
    internal abstract class DirectoryProviderBase : IDirectoryProvider
    {
        protected FTPClient ftpClient;
        protected FTPClientConfiguration configuration;
        protected ILogger logger;
        protected Stream stream;

        protected IEnumerable<string> RetrieveDirectoryListing()
        {
            string line;
            while ((line = ReadLine(ftpClient.ControlStream.Encoding)) != null)
            {
                logger?.LogDebug(line);
                yield return line;
            }
        }

        protected string ReadLine(Encoding encoding)
        {
            if (encoding == null)
                throw new ArgumentNullException(nameof(encoding));

            var data = new List<byte>();
            var buf = new byte[1];
            string line = null;

            while (stream.Read(buf, 0, buf.Length) > 0)
            {
                data.Add(buf[0]);
                if ((char)buf[0] != '\n')
                    continue;
                line = encoding.GetString(data.ToArray()).Trim('\r', '\n');
                break;
            }

            return line;
        }

        public virtual Task<ReadOnlyCollection<FTPNodeInformation>> ListAllAsync()
        {
            throw new NotImplementedException();
        }

        public virtual Task<ReadOnlyCollection<FTPNodeInformation>> ListFilesAsync()
        {
            throw new NotImplementedException();
        }

        public virtual Task<ReadOnlyCollection<FTPNodeInformation>> ListDirectoriesAsync()
        {
            throw new NotImplementedException();
        }
    }
}