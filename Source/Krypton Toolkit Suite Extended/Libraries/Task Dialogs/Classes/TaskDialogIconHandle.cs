using System;
using System.Drawing;

namespace Krypton.Toolkit.Suite.Extended.Task.Dialogs
{
    /// <summary>
    /// 
    /// </summary>
    public class TaskDialogIconHandle : TaskDialogIcon
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="iconHandle"></param>
        public TaskDialogIconHandle(IntPtr iconHandle) => IconHandle = iconHandle;

#if !NET_STANDARD
        /// <summary>
        /// 
        /// </summary>
        /// <param name="icon"></param>
        public TaskDialogIconHandle(Icon icon) : this(icon?.Handle ?? default)
        {
        }
#endif

        /// <summary>
        /// 
        /// </summary>
        public IntPtr IconHandle { get; }
    }
}