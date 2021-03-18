using System;
using System.Runtime.InteropServices;

namespace Simple.MAPI.NET
{
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public class MapiFileDescW
    {
        public int reserved;
        public int flags;
        public int position;
        public string path;
        public string name;
        public IntPtr type;

        public MapiFileDescW() { }

        protected internal MapiFileDescW(MapiFileDesc fileDesc)
        {
            reserved = fileDesc.reserved;
            flags = fileDesc.flags;
            position = fileDesc.position;
            path = fileDesc.path;
            name = fileDesc.name;
            type = fileDesc.type;
        }
    }
}