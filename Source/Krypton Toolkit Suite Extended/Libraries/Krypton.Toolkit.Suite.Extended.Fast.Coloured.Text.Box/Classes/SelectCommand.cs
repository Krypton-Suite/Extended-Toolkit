#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license or other governing licenses that can be found in the LICENSE.md file or at
 * https://raw.githubusercontent.com/Krypton-Suite/Extended-Toolkit/master/LICENSE
 */

// Original license

/**
* THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY
* KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE
* IMPLIED WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR
* PURPOSE.
*
* License: GNU Lesser General Public License (LGPLv3)
*
* Email: pavel_torgashov@ukr.net.
*
* Copyright (C) Pavel Torgashov, 2011-2016.
*/
#endregion

namespace Krypton.Toolkit.Suite.Extended.Fast.Coloured.Text.Box
{


    /// <summary>
    /// Remembers current selection and restore it after Undo
    /// </summary>
    public class SelectCommand : UndoableCommand
    {
        public SelectCommand(TextSource ts) : base(ts)
        {
        }

        public override void Execute()
        {
            //remember selection
            lastSel = new RangeInfo(ts.CurrentTB.Selection);
        }

        protected override void OnTextChanged(bool invert)
        {
        }

        public override void Undo()
        {
            //restore selection
            ts.CurrentTB.Selection = new Range(ts.CurrentTB, lastSel.Start, lastSel.End);
        }

        public override UndoableCommand Clone()
        {
            var result = new SelectCommand(ts);
            if (lastSel != null)
                result.lastSel = new RangeInfo(new Range(ts.CurrentTB, lastSel.Start, lastSel.End));
            return result;
        }
    }
}