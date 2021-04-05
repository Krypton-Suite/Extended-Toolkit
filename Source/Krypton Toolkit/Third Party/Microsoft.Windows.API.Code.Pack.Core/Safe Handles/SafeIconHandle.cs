namespace Microsoft.Windows.API.Code.Pack.Core
{
    /// <summary>
    /// Safe Icon Handle
    /// </summary>
    public class SafeIconHandle : ZeroInvalidHandle
    {
        /// <summary>
        /// Release the handle
        /// </summary>
        /// <returns>true if handled is release successfully, false otherwise</returns>
        protected override bool ReleaseHandle()
        {
            if (CoreNativeMethods.DestroyIcon(handle))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}