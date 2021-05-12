using System;
using System.Runtime.InteropServices;

namespace Simple.MAPI.NET
{
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public class MapiMessageW
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

        public MapiMessageW() { }

        protected internal MapiMessageW(MapiMessage message)
        {
            reserved = message.reserved;
            subject = message.subject;
            noteText = message.noteText;
            messageType = message.messageType;
            dateReceived = message.dateReceived;
            conversationID = message.conversationID;
            flags = message.flags;
            originator = message.originator;
            recipCount = message.recipCount;
            recips = message.recips;
            fileCount = message.fileCount;
            files = message.files;
        }
    }
}