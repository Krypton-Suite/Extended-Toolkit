#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license or other governing licenses that can be found in the LICENSE.md file or at
 * https://raw.githubusercontent.com/Krypton-Suite/Extended-Toolkit/master/LICENSE
 */
#endregion

namespace Krypton.Toolkit.Suite.Extended.Networking
{
    public class ComputerEnum : IEnumerable, IDisposable
    {
        #region "Server type enumeration"
        // Possible types of servers
        [FlagsAttribute]
        public enum ServerType : uint
        {
            /// <summary>
            /// All workstations
            /// </summary>
            SV_TYPE_WORKSTATION = 0x00000001,
            /// <summary>
            /// All computers that have the server service running
            /// </summary>
            SV_TYPE_SERVER = 0x00000002,
            /// <summary>
            /// Any server running Microsoft SQL Server
            /// </summary>
            SV_TYPE_SQLSERVER = 0x00000004,
            /// <summary>
            /// Primary domain controller
            /// </summary>
            SV_TYPE_DOMAIN_CTRL = 0x00000008,
            /// <summary>
            /// Backup domain controller
            /// </summary>
            SV_TYPE_DOMAIN_BAKCTRL = 0x00000010,
            /// <summary>
            /// Server running the Timesource service
            /// </summary>
            SV_TYPE_TIME_SOURCE = 0x00000020,
            /// <summary>
            /// Apple File Protocol servers
            /// </summary>
            SV_TYPE_AFP = 0x00000040,
            /// <summary>
            /// Novell servers
            /// </summary>
            SV_TYPE_NOVELL = 0x00000080,
            /// <summary>
            /// LAN Manager 2.x domain member
            /// </summary>
            SV_TYPE_DOMAIN_MEMBER = 0x00000100,
            /// <summary>
            /// Server sharing print queue
            /// </summary>
            SV_TYPE_PRINTQ_SERVER = 0x00000200,
            /// <summary>
            /// Server running dial-in service
            /// </summary>
            SV_TYPE_DIALIN_SERVER = 0x00000400,
            /// <summary>
            /// Xenix server
            /// </summary>
            SV_TYPE_XENIX_SERVER = 0x00000800,
            /// <summary>
            /// Windows NT workstation or server
            /// </summary>
            SV_TYPE_NT = 0x00001000,
            /// <summary>
            /// Server running Windows for Workgroups
            /// </summary>
            SV_TYPE_WFW = 0x00002000,
            /// <summary>
            /// Microsoft File and Print for NetWare
            /// </summary>
            SV_TYPE_SERVER_MFPN = 0x00004000,
            /// <summary>
            /// Server that is not a domain controller
            /// </summary>
            SV_TYPE_SERVER_NT = 0x00008000,
            /// <summary>
            /// Server that can run the browser service
            /// </summary>
            SV_TYPE_POTENTIAL_BROWSER = 0x00010000,
            /// <summary>
            /// Server running a browser service as backup
            /// </summary>
            SV_TYPE_BACKUP_BROWSER = 0x00020000,
            /// <summary>
            /// Server running the master browser service
            /// </summary>
            SV_TYPE_MASTER_BROWSER = 0x00040000,
            /// <summary>
            /// Server running the domain master browser
            /// </summary>
            SV_TYPE_DOMAIN_MASTER = 0x00080000,
            /// <summary>
            /// Windows 95 or later
            /// </summary>
            SV_TYPE_WINDOWS = 0x00400000,
            /// <summary>
            /// Root of a DFS tree
            /// </summary>
            SV_TYPE_DFS = 0x00800000,
            /// <summary>
            /// Terminal Server
            /// </summary>
            SV_TYPE_TERMINALSERVER = 0x02000000,
            /// <summary>
            /// Server clusters available in the domain
            /// </summary>
            SV_TYPE_CLUSTER_NT = 0x01000000,
            /// <summary>
            /// Cluster virtual servers available in the domain
            /// (Not supported for Windows 2000/NT)
            /// </summary>			
            SV_TYPE_CLUSTER_VS_NT = 0x04000000,
            /// <summary>
            /// IBM DSS (Directory and Security Services) or equivalent
            /// </summary>
            SV_TYPE_DCE = 0x10000000,
            /// <summary>
            /// Return list for alternate transport
            /// </summary>
            SV_TYPE_ALTERNATE_XPORT = 0x20000000,
            /// <summary>
            /// Return local list only
            /// </summary>
            SV_TYPE_LOCAL_LIST_ONLY = 0x40000000,
            /// <summary>
            /// Lists available domains
            /// </summary>
            SV_TYPE_DOMAIN_ENUM = 0x80000000
        }
        #endregion

        // Holds computer information
        [StructLayoutAttribute(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
        internal struct SERVER_INFO_101
        {
            public int sv101_platform_id;
            public string sv101_name;
            public int sv101_version_major;
            public int sv101_version_minor;
            public int sv101_type;
            public string sv101_comment;
        }

        // enumerates network computers
        [DllImport("Netapi32", CharSet = CharSet.Unicode)]
        private static extern int NetServerEnum(
            string servername,      // must be null
            int level,              // 100 or 101
            out IntPtr bufptr,      // pointer to buffer receiving data
            int prefmaxlen,         // max length of returned data
            out int entriesread,    // num entries read
            out int totalentries,   // total servers + workstations
            uint servertype,        // server type filter
            [MarshalAs(UnmanagedType.LPWStr)]
            string domain,          // domain to enumerate
            IntPtr resume_handle);

        // Frees buffer created by NetServerEnum
        [DllImport("netapi32.dll")]
        private extern static int NetApiBufferFree(
            IntPtr buf);

        // Constants
        private const int ERROR_ACCESS_DENIED = 5;
        private const int ERROR_MORE_DATA = 234;

        private NetworkComputers[] _computers;
        private string _lastError = "";

        /// <summary>
        /// Converts ServerType to its underlying value
        /// </summary>
        /// <param name="serverType">One of the ServerType values</param>
        /// <param name="domain">The domain to search for computers in</param>
        public ComputerEnum(ServerType serverType, string domain) : this(UInt32.Parse(Enum.Format(typeof(ServerType), serverType, "x"), System.Globalization.NumberStyles.HexNumber), domain)
        {

        }
        /// <summary>
        /// Populates with broadcasting computers.
        /// </summary>
        /// <param name="serverType">Server type filter</param>
        /// <param name="domain">The domain to search for computers in</param>
        public ComputerEnum(uint serverType, string domainName)
        {
            int entriesread;  // number of entries actually read
            int totalentries; // total visible servers and workstations
            int result;       // result of the call to NetServerEnum

            // Pointer to buffer that receives the data
            IntPtr pBuf = IntPtr.Zero;
            Type svType = typeof(SERVER_INFO_101);

            // structure containing info about the server
            SERVER_INFO_101 si;

            try
            {
                result = NetServerEnum(
                    null,
                    101,
                    out pBuf,
                    -1,
                    out entriesread,
                    out totalentries,
                    serverType,
                    domainName,
                    IntPtr.Zero);

                // Successful?
                if (result != 0)
                {
                    switch (result)
                    {
                        case ERROR_MORE_DATA:
                            _lastError = "More data is available";
                            break;
                        case ERROR_ACCESS_DENIED:
                            _lastError = "Access was denied";
                            break;
                        default:
                            _lastError = "Unknown error code " + result;
                            break;
                    }
                    return;
                }
                else
                {
                    _computers = new NetworkComputers[entriesread];

                    int tmp = (int)pBuf;
                    for (int i = 0; i < entriesread; i++)
                    {
                        // fill our struct
                        si = (SERVER_INFO_101)Marshal.PtrToStructure((IntPtr)tmp, svType);
                        _computers[i] = new NetworkComputers(si);

                        // next struct
                        tmp += Marshal.SizeOf(svType);
                    }
                }
            }
            finally
            {
                // free the buffer
                NetApiBufferFree(pBuf);
                pBuf = IntPtr.Zero;
            }
        }

        /// <summary>
        /// Total computers in the collection
        /// </summary>
        public int Length
        {
            get
            {
                if (_computers != null)
                {
                    return _computers.Length;
                }
                else
                {
                    return 0;
                }
            }
        }

        /// <summary>
        /// Last error message
        /// </summary>
        public string LastError
        {
            get { return _lastError; }
        }

        /// <summary>
        /// Obtains the enumerator for ComputerEnumerator class
        /// </summary>
        /// <returns>IEnumerator</returns>
        public IEnumerator GetEnumerator()
        {
            return new ComputerEnumerator(_computers);
        }

        // cleanup
        public void Dispose()
        {
            _computers = null;
        }

        public NetworkComputers this[int item]
        {
            get
            {
                return _computers[item];
            }
        }

        // holds computer info.
        public struct NetworkComputers
        {
            SERVER_INFO_101 _computerinfo;
            internal NetworkComputers(SERVER_INFO_101 info)
            {
                _computerinfo = info;
            }

            /// <summary>
            /// Name of computer
            /// </summary>
            public string Name
            {
                get { return _computerinfo.sv101_name; }
            }
            /// <summary>
            /// Server comment
            /// </summary>
            public string Comment
            {
                get { return _computerinfo.sv101_comment; }
            }
            /// <summary>
            /// Major version number of OS
            /// </summary>
            public int VersionMajor
            {
                get { return _computerinfo.sv101_version_major; }
            }
            /// <summary>
            /// Minor version number of OS
            /// </summary>
            public int VersionMinor
            {
                get { return _computerinfo.sv101_version_minor; }
            }
        }

        /// <summary>
        /// Enumerates the collection of computers
        /// </summary>
        public class ComputerEnumerator : IEnumerator
        {
            private NetworkComputers[] aryComputers;
            private int indexer;

            internal ComputerEnumerator(NetworkComputers[] networkComputers)
            {
                aryComputers = networkComputers;
                indexer = -1;
            }

            public void Reset()
            {
                indexer = -1;
            }

            public object Current
            {
                get
                {
                    return aryComputers[indexer];
                }
            }
            public bool MoveNext()
            {
                if (aryComputers == null)
                    return false;
                if (indexer < aryComputers.Length)
                    indexer++;
                return (!(indexer == aryComputers.Length));
            }
        }
    }
}