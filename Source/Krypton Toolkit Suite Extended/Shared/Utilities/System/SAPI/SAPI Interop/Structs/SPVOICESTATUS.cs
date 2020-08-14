namespace Krypton.Toolkit.Suite.Extended.Utilities.System.SAPIInterop
{
    internal struct SPVOICESTATUS
    {
        internal uint ulCurrentStream;

        internal uint ulLastStreamQueued;

        internal int hrLastResult;

        internal SpeechRunState dwRunningState;

        internal uint ulInputWordPos;

        internal uint ulInputWordLen;

        internal uint ulInputSentPos;

        internal uint ulInputSentLen;

        internal int lBookmarkId;

        internal ushort PhonemeId;

        internal int VisemeId;

        internal uint dwReserved1;

        internal uint dwReserved2;
    }
}