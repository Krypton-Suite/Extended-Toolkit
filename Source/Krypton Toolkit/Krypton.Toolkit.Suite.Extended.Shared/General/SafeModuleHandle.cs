namespace Krypton.Toolkit.Suite.Extended.Shared
{
    // inherits from SafeHandleZeroOrMinusOneIsInvalid, so IsInvalid is already implemented.
    public sealed class SafeModuleHandle : SafeHandleZeroOrMinusOneIsInvalid
    {
        // A default constructor is required for P/Invoke to instantiate the class
        public SafeModuleHandle()
            : base(true)
        {
        }

        protected override bool ReleaseHandle()
        {
            return PlatformInvoke.FreeLibrary(handle);
        }
    }
}