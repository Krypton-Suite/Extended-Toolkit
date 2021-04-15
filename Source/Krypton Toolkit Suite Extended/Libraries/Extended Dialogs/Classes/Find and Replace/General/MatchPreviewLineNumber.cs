#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license or other governing licenses that can be found in the LICENSE.md file or at
 * https://raw.githubusercontent.com/Krypton-Suite/Extended-Toolkit/master/LICENSE
 */
#endregion

using System.Collections.Generic;

namespace Krypton.Toolkit.Suite.Extended.Dialogs
{
    public class MatchPreviewLineNumber
    {
        public int LineNumber { get; set; }

        public bool HasMatch { get; set; }
    }

    public class LineNumberComparer : IEqualityComparer<MatchPreviewLineNumber>
    {
        public bool Equals(MatchPreviewLineNumber x, MatchPreviewLineNumber y)
        {
            return x.LineNumber == y.LineNumber;
        }

        public int GetHashCode(MatchPreviewLineNumber obj)
        {
            return obj.LineNumber.GetHashCode();
        }
    }
}