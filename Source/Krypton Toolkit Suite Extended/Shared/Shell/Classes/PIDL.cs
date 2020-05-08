using System;
using System.Collections;
using System.Runtime.InteropServices;
using System.Text;

namespace Krypton.Toolkit.Suite.Extended.Shell
{
    internal class PIDL : IEnumerable
    {
        private IntPtr pidl = IntPtr.Zero;

        #region Constructors

        public PIDL(IntPtr pidl, bool clone)
        {
            if (clone)
                this.pidl = ILClone(pidl);
            else
                this.pidl = pidl;
        }

        public PIDL(PIDL pidl, bool clone)
        {
            if (clone)
                this.pidl = ILClone(pidl.Ptr);
            else
                this.pidl = pidl.Ptr;
        }

        #endregion

        #region Public

        public IntPtr Ptr { get { return pidl; } }

        public void Append(IntPtr appendPidl)
        {
            IntPtr newPidl = ILCombine(pidl, appendPidl);

            Marshal.FreeCoTaskMem(pidl);
            pidl = newPidl;
        }

        public void Insert(IntPtr insertPidl)
        {
            IntPtr newPidl = ILCombine(insertPidl, pidl);

            Marshal.FreeCoTaskMem(pidl);
            pidl = newPidl;
        }

        public static bool IsEmpty(IntPtr pidl)
        {
            if (pidl == IntPtr.Zero)
                return true;

            byte[] bytes = new byte[2];
            Marshal.Copy(pidl, bytes, 0, 2);
            int size = bytes[0] + bytes[1] * 256;
            return (size <= 2);
        }

        public static bool SplitPidl(IntPtr pidl, out IntPtr parent, out IntPtr child)
        {
            parent = ILClone(pidl);
            child = ILClone(ILFindLastID(pidl));

            if (!ILRemoveLastID(parent))
            {
                Marshal.FreeCoTaskMem(parent);
                Marshal.FreeCoTaskMem(child);
                return false;
            }
            else
            {
                return true;
            }
        }

        public static void Write(IntPtr pidl)
        {
            StringBuilder path = new StringBuilder(256);
            ShellAPI.SHGetPathFromIDList(pidl, path);
            Console.Out.WriteLine("Pidl: {0}", path);
        }

        public static void WriteBytes(IntPtr pidl)
        {
            int size = Marshal.ReadByte(pidl, 0) + Marshal.ReadByte(pidl, 1) * 256 - 2;

            for (int i = 0; i < size; i++)
            {
                Console.Out.WriteLine(Marshal.ReadByte(pidl, i + 2));
            }

            Console.Out.WriteLine(Marshal.ReadByte(pidl, size + 2));
            Console.Out.WriteLine(Marshal.ReadByte(pidl, size + 3));
        }

        public void Free()
        {
            if (pidl != IntPtr.Zero)
            {
                Marshal.FreeCoTaskMem(pidl);
                pidl = IntPtr.Zero;
            }
        }

        #endregion

        #region Shell

        private static int ItemIDSize(IntPtr pidl)
        {
            if (!pidl.Equals(IntPtr.Zero))
            {
                byte[] buffer = new byte[2];
                Marshal.Copy(pidl, buffer, 0, 2);
                return buffer[1] * 256 + buffer[0];
            }
            else
                return 0;
        }

        private static int ItemIDListSize(IntPtr pidl)
        {
            if (pidl.Equals(IntPtr.Zero))
                return 0;
            else
            {
                int size = ItemIDSize(pidl);
                int nextSize = Marshal.ReadByte(pidl, size) + (Marshal.ReadByte(pidl, size + 1) * 256);
                while (nextSize > 0)
                {
                    size += nextSize;
                    nextSize = Marshal.ReadByte(pidl, size) + (Marshal.ReadByte(pidl, size + 1) * 256);
                }

                return size;
            }
        }

        // Clones an ITEMIDLIST structure
        public static IntPtr ILClone(IntPtr pidl)
        {
            int size = ItemIDListSize(pidl);

            byte[] bytes = new byte[size + 2];
            Marshal.Copy(pidl, bytes, 0, size);

            IntPtr newPidl = Marshal.AllocCoTaskMem(size + 2);
            Marshal.Copy(bytes, 0, newPidl, size + 2);

            return newPidl;
        }

        // Clones the first SHITEMID structure in an ITEMIDLIST structure
        public static IntPtr ILCloneFirst(IntPtr pidl)
        {
            int size = ItemIDSize(pidl);

            byte[] bytes = new byte[size + 2];
            Marshal.Copy(pidl, bytes, 0, size);

            IntPtr newPidl = Marshal.AllocCoTaskMem(size + 2);
            Marshal.Copy(bytes, 0, newPidl, size + 2);

            return newPidl;
        }

        // Gets the next SHITEMID structure in an ITEMIDLIST structure
        public static IntPtr ILGetNext(IntPtr pidl)
        {
            int size = ItemIDSize(pidl);
            IntPtr nextPidl = new IntPtr((int)pidl + size);
            return nextPidl;
        }

        // Returns a pointer to the last SHITEMID structure in an ITEMIDLIST structure
        public static IntPtr ILFindLastID(IntPtr pidl)
        {
            IntPtr ptr1 = pidl;
            IntPtr ptr2 = ILGetNext(ptr1);

            while (ItemIDSize(ptr2) > 0)
            {
                ptr1 = ptr2;
                ptr2 = ILGetNext(ptr1);
            }

            return ptr1;
        }

        // Removes the last SHITEMID structure from an ITEMIDLIST structure
        public static bool ILRemoveLastID(IntPtr pidl)
        {
            IntPtr lastPidl = ILFindLastID(pidl);

            if (lastPidl != pidl)
            {
                int newSize = (int)lastPidl - (int)pidl + 2;
                Marshal.ReAllocCoTaskMem(pidl, newSize);
                Marshal.Copy(new byte[] { 0, 0 }, 0, new IntPtr((int)pidl + newSize - 2), 2);

                return true;
            }
            else
                return false;
        }

        // Combines two ITEMIDLIST structures
        public static IntPtr ILCombine(IntPtr pidl1, IntPtr pidl2)
        {
            int size1 = ItemIDListSize(pidl1);
            int size2 = ItemIDListSize(pidl2);

            IntPtr newPidl = Marshal.AllocCoTaskMem(size1 + size2 + 2);
            byte[] bytes = new byte[size1 + size2 + 2];

            Marshal.Copy(pidl1, bytes, 0, size1);
            Marshal.Copy(pidl2, bytes, size1, size2);

            Marshal.Copy(bytes, 0, newPidl, bytes.Length);

            return newPidl;
        }

        #endregion

        #region IEnumerable Members

        public IEnumerator GetEnumerator()
        {
            return new PIDLEnumerator(pidl);
        }

        #endregion

        #region Override

        public override bool Equals(object obj)
        {
            try
            {
                if (obj is IntPtr)
                    return ShellAPI.ILIsEqual(this.Ptr, (IntPtr)obj);
                if (obj is PIDL)
                    return ShellAPI.ILIsEqual(this.Ptr, ((PIDL)obj).Ptr);
                else
                    return false;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public override int GetHashCode()
        {
            return pidl.GetHashCode();
        }

        #endregion

        public class PIDLEnumerator : IEnumerator
        {
            private IntPtr pidl;
            private IntPtr currentPidl;
            private IntPtr clonePidl;
            private bool start;

            public PIDLEnumerator(IntPtr pidl)
            {
                start = true;
                this.pidl = pidl;
                currentPidl = pidl;
                clonePidl = IntPtr.Zero;
            }

            #region IEnumerator Members

            public object Current
            {
                get
                {
                    if (clonePidl != IntPtr.Zero)
                    {
                        Marshal.FreeCoTaskMem(clonePidl);
                        clonePidl = IntPtr.Zero;
                    }

                    clonePidl = PIDL.ILCloneFirst(currentPidl);
                    return clonePidl;
                }
            }

            public bool MoveNext()
            {
                if (clonePidl != IntPtr.Zero)
                {
                    Marshal.FreeCoTaskMem(clonePidl);
                    clonePidl = IntPtr.Zero;
                }

                if (start)
                {
                    start = false;
                    return true;
                }
                else
                {
                    IntPtr newPidl = ILGetNext(currentPidl);

                    if (!PIDL.IsEmpty(newPidl))
                    {
                        currentPidl = newPidl;
                        return true;
                    }
                    else
                        return false;
                }
            }

            public void Reset()
            {
                start = true;
                currentPidl = pidl;

                if (clonePidl != IntPtr.Zero)
                {
                    Marshal.FreeCoTaskMem(clonePidl);
                    clonePidl = IntPtr.Zero;
                }
            }

            #endregion
        }
    }
}