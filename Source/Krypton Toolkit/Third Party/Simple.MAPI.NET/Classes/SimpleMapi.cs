using System;
using System.Collections;
using System.Globalization;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;

namespace Simple.MAPI.NET
{
    public class SimpleMapi
    {
        private const int MAPI_DIALOG = 8;
        private static readonly bool UseUnicode = Environment.OSVersion.Version >= new Version(6, 2);

        #region SESSION

        // SESSION

        public bool Logon(IntPtr hwnd)
        {
            winhandle = hwnd;
            error = MAPILogon(hwnd, null, null, 0, 0, ref session);
            if (error != 0)
            {
                error = MAPILogon(hwnd, null, null, MapiLogonUI, 0, ref session);
            }
            return error == 0;
        }

        public void Reset()
        {
            findseed = null;
            origin = new MapiRecipDesc();
            recpts.Clear();
            attachs.Clear();
            lastMsg = null;
        }

        public void Logoff()
        {
            if (session == IntPtr.Zero) return;
            error = MAPILogoff(session, winhandle, 0, 0);
            session = IntPtr.Zero;
        }

        [DllImport("MAPI32.DLL", CharSet = CharSet.Ansi)]
        private static extern int MAPILogon(IntPtr hwnd, string prf, string pw, int flg, int rsv, ref IntPtr sess);

        [DllImport("MAPI32.DLL")]
        private static extern int MAPILogoff(IntPtr sess, IntPtr hwnd, int flg, int rsv);

        private const int MapiLogonUI = 0x00000001;
        private const int MapiPasswordUI = 0x00020000;
        private const int MapiNewSession = 0x00000002;
        private const int MapiForceDownload = 0x00001000;
        private const int MapiExtendedUI = 0x00000020;

        private IntPtr session = IntPtr.Zero;
        private IntPtr winhandle = IntPtr.Zero;

        #endregion

        #region SENDING

        public bool Send(string subject, string noteText, bool ShowDialog = true)
        {
            int flags = 0;

            if (ShowDialog)
            {
                flags = MAPI_DIALOG;
            }

            lastMsg = new MapiMessage
            {
                subject = subject,
                noteText = noteText,
                originator = AllocOrigin()
            };

            // set pointers
            lastMsg.recips = AllocRecips(out lastMsg.recipCount);
            lastMsg.files = AllocAttachs(out lastMsg.fileCount);
            error = UseUnicode
                ? MAPISendMailW(session, winhandle, new MapiMessageW(lastMsg), flags, 0)
                : MAPISendMail(session, winhandle, lastMsg, flags, 0);

            Dealloc();
            Reset();
            return error == 0;
        }

        public void AddRecipient(string name, string addr, bool cc)
        {
            var dest = new MapiRecipDesc
            {
                recipClass = cc ? MapiCC : MapiTO,
                name = name,
                address = addr
            };
            recpts.Add(dest);
        }

        public void AddRecipientBCC(string name, string addr)
        {
            var dest = new MapiRecipDesc
            {
                recipClass = MapiBCC,
                name = name,
                address = addr
            };
            recpts.Add(dest);
        }

        public void SetSender(string senderName, string senderAddress)
        {
            origin.name = senderName;
            origin.address = senderAddress;
        }

        public void Attach(string filepath)
        {
            attachs.Add(filepath);
        }

        private IntPtr AllocOrigin()
        {
            origin.recipClass = MapiORIG;
            Type rtype = UseUnicode ? typeof(MapiRecipDescW) : typeof(MapiRecipDesc);
            int rsize = Marshal.SizeOf(rtype);
            IntPtr ptro = Marshal.AllocHGlobal(rsize);
            if (UseUnicode)
                Marshal.StructureToPtr(new MapiRecipDescW(origin), ptro, false);
            else
                Marshal.StructureToPtr(origin, ptro, false);
            return ptro;
        }

        private IntPtr AllocRecips(out int recipCount)
        {
            recipCount = 0;
            if (recpts.Count == 0)
            {
                return IntPtr.Zero;
            }

            Type rtype = UseUnicode ? typeof(MapiRecipDescW) : typeof(MapiRecipDesc);
            int rsize = Marshal.SizeOf(rtype);
            IntPtr ptrr = Marshal.AllocHGlobal(recpts.Count * rsize);
            var runptr = ptrr.ToInt64();

            for (int i = 0; i < recpts.Count; i++)
            {
                var ptrDest = new IntPtr(runptr);
                if (UseUnicode)
                    Marshal.StructureToPtr(new MapiRecipDescW(recpts[i] as MapiRecipDesc), ptrDest, false);
                else
                    Marshal.StructureToPtr(recpts[i] as MapiRecipDesc, ptrDest, false);
                runptr += rsize;
            }

            recipCount = recpts.Count;
            return ptrr;
        }

        private IntPtr AllocAttachs(out int fileCount)
        {
            fileCount = 0;
            if (attachs == null)
            {
                return IntPtr.Zero;
            }
            if (attachs.Count <= 0 || attachs.Count > 100)
            {
                return IntPtr.Zero;
            }

            Type atype = UseUnicode ? typeof(MapiFileDescW) : typeof(MapiFileDesc);
            int asize = Marshal.SizeOf(atype);
            IntPtr ptra = Marshal.AllocHGlobal(attachs.Count * asize);

            var mfd = new MapiFileDesc
            {
                position = -1
            };
            var runptr = ptra.ToInt64();

            for (int i = 0; i < attachs.Count; i++)
            {
                var path = attachs[i] as string;
                mfd.name = Path.GetFileName(path);
                mfd.path = path;
                var ptrDest = new IntPtr(runptr);
                if (UseUnicode)
                    Marshal.StructureToPtr(new MapiFileDescW(mfd), ptrDest, false);
                else
                    Marshal.StructureToPtr(mfd, ptrDest, false);
                runptr += asize;
            }

            fileCount = attachs.Count;
            return ptra;
        }

        private void Dealloc()
        {
            Type rtype = UseUnicode ? typeof(MapiRecipDescW) : typeof(MapiRecipDesc);
            int rsize = Marshal.SizeOf(rtype);

            if (lastMsg.originator != IntPtr.Zero)
            {
                Marshal.DestroyStructure(lastMsg.originator, rtype);
                Marshal.FreeHGlobal(lastMsg.originator);
            }

            if (lastMsg.recips != IntPtr.Zero)
            {
                var runptr = lastMsg.recips.ToInt64();
                for (int i = 0; i < lastMsg.recipCount; i++)
                {
                    var ptrDest = new IntPtr(runptr);
                    Marshal.DestroyStructure(ptrDest, rtype);
                    runptr += rsize;
                }
                Marshal.FreeHGlobal(lastMsg.recips);
            }

            if (lastMsg.files != IntPtr.Zero)
            {
                Type ftype = UseUnicode ? typeof(MapiFileDescW) : typeof(MapiFileDesc);
                int fsize = Marshal.SizeOf(ftype);

                var runptr = lastMsg.files.ToInt64();
                for (int i = 0; i < lastMsg.fileCount; i++)
                {
                    var ptrDest = new IntPtr(runptr);
                    Marshal.DestroyStructure(ptrDest, ftype);
                    runptr += fsize;
                }
                Marshal.FreeHGlobal(lastMsg.files);
            }
        }

        private const int MapiORIG = 0;
        private const int MapiTO = 1;
        private const int MapiCC = 2;
        private const int MapiBCC = 3;

        [DllImport("MAPI32.DLL", CharSet = CharSet.Ansi)]
        private static extern int MAPISendMail(IntPtr sess, IntPtr hwnd, MapiMessage message, int flg, int rsv);

        [DllImport("MAPI32.DLL", CharSet = CharSet.Unicode)]
        private static extern int MAPISendMailW(IntPtr sess, IntPtr hwnd, MapiMessageW message, int flg, int rsv);

        private MapiRecipDesc origin = new MapiRecipDesc();
        private readonly ArrayList recpts = new ArrayList();
        private readonly ArrayList attachs = new ArrayList();

        #endregion

        #region FINDING

        public bool Next(ref MailEnvelop env)
        {
            error = MAPIFindNext(session, winhandle, null, findseed, MapiLongMsgID, 0, lastMsgID);
            if (error != 0)
            {
                return false;
            }
            findseed = lastMsgID.ToString();

            IntPtr ptrmsg = IntPtr.Zero;
            error = MAPIReadMail(session, winhandle, findseed, MapiEnvOnly | MapiPeek | MapiSuprAttach, 0, ref ptrmsg);
            if (error != 0 || ptrmsg == IntPtr.Zero)
            {
                return false;
            }

            lastMsg = new MapiMessage();
            Marshal.PtrToStructure(ptrmsg, lastMsg);
            var orig = new MapiRecipDesc();
            if (lastMsg.originator != IntPtr.Zero)
            {
                Marshal.PtrToStructure(lastMsg.originator, orig);
            }

            env.id = findseed;
            env.date = DateTime.ParseExact(lastMsg.dateReceived, "yyyy/MM/dd HH:mm", DateTimeFormatInfo.InvariantInfo);
            env.subject = lastMsg.subject;
            env.from = orig.name;
            env.unread = (lastMsg.flags & MapiUnread) != 0;
            env.atts = lastMsg.fileCount;

            error = MAPIFreeBuffer(ptrmsg);
            return error == 0;
        }


        [DllImport("MAPI32.DLL", CharSet = CharSet.Ansi)]
        private static extern int MAPIFindNext(IntPtr sess, IntPtr hwnd, string typ, string seed, int flg, int rsv, StringBuilder id);

        private const int MapiUnreadOnly = 0x00000020;
        private const int MapiGuaranteeFiFo = 0x00000100;
        private const int MapiLongMsgID = 0x00004000;

        private readonly StringBuilder lastMsgID = new StringBuilder(600);
        private string findseed;

        #endregion

        #region READING

        public string Read(string id, out MailAttach[] att)
        {
            att = null;
            IntPtr ptrMsg = IntPtr.Zero;
            error = MAPIReadMail(session, winhandle, id, MapiPeek | MapiSuprAttach, 0, ref ptrMsg);
            if (error != 0 || ptrMsg == IntPtr.Zero)
            {
                return null;
            }

            lastMsg = new MapiMessage();
            Marshal.PtrToStructure(ptrMsg, lastMsg);

            if (lastMsg.fileCount > 0 && lastMsg.fileCount < 100 && lastMsg.files != IntPtr.Zero)
            {
                GetAttachNames(out att);
            }

            MAPIFreeBuffer(ptrMsg);
            return lastMsg.noteText;
        }

        public bool Delete(string id)
        {
            error = MAPIDeleteMail(session, winhandle, id, 0, 0);
            return error == 0;
        }

        public bool SaveAttachm(string id, string name, string savePath)
        {
            IntPtr ptrMsg = IntPtr.Zero;
            error = MAPIReadMail(session, winhandle, id, MapiPeek, 0, ref ptrMsg);
            if (error != 0 || ptrMsg == IntPtr.Zero)
            {
                return false;
            }

            lastMsg = new MapiMessage();
            Marshal.PtrToStructure(ptrMsg, lastMsg);
            bool f = false;
            if (lastMsg.fileCount > 0 && lastMsg.fileCount < 100 && lastMsg.files != IntPtr.Zero)
            {
                f = SaveAttachByName(name, savePath);
            }
            MAPIFreeBuffer(ptrMsg);
            return f;
        }

        private void GetAttachNames(out MailAttach[] att)
        {
            att = new MailAttach[lastMsg.fileCount];
            Type fdtype = typeof(MapiFileDesc);
            int fdsize = Marshal.SizeOf(fdtype);
            var fdtmp = new MapiFileDesc();
            var runptr = lastMsg.files.ToInt64();
            for (int i = 0; i < lastMsg.fileCount; i++)
            {
                var ptrDest = new IntPtr(runptr);
                Marshal.PtrToStructure(ptrDest, fdtmp);
                runptr += fdsize;
                att[i] = new MailAttach();
                if (fdtmp.flags == 0)
                {
                    att[i].position = fdtmp.position;
                    att[i].name = fdtmp.name;
                    att[i].path = fdtmp.path;
                }
            }
        }

        private bool SaveAttachByName(string name, string savePath)
        {
            bool f = true;
            Type fdtype = typeof(MapiFileDesc);
            int fdsize = Marshal.SizeOf(fdtype);
            var fdtmp = new MapiFileDesc();
            var runPtr = lastMsg.files.ToInt64();

            for (int i = 0; i < lastMsg.fileCount; i++)
            {
                var ptrDest = new IntPtr(runPtr);
                Marshal.PtrToStructure(ptrDest, fdtmp);
                runPtr += fdsize;
                if (fdtmp.flags != 0) continue;
                if (fdtmp.name == null) continue;

                try
                {
                    if (name == fdtmp.name)
                    {
                        if (File.Exists(savePath))
                        {
                            File.Delete(savePath);
                        }
                        File.Move(fdtmp.path, savePath);
                    }
                }
                catch (Exception)
                {
                    f = false;
                    error = 13;
                }

                try
                {
                    File.Delete(fdtmp.path);
                }
                catch (Exception)
                {
                    // ignored
                }
            }
            return f;
        }

        [DllImport("MAPI32.DLL", CharSet = CharSet.Ansi)]
        private static extern int MAPIReadMail(IntPtr sess, IntPtr hwnd, string id, int flg, int rsv, ref IntPtr ptrmsg);

        [DllImport("MAPI32.DLL")]
        private static extern int MAPIFreeBuffer(IntPtr ptr);

        [DllImport("MAPI32.DLL", CharSet = CharSet.Ansi)]
        private static extern int MAPIDeleteMail(IntPtr sess, IntPtr hwnd, string id, int flg, int rsv);

        private const int MapiPeek = 0x00000080;
        private const int MapiSuprAttach = 0x00000800;
        private const int MapiEnvOnly = 0x00000040;
        private const int MapiBodyAsFile = 0x00000200;

        private const int MapiUnread = 0x00000001;
        private const int MapiReceiptReq = 0x00000002;
        private const int MapiSent = 0x00000004;

        private MapiMessage lastMsg;

        #endregion

        #region ADDRESS

        public bool SingleAddress(string label, out string name, out string addr)
        {
            name = null;
            addr = null;
            int newrec = 0;
            IntPtr ptrnew = IntPtr.Zero;
            error = MAPIAddress(session, winhandle, null, 1, label, 0, IntPtr.Zero, 0, 0, ref newrec, ref ptrnew);
            if (error != 0 || newrec < 1 || ptrnew == IntPtr.Zero)
            {
                return false;
            }

            var recip = new MapiRecipDesc();
            Marshal.PtrToStructure(ptrnew, recip);
            name = recip.name;
            addr = recip.address;

            MAPIFreeBuffer(ptrnew);
            return true;
        }


        [DllImport("MAPI32.DLL", CharSet = CharSet.Ansi)]
        private static extern int MAPIAddress(IntPtr sess, IntPtr hwnd, string caption,
                                              int editfld, string labels, int recipcount, IntPtr ptrrecips,
                                              int flg, int rsv, ref int newrec, ref IntPtr ptrnew);

        #endregion

        #region ERRORS

        public string Error()
        {
            if (error <= 26)
            {
                return errors[error];
            }
            return "?unknown? [" + error + "]";
        }

        private int error;

        private readonly string[] errors = {
            "OK [0]",
            "User abort [1]",
            "General MAPI failure [2]",
            "MAPI login failure [3]",
            "Disk full [4]",
            "Insufficient memory [5]",
            "Access denied [6]", "-unknown- [7]",
            "Too many sessions [8]",
            "Too many files were specified [9]",
            "Too many recipients were specified [10]",
            "A specified attachment was not found [11]",
            "Attachment open failure [12]",
            "Attachment write failure [13]",
            "Unknown recipient [14]",
            "Bad recipient type [15]",
            "No messages [16]",
            "Invalid message [17]",
            "Text too large [18]",
            "Invalid session [19]",
            "Type not supported [20]",
            "A recipient was specified ambiguously [21]",
            "Message in use [22]",
            "Network failure [23]",
            "Invalid edit fields [24]",
            "Invalid recipients [25]",
            "Not supported [26]"
         };

        public RETURN_VALUE ErrorValue => (RETURN_VALUE)error;

        public enum RETURN_VALUE
        {
            /// <summary>
            /// The call succeeded and the message was sent.
            /// </summary>
            SUCCESS_SUCCESS = 0,

            /// <summary>
            /// The user canceled one of the dialog boxes. No message was sent.
            /// </summary>
            MAPI_E_USER_ABORT = 1,

            /// <summary>
            /// One or more unspecified errors occurred. No message was sent.
            /// </summary>
            MAPI_E_FAILURE = 2,

            /// <summary>
            /// There was no default logon, and the user failed to log on successfully when the logon dialog box was displayed. No message was sent.
            /// </summary>
            MAPI_E_LOGIN_FAILURE = 3,

            //4

            /// <summary>
            /// There was insufficient memory to proceed. No message was sent.
            /// </summary>
            MAPI_E_INSUFFICIENT_MEMORY = 5,

            //6
            //7
            //8

            /// <summary>
            /// There were too many file attachments. No message was sent.
            /// </summary>
            MAPI_E_TOO_MANY_FILES = 9,

            /// <summary>
            /// There were too many recipients. No message was sent.
            /// </summary>
            MAPI_E_TOO_MANY_RECIPIENTS = 10,

            /// <summary>
            /// The specified attachment was not found. No message was sent.
            /// </summary>
            MAPI_E_ATTACHMENT_NOT_FOUND = 11,

            /// <summary>
            /// The specified attachment could not be opened. No message was sent.
            /// </summary>
            MAPI_E_ATTACHMENT_OPEN_FAILURE = 12,

            //13

            /// <summary>
            /// A recipient did not appear in the address list. No message was sent.
            /// </summary>
            MAPI_E_UNKNOWN_RECIPIENT = 14,

            /// <summary>
            /// The type of a recipient was not MAPI_TO, MAPI_CC, or MAPI_BCC. No message was sent.
            /// </summary>
            MAPI_E_BAD_RECIPTYPE = 15,

            //16
            //17

            /// <summary>
            /// The text in the message was too large. No message was sent.
            /// </summary>
            MAPI_E_TEXT_TOO_LARGE = 18,

            //19
            //20

            /// <summary>
            /// A recipient matched more than one of the recipient descriptor structures and MAPI_DIALOG was not set. No message was sent.
            /// </summary>
            MAPI_E_AMBIGUOUS_RECIPIENT = 21,

            //22
            //23
            //24

            /// <summary>
            /// One or more recipients were invalid or did not resolve to any address.
            /// </summary>
            MAPI_E_INVALID_RECIPS = 25,

            //26

            /// <summary>
            /// The MAPI_FORCE_UNICODE flag is specified and Unicode is not supported. Note: This value can be returned by MAPISendMailW only.
            /// </summary>
            MAPI_E_UNICODE_NOT_SUPPORTED = 27,

            /// <summary>
            /// The specified attachment was too large. No message was sent.
            /// </summary>
            MAPI_E_ATTACHMENT_TOO_LARGE = 28
        }

        #endregion
    }
}