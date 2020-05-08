using System;
using System.Runtime.InteropServices;

namespace Krypton.Toolkit.Suite.Extended.Shell
{
    [ComImportAttribute()]
    [InterfaceTypeAttribute(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("000214F2-0000-0000-C000-000000000046")]
    public interface IEnumIDList
    {
        // Retrieves the specified number of item identifiers in the enumeration 
        // sequence and advances the current position by the number of items retrieved
        [PreserveSig()]
        Int32 Next(
            int celt,
            out IntPtr rgelt,
            out int pceltFetched);

        // Skips over the specified number of elements in the enumeration sequence
        [PreserveSig()]
        Int32 Skip(
            int celt);

        // Returns to the beginning of the enumeration sequence
        [PreserveSig()]
        Int32 Reset();

        // Creates a new item enumeration object with the same contents and state as the current one
        [PreserveSig()]
        Int32 Clone(
            out IEnumIDList ppenum);
    }
}