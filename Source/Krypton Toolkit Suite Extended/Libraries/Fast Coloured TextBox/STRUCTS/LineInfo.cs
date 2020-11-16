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

using System.Collections.Generic;

namespace Krypton.Toolkit.Suite.Extended.Fast.Coloured.Text.Box
{
    public struct LineInfo
    {
        List<int> cutOffPositions;
        //Y coordinate of line on screen
        internal int startY;
        internal int bottomPadding;
        //indent of secondary wordwrap strings (in chars)
        internal int wordWrapIndent;
        /// <summary>
        /// Visible state
        /// </summary>
        public VisibleState VisibleState;

        public LineInfo(int startY)
        {
            cutOffPositions = null;
            VisibleState = VisibleState.Visible;
            this.startY = startY;
            bottomPadding = 0;
            wordWrapIndent = 0;
        }
        /// <summary>
        /// Positions for wordwrap cutoffs
        /// </summary>
        public List<int> CutOffPositions
        {
            get
            {
                if (cutOffPositions == null)
                    cutOffPositions = new List<int>();
                return cutOffPositions;
            }
        }

        /// <summary>
        /// Count of wordwrap string count for this line
        /// </summary>
        public int WordWrapStringsCount
        {
            get
            {
                switch (VisibleState)
                {
                    case VisibleState.Visible:
                        if (cutOffPositions == null)
                            return 1;
                        else
                            return cutOffPositions.Count + 1;
                    case VisibleState.Hidden: return 0;
                    case VisibleState.StartOfHiddenBlock: return 1;
                }

                return 0;
            }
        }

        internal int GetWordWrapStringStartPosition(int iWordWrapLine)
        {
            return iWordWrapLine == 0 ? 0 : CutOffPositions[iWordWrapLine - 1];
        }

        internal int GetWordWrapStringFinishPosition(int iWordWrapLine, Line line)
        {
            if (WordWrapStringsCount <= 0)
                return 0;
            return iWordWrapLine == WordWrapStringsCount - 1 ? line.Count - 1 : CutOffPositions[iWordWrapLine] - 1;
        }

        /// <summary>
        /// Gets index of wordwrap string for given char position
        /// </summary>
        public int GetWordWrapStringIndex(int iChar)
        {
            if (cutOffPositions == null || cutOffPositions.Count == 0) return 0;
            for (int i = 0; i < cutOffPositions.Count; i++)
                if (cutOffPositions[i] >/*>=*/ iChar)
                    return i;
            return cutOffPositions.Count;
        }
    }
}