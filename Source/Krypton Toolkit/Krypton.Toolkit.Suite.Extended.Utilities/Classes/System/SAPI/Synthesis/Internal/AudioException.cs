#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license or other governing licenses that can be found in the LICENSE.md file or at
 * https://raw.githubusercontent.com/Krypton-Suite/Extended-Toolkit/master/LICENSE
 */
#endregion

using Krypton.Toolkit.Suite.Extended.Utilities.SystemInternal.Speech;

namespace Krypton.Toolkit.Suite.Extended.Utilities.System.Synthesis
{
    [Serializable]
    internal class AudioException : Exception
    {
        internal AudioException()
        {
        }

        internal AudioException(MMSYSERR errorCode)
            : base(string.Format(CultureInfo.InvariantCulture, "{0} - Error Code: 0x{1:x}", new object[2]
            {
                SR.Get(SRID.AudioDeviceError),
                (int)errorCode
            }))
        {
        }

        protected AudioException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
}