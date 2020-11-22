#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license or other governing licenses that can be found in the LICENSE.md file or at
 * https://raw.githubusercontent.com/Krypton-Suite/Extended-Toolkit/master/LICENSE
 */
#endregion

using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace Krypton.Toolkit.Suite.Extended.Core
{
    public class Helpers
    {
        #region Arrays
        public string[] DriveLetters = new string[] { @"A:\\", @"B:\\", @"C:\\", @"D:\\", @"E:\\", @"F:\\", @"G:\\", @"H:\\", @"I:\\", @"J:\\", @"K:\\", @"L:\\", @"M:\\", @"N:\\", @"O:\\", @"P:\\", @":\\" };
        #endregion

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