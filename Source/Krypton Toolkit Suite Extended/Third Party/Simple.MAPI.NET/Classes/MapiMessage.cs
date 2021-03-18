using System;
using System.Runtime.InteropServices;

namespace Simple.MAPI.NET
{
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public class MapiMessage
    {
        public int reserved;
        public string subject;
        public string noteText;
        public string messageType;
        public string dateReceived;
        public string conversationID;
        public int flags;
        public IntPtr originator; // MapiRecipDesc* [1]
        public int recipCount;
        public IntPtr recips; // MapiRecipDesc* [n]
        public int fileCount;
        public IntPtr files; // MapiFileDesc*  [n]
    }
}