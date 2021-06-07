#region BSD License
/*
 *
 * Use of this source code is governed by a BSD-style
 * license or other governing licenses that can be found in the LICENSE.md file or at
 * https://raw.githubusercontent.com/Krypton-Suite/Extended-Toolkit/master/LICENSE
 *
 * Base code by Steve Bate 2003 - 2017 (https://github.com/SteveBate/AdvancedWizard), modifications by Peter Wagner (aka Wagnerp) 2021.
 *
 */
#endregion

namespace Krypton.Toolkit.Suite.Extended.Wizard
{
    /// <summary>
    /// Add AllowPageChange property to allow user to determine whether or not 
    /// the application user can proceed
    /// </summary>
    public class WizardEventArgs : EventArgs
    {
        public WizardEventArgs(int currentPageIndex, Direction direction = Direction.FORWARD)
        {
            CurrentPageIndex = currentPageIndex;
            NextPageIndex = direction == Direction.FORWARD ? currentPageIndex + 1 : currentPageIndex - 1;
            AllowPageChange = true;
        }

        public bool AllowPageChange { get; set; }

        public int CurrentPageIndex { get; }

        public int NextPageIndex { get; set; }
    }
}