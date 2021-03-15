#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license or other governing licenses that can be found in the LICENSE.md file or at
 * https://raw.githubusercontent.com/Krypton-Suite/Extended-Toolkit/master/LICENSE
 */
#endregion

using System;

namespace Krypton.Toolkit.Suite.Extended.Drawing.Suite
{
    public class ColourEvents
    {
        public delegate void SelectedColourChangedEventHandler(object sender, EventArgs e);

        public event SelectedColourChangedEventHandler SelectedColourChanged;


        protected virtual void OnSelectedColourChanged()
        {
            if (SelectedColourChanged != null) SelectedColourChanged(this, EventArgs.Empty);
        }
    }
}