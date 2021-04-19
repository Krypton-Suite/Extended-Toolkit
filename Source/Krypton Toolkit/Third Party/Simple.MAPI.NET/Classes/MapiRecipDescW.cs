using System;
using System.Runtime.InteropServices;

namespace Simple.MAPI.NET
{
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public class MapiRecipDescW
    {
        public int reserved;
        public int recipClass;
        public string name;
        public string address;
        public int eIDSize;
        public IntPtr entryID; // void*

        public MapiRecipDescW() { }

        protected internal MapiRecipDescW(MapiRecipDesc recipDesc)
        {
            reserved = recipDesc.reserved;
            recipClass = recipDesc.recipClass;
            name = recipDesc.name;
            address = recipDesc.address;
            eIDSize = recipDesc.eIDSize;
            entryID = recipDesc.entryID;
        }
    }
}