﻿namespace Krypton.Toolkit.Suite.Extended.Software.Updater
{
    /// <summary>
    ///     An object of this class contains the AppCast file received from server.
    /// </summary>
    public class ParseUpdateInfoEventArgs : EventArgs
    {
        /// <summary>
        ///     An object containing the AppCast file received from server.
        /// </summary>
        /// <param name="remoteData">A string containing remote data received from the AppCast file.</param>
        public ParseUpdateInfoEventArgs(string remoteData)
        {
            RemoteData = remoteData;
        }

        /// <summary>
        ///     Remote data received from the AppCast file.
        /// </summary>
        public string RemoteData { get; }

        /// <summary>
        ///     Set this object with values received from the AppCast file.
        /// </summary>
        public UpdateInfoEventArgs UpdateInfo { get; set; }
    }
}