﻿#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license or other governing licenses that can be found in the LICENSE.md file or at
 * https://raw.githubusercontent.com/Krypton-Suite/Extended-Toolkit/master/LICENSE
 */
#endregion

using System.Drawing;
using System.Windows.Forms;

namespace Krypton.Toolkit.Suite.Extended.Drawing.Suite
{
    [ToolboxBitmap(typeof(KryptonTrackBar))]
    public class KryptonGreenTrackBar : KryptonTrackBar
    {
        #region Variables
        private bool _useAccessibleUI;
        #endregion

        #region Properties
        public bool UseAccessibleUI { get => _useAccessibleUI; set { _useAccessibleUI = value; Invalidate(); } }
        #endregion

        #region Constructor
        public KryptonGreenTrackBar()
        {
            Maximum = 255;

            TickStyle = TickStyle.None;

            Size = new Size(182, 27);
        }
        #endregion

        #region Methods
        private void AlterTrackbarUI(bool useAccessibleUI)
        {
            if (useAccessibleUI)
            {
                StateCommon.Tick.Color1 = Color.Empty;

                StateCommon.Track.Color1 = Color.Empty;

                StateCommon.Track.Color2 = Color.Empty;

                StateCommon.Track.Color3 = Color.Empty;

                StateCommon.Track.Color4 = Color.Empty;

                StateCommon.Track.Color5 = Color.Empty;
            }
            else
            {
                StateCommon.Tick.Color1 = Color.Green;

                StateCommon.Track.Color1 = Color.Green;

                StateCommon.Track.Color2 = Color.Green;

                StateCommon.Track.Color3 = Color.Green;

                StateCommon.Track.Color4 = Color.Green;

                StateCommon.Track.Color5 = Color.Green;
            }
        }
        #endregion

        #region Overrides
        protected override void OnPaint(PaintEventArgs e)
        {
            AlterTrackbarUI(_useAccessibleUI);

            base.OnPaint(e);
        }
        #endregion
    }
}