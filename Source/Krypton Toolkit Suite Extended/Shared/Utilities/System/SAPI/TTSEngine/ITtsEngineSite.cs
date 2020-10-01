using System;
using System.IO;

namespace Krypton.Toolkit.Suite.Extended.Utilities.System.TTSEngine
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
