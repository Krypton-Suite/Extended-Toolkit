using System;

namespace Simple.MAPI.NET
{
    public class MailEnvelop
    {
        public string id;
        public DateTime date;
        public string from;
        public string subject;
        public bool unread;
        public int atts;
    }
}