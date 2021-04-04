using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace Krypton.Toolkit.Suite.Extended.Developer.Utilities
{
    public class MethodHelpers
    {
        [MethodImpl(MethodImplOptions.NoInlining)]
        public static string GetCurrentMethod()
        {
            var stackTrace = new StackTrace();

            var stackFrame = stackTrace.GetFrame(1);

            return stackFrame.GetMethod().ToString();
        }
    }
}