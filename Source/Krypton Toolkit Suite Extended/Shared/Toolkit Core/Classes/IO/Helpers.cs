using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace Krypton.Toolkit.Suite.Extended.Core
{
    public class Helpers
    {
        #region Methods
        [MethodImpl(MethodImplOptions.NoInlining)]
        public static string GetCurrentMethod()
        {
            var stackTrace = new StackTrace();

            var stackFrame = stackTrace.GetFrame(1);

            return stackFrame.GetMethod().Name;
        }
        #endregion
    }
}