#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license or other governing licenses that can be found in the LICENSE.md file or at
 * https://raw.githubusercontent.com/Krypton-Suite/Extended-Toolkit/master/LICENSE
 */
#endregion

using System;
using System;

namespace Krypton.Toolkit.Suite.Extended.Utilities
{
    public interface ITtsEngineSite
    {
        int EventInterest
        {
            get;
        }

        int Actions
        {
            get;
        }

        int Rate
        {
            get;
        }

        int Volume
        {
            get;
        }

        void AddEvents(SpeechEventInfo[] events, int count);

        int Write(IntPtr data, int count);

        SkipInfo GetSkipInfo();

        void CompleteSkip(int skipped);

        Stream LoadResource(Uri uri, string mediaType);
    }
}
